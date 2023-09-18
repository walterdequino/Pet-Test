import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PetsListComponent } from './components/pets/list/pets.list.component';
import { PrincipalComponent } from './components/principal/principal.component';

const routes: Routes = [
  { path: 'pets/list', component: PetsListComponent },
  { path: 'principal', component: PrincipalComponent },
  { path: '', component: PrincipalComponent }
  // { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
