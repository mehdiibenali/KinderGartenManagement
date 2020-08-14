import { Component } from '@angular/core';
import { NbAuthComponent } from '@nebular/auth';

@Component({
  selector: 'auth-component',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent extends NbAuthComponent{
}
