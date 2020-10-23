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
}
