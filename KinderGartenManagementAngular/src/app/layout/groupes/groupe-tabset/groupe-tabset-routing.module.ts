import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupeTabsetComponent } from './groupe-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:GroupeTabsetComponent,
    children:[
      {
        path:'groupe',
        loadChildren: () => import('./groupe-tab/groupe-tab.module').then(m=>m.GroupeTabModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupeTabsetRoutingModule { }
