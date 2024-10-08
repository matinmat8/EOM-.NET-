import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.url.includes('/song/add') && req.method === 'POST') {
      const clonedRequest = req.clone({
        headers: req.headers.delete('Content-Type')
      });
      return next.handle(clonedRequest);
    }
    const modifiedReq = req.clone({
      headers: req.headers
        .set('Content-Type', 'application/json')
        .set('Access-Control-Allow-Origin', '*')
    });
    return next.handle(modifiedReq);
  }
}
