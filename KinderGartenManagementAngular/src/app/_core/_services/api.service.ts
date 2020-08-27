import { Injectable } from '@angular/core';
import { NbAuthService, NbAuthJWTToken } from '@nebular/auth';
import { throwError, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  token;
  base:string='https://localhost:5001';
  constructor(
    private http: HttpClient,
    private authService: NbAuthService
  ) {
    this.authService.onTokenChange()
      .subscribe((token: NbAuthJWTToken) => {
        if (token.isValid()) {
          this.token = token.getValue();
        }
      });
  }
  private formatErrors(error: any) {
    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    let myHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': "Bearer " + this.token
    })

    return this.http.get(this.base+path, { headers: myHeaders });

  }

  put(path: string, body: any): Observable<any> {
    let myHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': "Bearer " + this.token
    })
    return this.http.put(
      this.base+path,
      body, { headers: myHeaders }
    ).pipe(catchError(this.formatErrors));
  }

  post(path: string, body): Observable<any> {
    let myHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': "Bearer " + this.token
    })
    return this.http.post(
      this.base+path,
      body, { headers: myHeaders }
    ).pipe(catchError(this.formatErrors));
  }

  delete(path): Observable<any> {
    const url=this.base+path;
    let myHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': "Bearer " + this.token
    })
    return this.http.delete(
      url, { headers: myHeaders }
    ).pipe(catchError(this.formatErrors));
  }
  
  postfile(path: string, formData){
    return this.http.post(this.base+path, formData, { reportProgress: true, observe: 'events'})
  }
}
