import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth-guard.service';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard], 
    loadChildren: () => import('./layout/layout.module').then(m=>m.LayoutModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m=>m.AuthModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
