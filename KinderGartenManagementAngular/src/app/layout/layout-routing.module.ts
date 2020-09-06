import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { EmployeesModule } from './employees/employees.module';

const routes: Routes = [
  {
    path:'',
    component: LayoutComponent,
    children:[
      {
        path:'employees',
        loadChildren: () => import('./employees/employees.module').then(m=>m.EmployeesModule)
      },
      {
        path:'eleves',
        loadChildren: () => import('./eleves/eleves.module').then(m=>m.ElevesModule)
      },
      {
        path:'conventions',
        loadChildren: () => import('./conventions/conventions.module').then(m=>m.ConventionsModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
