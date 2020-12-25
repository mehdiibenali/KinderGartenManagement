import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddGroupeGtComponent } from './add-groupe-gt/add-groupe-gt.component';


const routes: Routes = [
  {
    path:'add',
    component:AddGroupeGtComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupeTabRoutingModule { }
