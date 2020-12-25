import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class PayementService {

  constructor(private api : ApiService,) { }
  AddPayement(payement){
    return this.api.post('/api/Payements',payement);
  }
  GetUnpaid(eleveids){
    return this.api.get('/api/Payements/GetUnpaid/'+eleveids)
  }
}
