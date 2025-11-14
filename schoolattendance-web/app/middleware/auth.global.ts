import { useAuthStore } from "~/store/auth";

export default defineNuxtRouteMiddleware((to) => {
  const authStore = useAuthStore();
  const isAuthenticated = authStore.isAuthenticated();

  const roleName = authStore.userData?.roleName;

  // Rutas que requieren autenticación
  if (to.meta.requiredAuth && !isAuthenticated) {
    authStore.clearAttributes();
    return navigateTo("/");
  }

  // Redirección desde "/" si está autenticado
  if (to.path === "/" && isAuthenticated) {
    const dashboard =
      roleName === "auxiliar" ? "/auxiliar/dashboard" : "/profesor/dashboard";
    return navigateTo(dashboard);
  }

  // Validación por roles
  const allowedRoles = to.meta.allowedRoles as string[] | undefined;
  if (
    allowedRoles &&
    isAuthenticated &&
    !allowedRoles.includes(roleName || "")
  ) {
    return navigateTo("/"); // o "/unauthorized"
  }

  // Rutas de invitados
  if (to.meta.guest && isAuthenticated) {
    const dashboard =
      roleName === "auxiliar" ? "/auxiliar/dashboard" : "/profesor/dashboard";
    return navigateTo(dashboard);
  }
});
