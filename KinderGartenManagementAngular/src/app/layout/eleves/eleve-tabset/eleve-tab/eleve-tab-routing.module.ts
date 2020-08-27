import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddEleveComponent } from './add-eleve/add-eleve.component';
import { EditEleveComponent } from './edit-eleve/edit-eleve.component';


const routes: Routes = [
  {
    path:"add",
    component:AddEleveComponent,
  },
  {
    path:":eleveid",
    component:EditEleveComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EleveTabRoutingModule { }
