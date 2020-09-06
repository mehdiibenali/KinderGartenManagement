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
  SearchByName(groupesearch){
    return this.api.get('/api/Groupes/SearchByName/'+groupesearch)
  }
  SearchByYear(anneededebut,anneedefin){
    return this.api.get('/api/Groupes/SearchByYear/'+anneededebut+'/'+anneedefin)
  }
  GetYears(eleveid){
    return this.api.get('/api/Groupes/GetYears/'+eleveid)
  }
  DeleteEleveGroupe(eleveid,groupeid){
    return this.api.delete('/api/EleveGroupes/'+eleveid+'/'+groupeid)
  }
}
