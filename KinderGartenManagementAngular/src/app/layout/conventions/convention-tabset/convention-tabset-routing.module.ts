import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConventionTabsetComponent } from './convention-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:ConventionTabsetComponent,
    children:[
      {
        path:'convention',
        loadChildren: () => import('./convention-tab/convention-tab.module').then(m=>m.ConventionTabModule)
      },
      {
        path:':conventionid/parents',
        loadChildren: () => import('./parents-tab/parents-tab.module').then(m=>m.ParentsTabModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConventionTabsetRoutingModule { }
