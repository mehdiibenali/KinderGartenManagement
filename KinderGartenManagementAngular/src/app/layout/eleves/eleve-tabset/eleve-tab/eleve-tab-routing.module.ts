import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditEleveTeComponent } from './edit-eleve-te/edit-eleve-te.component';
import { AddEleveTeComponent } from './add-eleve-te/add-eleve-te.component';


const routes: Routes = [
  {
    path:"add",
    component:AddEleveTeComponent,
  },
  {
    path:":eleveid",
    component:EditEleveTeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EleveTabRoutingModule { }
