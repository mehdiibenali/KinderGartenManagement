import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ClubService {

  constructor(private api :ApiService) { }
  GetAll(){
    return this.api.get('/api/EnrollementClubs')
  }
}
