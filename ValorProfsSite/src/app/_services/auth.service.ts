import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl =  environment.apiUrl + 'users';
  userToken: any;
  decodedToken: any;
  jwtHelper: JwtHelperService = new JwtHelperService();
  constructor(private http: HttpClient) {}

  login(model: any) {
      const resp = this.http
      .post(this.baseUrl + '/login', model, {responseType: 'text'});
      return resp
      .pipe(
        map((response: any) => {
          const token = response;
          if (token) {
            localStorage.setItem('token', token);
            this.decodedToken = this.jwtHelper.decodeToken(token);
            console.log(this.decodedToken);
            this.userToken = token;
          }
        })
      );
  }
  register(model: any) {
    return this.http
      .post(this.baseUrl , model, httpOptions);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
