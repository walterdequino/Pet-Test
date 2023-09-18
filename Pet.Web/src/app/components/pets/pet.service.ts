import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs';

import { Pet } from 'src/app/models/pet';

@Injectable({
  providedIn: 'root'
})
export class PetService {
  public openModal = new BehaviorSubject<boolean>(false);
  public actualPet: Pet | null = null;
}
