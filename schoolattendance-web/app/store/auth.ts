import { defineStore } from "pinia";
import type { AuthResponseDto } from "~/dtos/auth/AuthResponseDto";
import type { UserDto } from "~/dtos/user/UserDto";
import { ref, onMounted } from "vue";

export const useAuthStore = defineStore(
  "authenticationStore",
  () => {
    const token = ref<string | null>(null);
    const tokenExpiration = ref<number | null>(null);
    const tokenExpirationAt = ref<number | null>(null);
    const userData = ref<UserDto | null>(null);
    const logoBase64 = ref<string | null>(null);

    // Cliente: mantener currentTime actualizado
    const currentTime = ref(Math.floor(Date.now() / 1000));
    if (import.meta.client) {
      setInterval(() => {
        currentTime.value = Math.floor(Date.now() / 1000);
      }, 1000);
    }

    const isAuthenticated = () => {
      return (
        !!token.value &&
        !!tokenExpirationAt.value &&
        currentTime.value < tokenExpirationAt.value
      );
    };

    const fillInData = (response: AuthResponseDto) => {
      token.value = response.token;
      tokenExpiration.value = response.tokenExpiration;
      userData.value = response.userData;

      const currentDate = Math.floor(Date.now() / 1000);

      if (tokenExpiration.value && !tokenExpirationAt.value && userData.value) {
        tokenExpirationAt.value = tokenExpiration.value + currentDate;
      }
    };

    const setLogo = async (logo: Blob) => {
      const logoBase64Str = await blobToBase64(logo);
      logoBase64.value = logoBase64Str;
    };

    const clearAttributes = () => {
      token.value = null;
      tokenExpiration.value = null;
      tokenExpirationAt.value = null;
      userData.value = null;
      logoBase64.value = null;
    };

    const blobToBase64 = (blob: Blob) =>
      new Promise<string>((resolve, reject) => {
        const reader = new FileReader();
        reader.onloadend = () => {
          if (reader.result) resolve((reader.result as string).split(",")[1]!);
          else reject(new Error("Error reading the Blob"));
        };
        reader.onerror = () => reject(new Error("FileReader error"));
        reader.readAsDataURL(blob);
      });

    return {
      token,
      tokenExpiration,
      tokenExpirationAt,
      userData,
      logoBase64,
      currentTime,
      isAuthenticated,
      fillInData,
      setLogo,
      clearAttributes,
      blobToBase64,
    };
  },
  { persist: true }
);
