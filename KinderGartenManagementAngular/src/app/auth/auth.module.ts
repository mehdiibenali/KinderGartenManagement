import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { NbAlertModule, NbInputModule, NbButtonModule, NbCheckboxModule, NbLayoutModule, NbSelectModule, NbIconModule, NbCardModule } from '@nebular/theme';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NbAuthModule } from '@nebular/auth';
import { AuthComponent } from './auth.component';


@NgModule({
  declarations: [LoginComponent, AuthComponent],
  imports: [    
    CommonModule,
    AuthRoutingModule,
    NbAlertModule,
    FormsModule, 
    ReactiveFormsModule,   
    NbInputModule,
    RouterModule,
    NbButtonModule,
    NbCheckboxModule,
    NbLayoutModule,
    NbAuthModule,
    NbSelectModule,
    NbIconModule,
    NbCardModule
  ]
})
export class AuthModule { }
