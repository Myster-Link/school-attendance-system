<script setup lang="ts">
import { useLogin } from '~/composables/auth/useLogin';
import { useAuthStore } from '~/store/auth';

definePageMeta({
    requiredAuth: false,
    layout: false,
})

const authStore = useAuthStore();

const {
    request,
    handleLogin,
} = useLogin()
</script>

<template>
    <div
        class="min-h-screen bg-gradient-to-br from-sky-50 via-blue-50 to-indigo-50 flex items-center justify-center p-4 relative">
        <div class="absolute bottom-6 right-6">
            <a href="https://mysterlink.com" target="_blank" rel="noopener noreferrer"
                class="inline-flex items-center gap-2 bg-white/90 backdrop-blur-md px-4 py-2 rounded-full shadow-lg border border-slate-200/50 hover:shadow-xl hover:scale-105 transition-all duration-300 group">
                <div class="w-2 h-2 bg-gradient-to-r from-blue-500 to-indigo-500 rounded-full animate-pulse" />
                <span
                    class="text-xs font-bold text-slate-700 tracking-wide group-hover:text-blue-600 transition-colors">
                    MYSTERLINK SYSTEMS
                </span>
                <svg class="w-3 h-3 text-slate-400 group-hover:text-blue-600 group-hover:translate-x-0.5 transition-all"
                    fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                </svg>
            </a>
        </div>

        <!-- Contenedor del login -->
        <div class="w-full max-w-md">
            <div class="bg-white/80 backdrop-blur-sm rounded-2xl shadow-2xl p-8 md:p-10 border border-white/20">
                <div class="text-center mb-8">
                    <div
                        class="inline-flex items-center justify-center w-24 h-24 bg-gradient-to-br from-blue-500 to-indigo-600 rounded-2xl mb-4 shadow-lg">
                        <svg class="w-12 h-12 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253" />
                        </svg>
                    </div>
                    <h1 class="text-3xl font-bold text-slate-800 mb-2">Sistema de Asistencia</h1>
                    <p class="text-slate-500 text-sm">Ingresa tus credenciales para continuar</p>
                </div>

                <!-- Formulario -->
                <form class="space-y-6" @submit.prevent="handleLogin">
                    <!-- Campo Usuario -->
                    <div>
                        <label for="username" class="block text-sm font-semibold text-slate-700 mb-2">
                            Usuario
                        </label>
                        <div class="relative">
                            <div class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                                <svg class="h-5 w-5 text-pink-900" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                                </svg>
                            </div>
                            <input type="text" id="username"
                                class="block w-full pl-10 pr-3 py-3 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent bg-white/50 backdrop-blur-sm text-slate-900 placeholder-slate-400 transition-all"
                                placeholder="Ingresa tu usuario" v-model="request.username" />
                        </div>
                    </div>

                    <!-- Campo Contraseña -->
                    <div>
                        <label for="password" class="block text-sm font-semibold text-slate-700 mb-2">
                            Contraseña
                        </label>
                        <div class="relative">
                            <div class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                                <svg class="h-5 w-5 text-pink-900" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                                </svg>
                            </div>
                            <input type="password" id="password"
                                class="block w-full pl-10 pr-3 py-3 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent bg-white/50 backdrop-blur-sm text-slate-900 placeholder-slate-400 transition-all"
                                placeholder="Ingresa tu contraseña" v-model="request.password" />
                        </div>
                    </div>

                    <!-- Botón de Login -->
                    <button type="submit"
                        class="w-full bg-gradient-to-r from-blue-600 to-indigo-600 text-white font-semibold py-3 px-4 rounded-lg hover:from-blue-700 hover:to-indigo-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transform transition-all hover:scale-[1.02] active:scale-[0.98] shadow-lg">
                        Iniciar Sesión
                    </button>

                    <!-- Link adicional -->
                    <div class="text-center">
                        <a href="#" class="text-sm text-blue-600 hover:text-blue-700 font-medium transition-colors">
                            ¿Olvidaste tu contraseña?
                        </a>
                    </div>
                </form>
            </div>

            <!-- Pie de página -->
            <div class="text-center mt-6">
                <p class="text-slate-500 text-sm">© 2025 Mysterlink Systems. Todos los derechos reservados.</p>
            </div>
        </div>
    </div>
</template>

<style scoped></style>