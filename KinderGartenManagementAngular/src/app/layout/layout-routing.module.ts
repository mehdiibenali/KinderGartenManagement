import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { EmployeesModule } from './employees/employees.module';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path:'',
    component: LayoutComponent,
    children:[
      {
        path:'',
        component:HomeComponent
      },
      {
        path:'employees',
        loadChildren: () => import('./employees/employees.module').then(m=>m.EmployeesModule)
      },
      {
        path:'eleves',
        loadChildren: () => import('./eleves/eleves.module').then(m=>m.ElevesModule)
      },
      {
        path:'parents',
        loadChildren: () => import('./parents/parents.module').then(m=>m.ParentsModule)
      },
      {
        path:'conventions',
        loadChildren: () => import('./conventions/conventions.module').then(m=>m.ConventionsModule)
      },
      {
        path:'summerclubs',
        loadChildren: () => import('./summer-clubs/summer-clubs.module').then(m=>m.SummerClubsModule)
      },
      {
        path:'winterclubs',
        loadChildren: () => import('./winter-clubs/winter-clubs.module').then(m=>m.WinterClubsModule)
      },
      {
        path:'groupes',
        loadChildren: () => import('./groupes/groupes.module').then(m=>m.GroupesModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
