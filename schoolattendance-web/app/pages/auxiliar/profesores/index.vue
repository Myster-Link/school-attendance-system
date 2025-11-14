<script setup>
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const profesores = [
    {
        id: 1,
        nombre: "María González Pérez",
        cedula: "1-0567-0890",
        email: "maria.gonzalez@colegio.cr",
        telefono: "8888-9999",
        cursos: ["Ciencias Informáticas", "Matemáticas"],
        secciones: 2,
        ciclo: "2025",
    },
    {
        id: 2,
        nombre: "Pedro Ramírez Castro",
        cedula: "1-0678-0901",
        email: "pedro.ramirez@colegio.cr",
        telefono: "8777-6666",
        cursos: ["Español"],
        secciones: 3,
        ciclo: "2025",
    },
    {
        id: 3,
        nombre: "Ana Martínez Luna",
        cedula: "1-0789-0123",
        email: "ana.martinez@colegio.cr",
        telefono: "8666-5555",
        cursos: ["Estudios Sociales", "Ciencias"],
        secciones: 4,
        ciclo: "2025",
    },
    {
        id: 4,
        nombre: "Luis Hernández Mora",
        cedula: "1-0890-0234",
        email: "luis.hernandez@colegio.cr",
        telefono: "8555-4444",
        cursos: ["Inglés"],
        secciones: 3,
        ciclo: "2025",
    },
    {
        id: 5,
        nombre: "Carlos Mora Valle",
        cedula: "1-0901-0345",
        email: "carlos.mora@colegio.cr",
        telefono: "8444-3333",
        cursos: ["Matemáticas"],
        secciones: 3,
        ciclo: "2025",
    },
    {
        id: 6,
        nombre: "Sofía Vargas Cruz",
        cedula: "1-0123-0456",
        email: "sofia.vargas@colegio.cr",
        telefono: "8333-2222",
        cursos: ["Ciencias Informáticas"],
        secciones: 2,
        ciclo: "2025",
    },
]

</script>

