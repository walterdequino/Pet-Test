import { OnInit, Component, OnDestroy, ViewChild } from '@angular/core';

import { Action, Store } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Subscription, take } from 'rxjs';

import { PetService } from '../pet.service';
import { Pet } from 'src/app/models/pet';
import { ADD, REMOVE } from 'src/app/reducers/pet.reducer';
import { HttpPetService } from 'src/app/services/http-pet.service';

interface PetsState {
  pets: Pet[];
}

@Component({
  selector: 'pets-list',
  templateUrl: './pets.list.component.html'
})
export class PetsListComponent implements OnInit, OnDestroy {
  @ViewChild('dt1', { static: false }) private dt!: Table;

  public pets: Pet[] = [];

  public petsRandom: Pet[] = [];

  public statuses = [
    { name: 'Disponible', code: 1 },
    { name: 'Adoptado', code: 2 },
    { name: 'Perdido', code: 3 }
  ];

  private suscription: Subscription[] = [];

  constructor(
    public httpPetService: HttpPetService,
    public petService: PetService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private store: Store<PetsState>
  ) {
    // Subs to changes
    this.store.subscribe(state => {
      this.petsRandom = [...state.pets];
    });
  }

  public ngOnInit(): void {
    this.petService.openModal.next(false);

    this.searchAll();

    // Refresh when add or remove
    this.suscription.push(
      this.petService.openModal.subscribe(open => {
        if (!open) {
          this.searchAll();
        }
      })
    );
  }

  public ngOnDestroy(): void {
    this.suscription.forEach(_ => _.unsubscribe());
  }

  public getStatus(statusId: number): string {
    switch (statusId) {
      case 1: // Disponible
        return 'info';
      case 2: // Adoptado
        return 'success';
      case 3: // Perdido
        return 'warning';
    }

    return '';
  }

  public getStatusDescription(statusId: number): string {
    switch (statusId) {
      case 1: // Disponible
        return 'Disponible';
      case 2: // Adoptado
        return 'Adoptado';
      case 3: // Perdido
        return 'Perdido';
    }

    return '';
  }
  public createPet(): void {
    this.petService.openModal.next(true);
  }

  public delete(pet: Pet): void {
    this.confirmationService.confirm({
      message: 'Está seguro de eliminar la mascota?',
      header: 'Alerta!',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Si',
      accept: () => {
        this.suscription.push(
          this.httpPetService
            .delete(pet.id)
            .pipe(take(1))
            .subscribe(() => {
              this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Mascota eliminada' });
              this.searchAll();
            })
        );
      }
    });
  }

  public edit(pet: Pet): void {
    this.petService.actualPet = pet;
    this.petService.openModal.next(true);
  }

  public clear(table: Table): void {
    table.clear();
  }

  public applyFilterGlobal($event: any, stringVal: string): void {
    this.dt.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  public removeRandom(): void {
    const action: Action = {
      type: REMOVE
    };

    this.store.dispatch(action);
  }

  public addRandom(): void {
    const action: Action = {
      type: ADD
    };

    this.store.dispatch(action);
  }

  private searchAll(): void {
    this.suscription.push(
      this.httpPetService
        .getAll()
        .pipe(take(1))
        .subscribe(result => {
          this.pets = result;
        })
    );
  }
}
