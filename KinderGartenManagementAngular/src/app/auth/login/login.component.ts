import { Component, OnInit } from '@angular/core';
import { NbLoginComponent, NbAuthJWTToken } from '@nebular/auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent extends NbLoginComponent implements OnInit {
  
  user = {
    username :'',
    password : '',
  };
  
  ngOnInit(): void {this.service.onTokenChange().subscribe((token: NbAuthJWTToken) => {
    //console.log('inside on init');
    if (token.isValid()) {
      //console.log('token valid');
      this.router.navigate(['']); // Your redirection goes here
    } else {
      //console.log('token not valid');
    }
  }, error => {
      this.errors = error;
     
    }
  )
  }

}
