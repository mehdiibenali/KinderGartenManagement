import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddConventionCtComponent } from './add-convention-ct/add-convention-ct.component';


const routes: Routes = [
  {
    path:'add',
    component:AddConventionCtComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConventionTabRoutingModule { }
