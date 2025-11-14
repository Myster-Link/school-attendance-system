<script setup lang="ts">
import { useAuthStore } from '~/store/auth'

const route = useRoute()
const authStore = useAuthStore()
const isOpen = ref(false)

const auxiliarLinks = [
    {
        title: 'Dashboard',
        href: '/auxiliar/dashboard',
        icon: "material-symbols:dashboard-2",
    },
    {
        title: 'Cursos',
        href: '/auxiliar/cursos',
        icon: "ic:outline-list-alt",
    },
    {
        title: 'Secciones',
        href: '/auxiliar/secciones',
        icon: "sidekickicons:bars-3-bottom-center-16-solid",
    },
    {
        title: 'Estudiantes',
        href: '/auxiliar/estudiantes',
        icon: "material-symbols:person-2-outline-rounded",
    },
    {
        title: 'Profesores',
        href: '/auxiliar/profesores',
        icon: "material-symbols:person-apron",
    },
    {
        title: 'Reportes',
        href: '/auxiliar/reportes',
        icon: "line-md:document-report-twotone",
    },
]

const profesorLinks = [
    {
        title: 'Dashboard',
        href: '/profesor/dashboard',
        icon: "material-symbols:dashboard-2",
    },
    {
        title: 'Asistencia',
        href: '/profesor/asistencia',
        icon: "material-symbols-light:list-alt-check-sharp",
    },
    {
        title: 'Mis Reportes',
        href: '/profesor/reportes',
        icon: "line-md:document-report-twotone",
    },
]

const isActive = (href: string) => route.path === href

const closeMenu = () => {
    isOpen.value = false
}

const validateRoleAuxiliar = () => {
    if (authStore.userData?.roleName === 'auxiliar')
        return true

    return false
}

const returnLinks = () =>
    validateRoleAuxiliar() ? auxiliarLinks : profesorLinks;

const logout = () => {
    authStore.clearAttributes()
    return navigateTo("/");
}

</script>

<template>
    <div>
        <!-- Mobile Menu Button - Solo visible en móvil cuando el menú está cerrado -->
        <button v-show="!isOpen"
            class="fixed top-4 right-2 z-50 lg:hidden bg-white backdrop-blur-sm border-2 border-blue-300 shadow-xl rounded-xl flex items-center justify-center transition-transform duration-200 hover:bg-blue-50 hover:shadow-2xl hover:scale-105"
            style="width: 2.5rem; height: 2.5rem;" @click="isOpen = !isOpen">
            <Icon name="mage:align-left" class="h-6 w-6 text-blue-600" />
        </button>


        <!-- Overlay -->
        <div v-if="isOpen" class="fixed inset-0 bg-gray-900/50 backdrop-blur-sm z-40 lg:hidden" @click="closeMenu" />

        <!-- Sidebar -->
        <aside :class="[
            'fixed top-0 left-0 z-40 h-screen w-64 bg-white/95 backdrop-blur-md border-r border-blue-200 shadow-2xl transition-transform duration-300 ease-in-out lg:translate-x-0',
            isOpen ? 'translate-x-0' : '-translate-x-full'
        ]">
            <div class="flex flex-col h-full">
                <!-- Header -->
                <div class="p-6 border-b border-blue-100 bg-gradient-to-br from-blue-50 to-indigo-50">
                    <h2 class="text-xl font-bold text-gray-800">Sistema de Asistencia</h2>
                    <p class="text-sm text-blue-600 mt-1 font-medium">
                        {{ validateRoleAuxiliar() ? 'Panel Auxiliar' : 'Panel Profesor' }}
                    </p>
                </div>

                <!-- Navigation -->
                <nav class="flex-1 p-4 space-y-1.5 overflow-y-auto">
                    <NuxtLink v-for="link in returnLinks()" :key="link.href" :to="link.href" @click="closeMenu" :class="[
                        'flex items-center gap-3 px-4 py-3 rounded-xl transition-all duration-200',
                        isActive(link.href)
                            ? 'bg-gradient-to-r from-blue-500 to-indigo-600 text-white shadow-lg shadow-blue-500/30'
                            : 'text-gray-600 hover:bg-gradient-to-r hover:from-blue-50 hover:to-indigo-50 hover:text-blue-700 hover:shadow-sm'
                    ]">
                        <Icon :name="link.icon" class="h-5 w-5 flex-shrink-0" />

                        <span class="font-medium">{{ link.title }}</span>
                    </NuxtLink>
                </nav>

                <!-- Footer -->
                <div class="p-4 border-t border-blue-100 bg-gradient-to-br from-blue-50/50 to-indigo-50/50">
                    <button
                        class="w-full flex items-center justify-start gap-3 px-4 py-3 rounded-xl text-gray-600 hover:text-red-600 hover:bg-red-50 transition-all duration-200 hover:shadow-sm group"
                        @click="logout()">
                        <Icon name="material-symbols:lock-open-sharp" class="h-6 w-6 text-blue-600" />
                        <span class="font-medium">Cerrar Sesión</span>
                    </button>
                </div>
            </div>
        </aside>
    </div>
</template>