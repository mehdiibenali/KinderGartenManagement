import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EleveTabsetComponent } from './eleve-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:EleveTabsetComponent,
    children:[
      {
        path:'eleve',
        loadChildren: () => import('./eleve-tab/eleve-tab.module').then(m=>m.EleveTabModule)
      },
      {
        path:':eleveid/parents',
        loadChildren: () => import('./parents-tab/parents-tab.module').then(m=>m.ParentsTabModule)
      },
      {
        path:':eleveid/groupes',
        loadChildren: () => import('./groupes-tab/groupes-tab.module').then(m=>m.GroupesTabModule)
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EleveTabsetRoutingModule { }
