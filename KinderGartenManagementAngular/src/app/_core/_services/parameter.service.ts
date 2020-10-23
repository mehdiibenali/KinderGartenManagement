import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {

  constructor(
    private apiService:ApiService,
  ) { }
  GetByCode(Code:string){
    return this.apiService.get('/api/Parameters/'+Code);
  }
  GetDates(annee){
    return this.apiService.get('/api/Parameters/GetDates/'+annee)
  }
}  
