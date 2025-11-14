// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2025-07-15",
  devtools: { enabled: true },
  modules: [
    "@nuxt/image",
    "@nuxt/ui",
    "@pinia/nuxt",
    "pinia-plugin-persistedstate/nuxt",
  ],
  css: ["~/assets/css/main.css"],

  runtimeConfig: {
    public: {
      NUXT_PUBLIC_API_BASE: "https://api.mysterlink.com",
      NUXT_PUBLIC_API_BASE_DEV: "https://localhost:7123",
    },
  },
});
