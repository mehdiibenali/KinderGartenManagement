import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WinterClubTabsetComponent } from './winter-club-tabset.component';


const routes: Routes = [
  {
    path:'',
    component:WinterClubTabsetComponent,
    children:[
      {
        path:'winterclub',
        loadChildren: () => import('./winter-club-tab/winter-club-tab.module').then(m=>m.WinterClubTabModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WinterClubTabsetRoutingModule { }
