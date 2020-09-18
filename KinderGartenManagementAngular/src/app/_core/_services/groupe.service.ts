import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Groupe } from '../_models/groupe';

@Injectable({
  providedIn: 'root'
})
export class GroupeService {

  constructor( private api : ApiService) { }
  GetAll(){
    return this.api.get('/api/EnrollementGroupes');
  }
  GetById(id:number){
    return this.api.get('/api/EnrollementGroupes/'+id);
  };
  AddGroupe(groupe:Groupe){
    return this.api.post('/api/EnrollementGroupes',parent);
  }
  AddEleveGroupe(elevegroupe){
    return this.api.post('/api/EleveEnrollements',elevegroupe)
  }
  GetGroupesByEleveId(eleveId:number){
    return this.api.get('/api/EnrollementGroupes/ByEleveId/'+eleveId);
  }
  Search(search){
    return this.api.post('/api/EnrollementGroupes/Search',search)
  }
  GetYears(){
    return this.api.get('/api/EnrollementGroupes/GetYears')
  }
  DeleteEleveGroupe(eleveid,groupeid){
    return this.api.delete('/api/EleveEnrollements/'+eleveid+'/'+groupeid)
  }
  GetAllClasses(){
    return this.api.get('/api/Classes')
  }
}
