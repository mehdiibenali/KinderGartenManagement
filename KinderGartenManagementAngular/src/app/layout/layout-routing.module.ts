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
        loadChildren: () => import('./employees/employees.module').then(e=>e.EmployeesModule)
      },
      {
        path:'eleves',
        loadChildren: () => import('./eleves/eleves.module').then(e=>e.ElevesModule)
      },
      {
        path:'parents',
        loadChildren: () => import('./parents/parents.module').then(p=>p.ParentsModule)
      },
      {
        path:'conventions',
        loadChildren: () => import('./conventions/conventions.module').then(c=>c.ConventionsModule)
      },
      {
        path:'summerclubs',
        loadChildren: () => import('./summer-clubs/summer-clubs.module').then(s=>s.SummerClubsModule)
      },
      {
        path:'winterclubs',
        loadChildren: () => import('./winter-clubs/winter-clubs.module').then(c=>c.WinterClubsModule)
      },
      {
        path:'groupes',
        loadChildren: () => import('./groupes/groupes.module').then(g=>g.GroupesModule)
      },
      {
        path:'print',
        loadChildren: () => import('./print/print.module').then(p=>p.PrintModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
