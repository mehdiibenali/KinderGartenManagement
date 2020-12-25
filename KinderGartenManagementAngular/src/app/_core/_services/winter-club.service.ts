import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class WinterClubService {

  constructor(private api :ApiService) { }
  GetAll(){
    return this.api.get('/api/EnrollementWinterClubs')
  }
  ByEleveId(eleveid){
    return this.api.get('/api/EnrollementWinterClubs/ByEleveId/'+eleveid)
  }
  AddClub(club){
    return this.api.post('/api/EnrollementWinterClubs',club);
  }
}
