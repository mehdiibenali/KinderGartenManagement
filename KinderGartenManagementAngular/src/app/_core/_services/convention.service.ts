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
  GetYears(){
    return this.api.get('/api/Conventions/GetYears')
  }
  Search(search){
    return this.api.post('/api/Conventions/Search',search)
  }
  GetActive(getactive){
    return this.api.post('/api/Conventions/GetActive/',getactive)
  }
  AddConvention(convention){
    return this.api.post('/api/Conventions',convention)
  }
  AddConventionFee(conventionfee){
    return this.api.post('/api/ConventionFees',conventionfee)
  }
}
