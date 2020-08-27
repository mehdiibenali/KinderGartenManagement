import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Groupe } from '../_models/groupe';

@Injectable({
  providedIn: 'root'
})
export class GroupeService {

  constructor( private api : ApiService) { }
  GetById(id:number){
    return this.api.get('/api/Groupes/'+id);
  };
  AddGroupe(groupe:Groupe){
    return this.api.post('/api/Groupes',parent);
  }
  AddEleveGroupe(elevegroupe){
    return this.api.post('/api/EleveGroupes',elevegroupe)
  }
  GetGroupesByEleveId(eleveId:number){
    return this.api.get('/api/Groupes/ByEleveId/'+eleveId);
  }
}
