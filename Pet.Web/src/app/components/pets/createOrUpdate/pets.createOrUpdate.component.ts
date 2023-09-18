import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MessageService } from 'primeng/api';
import { Subscription, take } from 'rxjs';

import { PetService } from '../pet.service';
import { Pet } from 'src/app/models/pet';
import { HttpPetService } from 'src/app/services/http-pet.service';

@Component({
  selector: 'pets-c-or-u',
  templateUrl: './pets.createOrUpdate.component.html'
})
export class PetsCreateOrUpdateComponent implements OnInit, OnDestroy {
  public petForm!: FormGroup;
  public petCreateOrUpdateDialog: boolean = false;

  public genders = [
    { name: 'Macho', code: 1 },
    { name: 'Hembra', code: 2 }
  ];

  public statuses = [
    { name: 'Disponible', code: 1 },
    { name: 'Adoptado', code: 2 },
    { name: 'Perdido', code: 3 }
  ];

  private suscription: Subscription[] = [];

  constructor(
    private httpPetService: HttpPetService,
    private fb: FormBuilder,
    private petService: PetService,
    private messageService: MessageService
  ) {}

  public ngOnInit(): void {
    this.petService.openModal.subscribe(open => {
      this.openOpUp(open);
    });
  }

  public ngOnDestroy(): void {
    this.suscription.forEach(_ => _.unsubscribe());
  }

  public hideDialog(): void {
    this.petCreateOrUpdateDialog = false;
  }

  public savePet(): void {
    const petToAdd = this.petForm.getRawValue() as Pet;

    if (!this.petForm.valid) {
      this.petForm.markAllAsTouched();
      return;
    }

    if (this.petForm.valid) {
      if (petToAdd.id) {
        this.suscription.push(
          this.httpPetService
            .update(petToAdd)
            .pipe(take(1))
            .subscribe(() => {
              this.finishModal();
              this.messageService.add({ severity: 'success', summary: 'Confirmed', detail: 'Operación realizada!' });
            })
        );
      } else {
        this.suscription.push(
          this.httpPetService
            .create(petToAdd)
            .pipe(take(1))
            .subscribe(() => {
              this.finishModal();
              this.messageService.add({ severity: 'success', summary: 'Confirmed', detail: 'Operación realizada!' });
            })
        );
      }
    }
  }

  public openOpUp(open: boolean): void {
    if (open) {
      this.buildForm();

      if (this.petService.actualPet) {
        this.petForm.reset(this.petService.actualPet);
      }

      this.petCreateOrUpdateDialog = open;
    }
  }

  public fieldIsInvalid(controlName: string): boolean {
    const controlForm = this.petForm.get(controlName);
    if (!controlForm) {
      return true;
    }

    return controlForm.errors != null && controlForm.errors && controlForm.touched;
  }

  public cancel(): void {
    this.petForm.reset();
    this.petService.actualPet = null;
  }

  private buildForm(): void {
    this.petForm = this.fb.group({
      id: ['', []],
      name: ['', [Validators.required]],
      breed: ['', [Validators.required]],
      type: [null, [Validators.required]],
      size: [null, [Validators.required]],
      gender: [null, [Validators.required]],
      status: [null, [Validators.required]]
    });
  }

  private finishModal(): void {
    this.hideDialog();
    this.petForm.reset();

    this.petService.openModal.next(false);
    this.petService.actualPet = null;
    this.suscription.forEach(_ => _.unsubscribe());
  }
}
