import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddSummerClubSctComponent } from './add-summer-club-sct/add-summer-club-sct.component';


const routes: Routes = [
  {
    path:'add',
    component:AddSummerClubSctComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SummerClubTabRoutingModule { }
