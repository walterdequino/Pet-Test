import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from '../environments/environment';
import { Pet } from '../models/pet';

@Injectable({
  providedIn: 'root'
})
export class HttpPetService {
  private baseUrl = `${environment.apiUrl}/pet`;
  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<Pet[]> {
    return this.httpClient.get<Pet[]>(`${this.baseUrl}/get-all`);
  }

  public create(pet: Pet): Observable<unknown> {
    return this.httpClient.post(`${this.baseUrl}/create`, pet);
  }

  public update(pet: Pet): Observable<unknown> {
    return this.httpClient.put(`${this.baseUrl}/update`, pet);
  }

  public delete(id: string): Observable<unknown> {
    return this.httpClient.delete(`${this.baseUrl}/delete/${id}`);
  }
}
