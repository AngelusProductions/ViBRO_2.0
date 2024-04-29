import { LoginResponseDto } from '../models/dto/login-response.dto';

export interface AuthState {
  user: LoginResponseDto | null;
  error: string | null;
}
