import { navigateTo } from "nuxt/app";
import { useAlert } from "~/composables/common/useAlerts";
import type { AuthResponseDto } from "~/dtos/auth/AuthResponseDto";
import type { LoginDto } from "~/dtos/auth/LoginDto";
import { HttpMethod } from "~/enums/HttpMethod";
import { useAuthStore } from "~/store/auth";

const { swalError } = useAlert();

class AuthService {
  private baseURL: string;

  constructor() {
    const config = useRuntimeConfig();
    const isDev = import.meta.dev;
    this.baseURL = isDev
      ? config.public.NUXT_PUBLIC_API_BASE_DEV
      : config.public.NUXT_PUBLIC_API_BASE;
  }

  async login(loginDto: LoginDto): Promise<AuthResponseDto | null> {
    try {
      const response = await $fetch.raw(`${this.baseURL}/api/auth/login`, {
        method: HttpMethod.POST,
        server: false,
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          "X-Requested-With": "XMLHttpRequest",
        },
        credentials: "include",

        body: {
          username: loginDto.username,
          password: loginDto.password,
        },
      });

      if (response.status === 200) {
        return response._data as AuthResponseDto;
      }

      return null;
    } catch (error: any) {
      await swalError(
        "Error al iniciar sesión",
        "Usuario o contraseña incorrectos. Verifica tus credenciales e inténtalo nuevamente."
      );
      return null;
    }
  }

  async logout(): Promise<void> {
    const authStore = useAuthStore();
    authStore.clearAttributes();
    await navigateTo({ path: "/auth" });
  }
}
export default AuthService;
