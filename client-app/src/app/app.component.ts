import { Component, makeEnvironmentProviders } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpInterceptorService } from './http-interceptor/http.interceptor';



@Component({
  selector: 'app-root',
  standalone: true,
  providers:[{ provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true }],
  imports: [
    RouterOutlet,
    FormsModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'client-app';
}
