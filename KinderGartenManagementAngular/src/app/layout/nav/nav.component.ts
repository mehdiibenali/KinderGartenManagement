import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NbAuthService, NbAuthJWTToken } from '@nebular/auth';
import { Payload } from 'src/app/_core/_models/payload';
import { NbMenuService } from '@nebular/theme';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  user : Payload;
  items = [
    { title: 'Profile' },
    { title: 'Logout' },
  ];
  constructor(
    private authService: NbAuthService,
    private router: Router,
    private nbMenuService: NbMenuService) {
    this.authService.onTokenChange()
    .subscribe((token: NbAuthJWTToken) => {
      if (token.isValid()) {
        this.user = token.getPayload();
      }
    });
   }

  ngOnInit(): void {
    this.nbMenuService.onItemClick()
      .pipe(
        filter(({ tag }) => tag === 'my-context-menu'),
        map(({ item: { title } }) => title),
      )
      .subscribe(title => {
        if (title === 'Logout') {
          localStorage.removeItem('auth_token');
          localStorage.clear();
          this.router.navigate(['auth/login']);
        }
        // if (title === 'Profile') {
        //   this.dialogService.open(ProfileComponent);
        // }
      });
  }
}
