import { createReducer, on } from '@ngrx/store';
import { login, loginSuccess, loginFailure } from '../actions/auth.actions';

export const initialState = {
  user: null,
  error: null
};

export const authReducer = createReducer(
  initialState,
  on(loginSuccess, (state, { response }) => ({ ...state, token: response })),
  on(loginFailure, (state, { error }) => ({ ...state, error }))
);
