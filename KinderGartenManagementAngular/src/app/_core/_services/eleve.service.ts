import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Eleve } from '../_models/eleve';

@Injectable({
  providedIn: 'root'
})
export class EleveService {

  constructor(private api : ApiService,) { }
  AddEleve(eleve:Eleve){
    return this.api.post('/api/Eleves',eleve);
  }
  GetAll(){
    return this.api.get('/api/Eleves')
  }
  Search(search){
    return this.api.post('/api/Eleves/Search',search)
  }
  DeleteEleve(id){
    return this.api.delete('/api/Eleves/'+id) 
  }
  UpdateEleve(eleve,id){
    return this.api.put('/api/Eleves/'+id,eleve)
  }
  GetById(id:number){
    return this.api.get('/api/Eleves/'+id)
  }
}
