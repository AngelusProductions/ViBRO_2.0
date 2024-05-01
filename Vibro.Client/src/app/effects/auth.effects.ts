import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';

import { AuthService } from '../services/auth.service';
import { login, loginSuccess, loginFailure } from '../actions/auth.actions';

@Injectable()
export class AuthEffects {
  constructor(private actions$: Actions, private authService: AuthService) { }

  login$ = createEffect(() => this.actions$.pipe(
    ofType(login),
    mergeMap((action: any) =>
      this.authService.login(action.username, action.password).pipe(
        map(response => loginSuccess({ response })),
        catchError(error => of(loginFailure({ error: error.message })))
      )
    )
  ));
}
