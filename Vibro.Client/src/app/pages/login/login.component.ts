import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';

import { AuthService } from '../../services/auth.service';
import { login } from '../../actions/auth.actions';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private store: Store) { }

  onSubmit() {
    this.store.dispatch(login({ username: this.username, password: this.password }));
  }
}
