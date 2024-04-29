import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from '../../environments/environment'; // Adjust this path as necessary
import { AuthState, authReducer } from './auth.reducer';

// Interface for the application state
export interface State {
  auth: AuthState; // Add other state interfaces here
}

export const reducers: ActionReducerMap<State> = {
  auth: authReducer // Add other reducers here
};

// Meta-reducers are optional and used mainly for debugging purposes
export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
