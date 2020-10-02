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
  AddPayementEnrollement(payementenrollement){
    return this.api.post('/api/PayementEnrollements',payementenrollement)
  }
  AddModalite(modalite){
    return this.api.post('/api/Modalites',modalite)
  }
  AddPayementDates(payementdates){
    return this.api.post('/api/PayementDates',payementdates)
  }
}
