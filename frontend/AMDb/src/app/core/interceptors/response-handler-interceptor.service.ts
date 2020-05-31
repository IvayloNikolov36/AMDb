import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ResponseHandlerInterceptorService implements HttpInterceptor {

  constructor(public toastr: ToastrService, private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // tslint:disable-next-line: no-angle-bracket-type-assertion
    return <any> next.handle(req).pipe(tap((success) => {

      if (success instanceof HttpResponse) {
        if (success.url.endsWith('login') || success.url.includes('register')
        || success.url.includes('create') || success.url.includes('delete')
        || success.url.includes('edit')) {
          this.toastr.success(success.body.message, 'Success');
        }
      }
    }), catchError((err) => {

      console.log('Error from interceptor: ' + err.title);

      let errMsg = err.error.error;
      if (errMsg) {
        const arrMsgs = err.error.errors.description;
        if (!arrMsgs) {
          errMsg = arrMsgs.join(' ');
        }
      }
      this.toastr.error(errMsg, 'Error');
      this.router.navigate(['/home']);
      throw err;
    })) as any;
  }
}
