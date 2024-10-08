import { Injectable } from '@angular/core';
import { AuthServiceClient } from './proto/auth_pb_service';
import { Observable } from 'rxjs';
import { LoginRequest, SignUpRequest } from './proto/auth_pb';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode'


@Injectable({
  providedIn: 'root'
})


export class AuthService {
  private client: AuthServiceClient;

  constructor(private router: Router) {
    this.client = new AuthServiceClient('http://127.0.0.1:5002');
  }


  login(credentials: { username: string, password: string }): Observable<any> {
    const request = new LoginRequest();
    request.setUsername(credentials.username);
    request.setPassword(credentials.password);

    return new Observable(observer => {
      this.client.login(request, (error: any, response) => {
        if (error) {
          observer.error(error);
        } else {
          observer.next(response)
          observer.complete()
        }
        },)
      });
    };


  signUp(credentials: { Username: string, Password: string, Email: string}): Observable<any> {
    const request = new SignUpRequest();
    request.setUsername(credentials.Username);
    request.setEmail(credentials.Email);
    request.setPassword(credentials.Password);


    console.log('Sending sign up request with:', credentials);

    return new Observable(observer => {
      this.client.signUp(request, (error: any, response) => {
        if (error) {
          observer.error(error);
        } else {
          observer.next(response)
          observer.complete()
        }
      })
    })
  }

  logOut() {
    try{
      localStorage.removeItem('token');
      this.router.navigate(['/login']);
    }catch(e) {
      console.log(e);
    }

  }

  getUsername(): string | null {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken: any = jwtDecode(token);
      return decodedToken.sub;
    }
    return null;
  }

  isAuthenticated() {
      const token = localStorage.getItem('token');
      return token;
  }
}
