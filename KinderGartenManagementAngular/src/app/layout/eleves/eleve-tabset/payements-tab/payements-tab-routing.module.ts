import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPayementTeComponent } from './add-payement-te/add-payement-te.component';
import { EditPayementTeComponent } from './edit-payement-te/edit-payement-te.component';
import { PayementsListComponent } from './payements-list/payements-list.component';


const routes: Routes = [
  {
    path:"list",
    component:PayementsListComponent
  },
  {
    path:"add",
    component:AddPayementTeComponent
  },
  {
    path:":payementid",
    component:EditPayementTeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PayementsTabRoutingModule { }