<template>
    <div class="min-h-screen bg-gradient-to-br from-slate-50 via-emerald-50 to-slate-50 p-4 sm:p-6 lg:p-8">
        <div class="max-w-7xl mx-auto space-y-6 sm:space-y-8">

            <!-- Header con diseño moderno - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 lg:p-8">
                <div class="flex flex-col gap-4 sm:gap-6 lg:flex-row lg:items-center lg:justify-between">
                    <div class="space-y-2 sm:space-y-3">
                        <div class="flex items-center gap-3">
                            <div
                                class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-emerald-600 to-teal-700 rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                                <GraduationCap class="h-5 w-5 sm:h-6 sm:w-6 text-white" />
                            </div>
                            <div class="min-w-0 flex-1">
                                <h1
                                    class="text-2xl sm:text-3xl lg:text-4xl font-bold bg-gradient-to-r from-slate-900 to-emerald-700 bg-clip-text text-transparent truncate">
                                    Profesores
                                </h1>
                                <p class="text-sm sm:text-base text-slate-500 mt-0.5 sm:mt-1">Gestiona el personal
                                    docente del colegio</p>
                            </div>
                        </div>
                    </div>
                    <button
                        class="group flex items-center justify-center gap-2 px-4 sm:px-6 py-2.5 sm:py-3 bg-gradient-to-r from-emerald-600 to-teal-700 text-white rounded-lg sm:rounded-xl hover:from-emerald-700 hover:to-teal-800 transition-all duration-200 shadow-lg shadow-emerald-500/25 hover:shadow-xl hover:shadow-emerald-500/40 hover:-translate-y-0.5 w-full lg:w-auto text-sm sm:text-base font-medium">
                        <Plus class="h-4 w-4 sm:h-5 sm:w-5 group-hover:rotate-90 transition-transform duration-200" />
                        <span class="font-semibold">Agregar Profesor</span>
                    </button>
                </div>

                <!-- Stats rápidas -->
                <div
                    class="grid grid-cols-2 sm:grid-cols-4 gap-3 sm:gap-4 mt-4 sm:mt-6 pt-4 sm:pt-6 border-t border-slate-100">
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-emerald-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <GraduationCap class="h-4 w-4 sm:h-5 sm:w-5 text-emerald-600" />
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{ profesores.length }}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Profesores</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-blue-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-blue-600" fill="none" stroke="currentColor"
                                viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{new Set(profesores.flatMap(p =>
                                p.cursos)).size }}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Cursos</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-purple-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-purple-600" fill="none" stroke="currentColor"
                                viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{profesores.reduce((sum, p) => sum
                                + p.secciones, 0) }}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Secciones</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-amber-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-amber-600" fill="none" stroke="currentColor"
                                viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">2025</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Ciclo Activo</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Filtros y Búsqueda - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6">
                <div class="flex flex-col sm:flex-row gap-3 sm:gap-4">
                    <!-- Búsqueda -->
                    <div class="relative flex-1">
                        <Search
                            class="absolute left-3 sm:left-4 top-1/2 -translate-y-1/2 h-4 w-4 sm:h-5 sm:w-5 text-slate-400 pointer-events-none" />
                        <input type="text" placeholder="Buscar por nombre o cédula..."
                            class="pl-10 sm:pl-12 pr-4 w-full h-10 sm:h-11 border-2 border-slate-200 rounded-lg sm:rounded-xl text-sm sm:text-base text-slate-900 placeholder:text-slate-400 focus:outline-none focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200 transition-all" />
                    </div>

                    <!-- Filtro por ciclo -->
                    <div class="relative sm:w-48">
                        <select
                            class="w-full h-10 sm:h-11 px-3 sm:px-4 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 bg-white text-sm sm:text-base text-slate-900 font-medium focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200 transition-all appearance-none cursor-pointer hover:border-slate-300">
                            <option value="">Todos los ciclos</option>
                            <option value="2025">2025</option>
                            <option value="2024">2024</option>
                            <option value="2023">2023</option>
                        </select>
                        <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                            fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Grid de Profesores - Responsive -->
            <div class="grid gap-4 sm:gap-6 grid-cols-1 lg:grid-cols-2">
                <div v-for="profesor in profesores" :key="profesor.id"
                    class="group bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 hover:shadow-xl hover:border-emerald-200 transition-all duration-300 overflow-hidden hover:-translate-y-1">

                    <!-- Barra superior de color -->
                    <div class="h-1.5 sm:h-2 bg-gradient-to-r from-emerald-500 via-emerald-600 to-teal-600"></div>

                    <div class="p-4 sm:p-6 space-y-4">
                        <!-- Header del profesor -->
                        <div class="flex items-start justify-between gap-3">
                            <div class="flex items-start gap-3 flex-1 min-w-0">
                                <div
                                    class="h-12 w-12 sm:h-14 sm:w-14 bg-gradient-to-br from-emerald-500 to-teal-600 rounded-xl sm:rounded-2xl flex items-center justify-center shadow-lg shadow-emerald-500/30 group-hover:scale-110 transition-transform duration-200 flex-shrink-0">
                                    <span class="text-white font-bold text-base sm:text-lg">
                                        {{profesor.nombre.split(' ').map(n => n[0]).slice(0, 2).join('')}}
                                    </span>
                                </div>
                                <div class="min-w-0 flex-1">
                                    <h3
                                        class="text-base sm:text-lg font-bold text-slate-900 group-hover:text-emerald-600 transition-colors leading-tight mb-1">
                                        {{ profesor.nombre }}
                                    </h3>
                                    <div class="flex items-center gap-1.5">
                                        <svg class="h-3.5 w-3.5 text-slate-400 flex-shrink-0" fill="none"
                                            stroke="currentColor" viewBox="0 0 24 24">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                                d="M10 6H5a2 2 0 00-2 2v9a2 2 0 002 2h14a2 2 0 002-2V8a2 2 0 00-2-2h-5m-4 0V5a2 2 0 114 0v1m-4 0a2 2 0 104 0m-5 8a2 2 0 100-4 2 2 0 000 4zm0 0c1.306 0 2.417.835 2.83 2M9 14a3.001 3.001 0 00-2.83 2M15 11h3m-3 4h2" />
                                        </svg>
                                        <span class="text-xs sm:text-sm text-slate-500 font-medium truncate">{{
                                            profesor.cedula }}</span>
                                    </div>
                                </div>
                            </div>
                            <span
                                class="bg-gradient-to-r from-slate-100 to-slate-200 text-slate-700 px-2 sm:px-3 py-1 rounded-full text-xs sm:text-sm font-semibold shadow-sm flex-shrink-0">
                                {{ profesor.ciclo }}
                            </span>
                        </div>

                        <!-- Información de contacto -->
                        <div class="space-y-3 pt-3 border-t border-slate-200">
                            <!-- Email -->
                            <div class="flex items-start gap-3">
                                <div
                                    class="h-8 w-8 bg-blue-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <Mail class="h-4 w-4 text-blue-600" />
                                </div>
                                <div class="min-w-0 flex-1">
                                    <p class="text-xs text-slate-500 font-medium mb-0.5">Email</p>
                                    <a href="#"
                                        class="text-sm sm:text-base font-medium text-slate-900 hover:text-blue-600 transition-colors truncate block">
                                        {{ profesor.email }}
                                    </a>
                                </div>
                            </div>

                            <!-- Teléfono -->
                            <div class="flex items-start gap-3">
                                <div
                                    class="h-8 w-8 bg-green-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <Phone class="h-4 w-4 text-green-600" />
                                </div>
                                <div class="min-w-0 flex-1">
                                    <p class="text-xs text-slate-500 font-medium mb-0.5">Teléfono</p>
                                    <a href="#"
                                        class="text-sm sm:text-base font-medium text-slate-900 hover:text-green-600 transition-colors">
                                        {{ profesor.telefono }}
                                    </a>
                                </div>
                            </div>

                            <!-- Cursos -->
                            <div class="flex items-start gap-3">
                                <div
                                    class="h-8 w-8 bg-purple-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <svg class="h-4 w-4 text-purple-600" fill="none" stroke="currentColor"
                                        viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                            d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253" />
                                    </svg>
                                </div>
                                <div class="min-w-0 flex-1">
                                    <p class="text-xs text-slate-500 font-medium mb-2">Cursos asignados</p>
                                    <div class="flex flex-wrap gap-2">
                                        <span v-for="(curso, idx) in profesor.cursos" :key="idx"
                                            class="inline-flex items-center px-2.5 py-1 bg-gradient-to-r from-purple-50 to-purple-100 border border-purple-200 rounded-lg text-xs sm:text-sm font-medium text-purple-700">
                                            {{ curso }}
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <!-- Secciones -->
                            <div
                                class="flex items-center justify-between bg-gradient-to-r from-emerald-50 to-teal-50 rounded-lg p-3 border border-emerald-100">
                                <div class="flex items-center gap-2">
                                    <svg class="h-4 w-4 text-emerald-600" fill="none" stroke="currentColor"
                                        viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                            d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                    </svg>
                                    <span class="text-xs sm:text-sm text-slate-600 font-medium">Secciones
                                        asignadas</span>
                                </div>
                                <span class="text-base sm:text-lg font-bold text-emerald-700">{{ profesor.secciones
                                    }}</span>
                            </div>
                        </div>

                        <!-- Botones de acción -->
                        <div class="flex flex-col xs:flex-row gap-2 sm:gap-3 pt-3 border-t border-slate-100">
                            <button
                                class="flex-1 flex items-center justify-center gap-2 px-3 sm:px-4 py-2 sm:py-2.5 border-2 border-slate-200 rounded-lg sm:rounded-xl text-slate-700 font-medium hover:bg-slate-50 hover:border-slate-300 transition-all duration-200 group/btn text-sm">
                                <svg class="h-3.5 w-3.5 sm:h-4 sm:w-4 group-hover/btn:scale-110 transition-transform flex-shrink-0"
                                    fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                                </svg>
                                <span>Ver Secciones</span>
                            </button>
                            <button
                                class="flex-1 flex items-center justify-center gap-2 px-3 sm:px-4 py-2 sm:py-2.5 bg-gradient-to-r from-green-600 to-green-700 text-white rounded-lg sm:rounded-xl font-medium hover:from-green-700 hover:to-green-800 transition-all duration-200 shadow-lg shadow-green-500/25 hover:shadow-xl hover:shadow-green-500/40 group/btn text-sm">
                                <Edit
                                    class="h-3.5 w-3.5 sm:h-4 sm:w-4 group-hover/btn:rotate-12 transition-transform flex-shrink-0" />
                                <span>Editar</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Empty State -->
            <div v-if="profesores.length === 0"
                class="bg-white rounded-2xl shadow-sm border border-slate-200 p-12 text-center">
                <div class="inline-flex h-16 w-16 items-center justify-center rounded-full bg-slate-100 mb-4">
                    <GraduationCap class="h-8 w-8 text-slate-400" />
                </div>
                <h3 class="text-lg font-semibold text-slate-900 mb-1">No hay profesores</h3>
                <p class="text-sm text-slate-500 mb-4">Comienza agregando profesores al sistema</p>
                <button
                    class="inline-flex items-center gap-2 px-6 py-3 bg-gradient-to-r from-emerald-600 to-teal-700 text-white rounded-xl font-medium hover:from-emerald-700 hover:to-teal-800 transition-all duration-200 shadow-lg shadow-emerald-500/25">
                    <Plus class="h-5 w-5" />
                    <span>Agregar Profesor</span>
                </button>
            </div>

        </div>
    </div>
</template>