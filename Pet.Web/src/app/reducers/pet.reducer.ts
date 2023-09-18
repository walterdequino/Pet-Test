import { Action } from '@ngrx/store';

import { Pet } from '../models/pet';

export const ADD = 'ADD';
export const REMOVE = 'REMOVE';

export function addOrRemoveRandomPetReducer(state: Pet[] = [], action: Action): any {
  switch (action.type) {
    case ADD:
      return [...state, getRandomPet()];
    case REMOVE:
      if (!state || state.length < 1) {
        return state;
      }
      const index = Math.floor(Math.random() * state.length);
      const newState = Object.assign([], state);
      newState.splice(index, 1);
      return newState;
    default:
      return state;
  }
}

export function getRandomPet(): Pet {
  const names = ['Pepe', 'Juan', 'Jose'];
  const breads = ['Pasto', 'Canario', 'Pet'];
  const types = ['Perro', 'Gato', 'Pájaro'];
  const sizes = ['Grande', 'Mediano', 'Pequeño'];
  const statuses = [1, 2, 3, 1, 2, 3, 1, 2, 3];
  const genders = ['Macho', 'Hembra'];

  const randomPet = {
    name: names[Math.floor(Math.random() * names.length)],
    breed: breads[Math.floor(Math.random() * breads.length)],
    typeDescription: types[Math.floor(Math.random() * types.length)],
    sizeDescription: sizes[Math.floor(Math.random() * sizes.length)],
    status: statuses[Math.floor(Math.random() * statuses.length)],
    genderDescription: genders[Math.floor(Math.random() * genders.length)]
  } as Pet;

  return randomPet;
}
