import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SummerClubTabsetComponent } from './summer-club-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:SummerClubTabsetComponent,
    children:[
      {
        path:'summerclub',
        loadChildren: () => import('./summer-club-tab/summer-club-tab.module').then(m=>m.SummerClubTabModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SummerClubTabsetRoutingModule { }
