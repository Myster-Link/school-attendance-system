import type { UserDto } from "../user/UserDto";

export interface AuthResponseDto {
  token: string;
  tokenExpiration: number;
  userData: UserDto;
}
