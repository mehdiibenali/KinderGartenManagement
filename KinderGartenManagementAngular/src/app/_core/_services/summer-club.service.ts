import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class SummerClubService {

  constructor(private api :ApiService) { }
  GetAll(){
    return this.api.get('/api/EnrollementSummerClubs')
  }
  ByEleveId(eleveid){
    return this.api.get('/api/EnrollementSummerClubs/ByEleveId/'+eleveid)
  }
  AddClub(club){
    return this.api.post('/api/EnrollementSummerClubs',club);
  }
  Search(search){
    return this.api.post('/api/EnrollementSummerClubs/Search',search)
  }
  GetYears(eleveid){
    return this.api.get('/api/EnrollementSummerClubs/GetYears/'+eleveid)
  }
}
