import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ConventionService {

  constructor(private api : ApiService,) { }
  GetAll(){
    return this.api.get('/api/Conventions')
  }
  GetById(id){
    return this.api.get('/api/Conventions/'+id)
  }
  SearchByYear(year){
    return this.api.get('/api/Conventions/SearchByYear/'+year)
  }
  GetActive(parentid,datetime){
    return this.api.get('/api/Conventions/GetActive/'+parentid+'/'+datetime)
  }
  AddConvention(convention){
    return this.api.post('/api/Conventions',convention)
  }
  AddConventionFee(conventionfee){
    return this.api.post('/api/ConventionFees',conventionfee)
  }
}
