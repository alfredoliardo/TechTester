import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TechContextService } from '../_services/tech-context.service';

@Injectable()
export class TechContextInterceptor implements HttpInterceptor {

  constructor(private tc:TechContextService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var request = request.clone({
      setHeaders:{
        TechContext:this.tc.getTechContext().workstationName
      }
    });
    return next.handle(request);
  }
}
