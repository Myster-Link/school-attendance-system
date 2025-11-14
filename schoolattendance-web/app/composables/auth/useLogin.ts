import { reactive } from "vue";
import type { AuthResponseDto } from "~/dtos/auth/AuthResponseDto";
import type { LoginDto } from "~/dtos/auth/LoginDto";
import AuthService from "~/services/AuthService";
import { useAuthStore } from "~/store/auth";

export const useLogin = () => {
  const authService = new AuthService();
  const authStore = useAuthStore();

  const request = reactive<LoginDto>({
    username: "",
    password: "",
  });

  const handleLogin = async () => {
    if (validateInputs()) {
      const response = await authService.login(request);

      if (response !== null) {
        const authResponse = response as AuthResponseDto;
        authStore.fillInData(authResponse);

        return navigateTo(
          authStore.userData?.roleName === "auxiliar"
            ? "/auxiliar/dashboard"
            : "/profesor/dashboard"
        );
      }
    } else {
      request.password = "";
    }
  };

  const validateInputs = () => {
    return request.username.trim() !== "" && request.password.trim() !== "";
  };

  const requiredRule = (v: string | boolean) => !!v || "Campo obligatorio";

  return {
    request,
    handleLogin, 
    validateInputs,
    requiredRule,
  };
};
