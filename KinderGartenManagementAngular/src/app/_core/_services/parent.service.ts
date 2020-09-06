import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Parent } from '../_models/parent';

@Injectable({
  providedIn: 'root'
})
export class ParentService {

  constructor(
    private api : ApiService,
  ) { }
  GetById(id:number){
    return this.api.get('/api/Parents/'+id);
  };
  AddParent(parent:Parent){
    return this.api.post('/api/Parents',parent);
  }
  AddEleveParent(eleveparent){
    return this.api.post('/api/EleveParents',eleveparent)
  }
  GetParentByEleveId(eleveId:number){
    return this.api.get('/api/Parents/ByEleveId/'+eleveId);
  }
  UpdateParent(parent,id){
    return this.api.put('/api/Parents/'+id,parent)
  }
  SearchByName(parentsearch){
    return this.api.get('/api/Parents/SearchByName/'+parentsearch)
  }
  GetEleveParentByParentTuter(eleveid){
    return this.api.get('/api/EleveParents/GetByParentTuteur/'+eleveid)
  }
  UpdateEleveParent(eleveid,parentid){
    return this.api.put('/api/EleveParents/'+eleveid+'/'+parentid,null)
  }
  DeleteEleveParent(eleveid,parentid){
    return this.api.delete('/api/EleveParents/'+eleveid+'/'+parentid)
  }
  AddParentConvention(addparentconvention){
    return this.api.post('/api/ParentConventions',addparentconvention)
  }
  DisableParentConvention(parentid){
    return this.api.put('/api/ParentConventions/DisableConventionActive/'+parentid,null)
  }
  UpdateParentConvention(parentconvention){
    return this.api.put('/api/ParentConventions',parentconvention)
  }
}
