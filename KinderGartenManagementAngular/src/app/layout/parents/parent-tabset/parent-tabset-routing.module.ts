import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentTabsetComponent } from './parent-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:ParentTabsetComponent,
    children:[
      {
        path:'parent',
        loadChildren: () => import('./parent-tab/parent-tab.module').then(m=>m.ParentTabModule)
      },
      {
        path:':parentid/eleves',
        loadChildren: () => import('./eleves-tab/eleves-tab.module').then(m=>m.ElevesTabModule)
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentTabsetRoutingModule { }
