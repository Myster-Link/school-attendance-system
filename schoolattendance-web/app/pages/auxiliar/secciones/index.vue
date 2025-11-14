<script setup>
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const secciones = [
    {
        id: 1,
        nombre: "7-1",
        grupo: "7°",
        curso: "Ciencias Informáticas",
        profesor: "María González",
        estudiantes: 30,
        ciclo: "2025",
    },
    {
        id: 2,
        nombre: "7-2",
        grupo: "7°",
        curso: "Matemáticas",
        profesor: "Pedro Ramírez",
        estudiantes: 28,
        ciclo: "2025",
    },
    {
        id: 3,
        nombre: "8-1",
        grupo: "8°",
        curso: "Español",
        profesor: "Ana Martínez",
        estudiantes: 32,
        ciclo: "2025",
    },
    {
        id: 4,
        nombre: "8-2",
        grupo: "8°",
        curso: "Estudios Sociales",
        profesor: "Luis Hernández",
        estudiantes: 29,
        ciclo: "2025",
    },
    {
        id: 5,
        nombre: "9-1",
        grupo: "9°",
        curso: "Ciencias",
        profesor: "Carlos Mora",
        estudiantes: 31,
        ciclo: "2025",
    },
    {
        id: 6,
        nombre: "9-2",
        grupo: "9°",
        curso: "Inglés",
        profesor: "Sofia Vargas",
        estudiantes: 27,
        ciclo: "2025",
    },
]

</script>

<template>
    <div class="min-h-screen bg-gradient-to-br from-slate-50 via-purple-50 to-slate-50 p-4 sm:p-6 lg:p-8">
        <div class="max-w-7xl mx-auto space-y-6 sm:space-y-8">
            
            <!-- Header con diseño moderno - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 lg:p-8">
                <div class="flex flex-col gap-4 sm:gap-6 lg:flex-row lg:items-center lg:justify-between">
                    <div class="space-y-2 sm:space-y-3">
                        <div class="flex items-center gap-3">
                            <div class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-purple-600 to-purple-700 rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                                <svg class="h-5 w-5 sm:h-6 sm:w-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4"/>
                                </svg>
                            </div>
                            <div class="min-w-0 flex-1">
                                <h1 class="text-2xl sm:text-3xl lg:text-4xl font-bold bg-gradient-to-r from-slate-900 to-purple-700 bg-clip-text text-transparent truncate">
                                    Secciones
                                </h1>
                                <p class="text-sm sm:text-base text-slate-500 mt-0.5 sm:mt-1">Gestiona las secciones y asignaciones</p>
                            </div>
                        </div>
                    </div>
                    <button
                        class="group flex items-center justify-center gap-2 px-4 sm:px-6 py-2.5 sm:py-3 bg-gradient-to-r from-purple-600 to-purple-700 text-white rounded-lg sm:rounded-xl hover:from-purple-700 hover:to-purple-800 transition-all duration-200 shadow-lg shadow-purple-500/25 hover:shadow-xl hover:shadow-purple-500/40 hover:-translate-y-0.5 w-full lg:w-auto text-sm sm:text-base font-medium">
                        <Plus class="h-4 w-4 sm:h-5 sm:w-5 group-hover:rotate-90 transition-transform duration-200" />
                        <span class="font-semibold">Crear Sección</span>
                    </button>
                </div>

                <!-- Filtros - Responsive -->
                <div class="mt-4 sm:mt-6 pt-4 sm:pt-6 border-t border-slate-100">
                    <div class="flex flex-col sm:flex-row gap-3 sm:gap-4 sm:items-end">
                        <div class="flex-1 sm:max-w-xs">
                            <label class="block text-xs sm:text-sm font-medium text-slate-700 mb-1.5 sm:mb-2">Filtrar por ciclo lectivo</label>
                            <div class="relative">
                                <select class="w-full h-10 sm:h-11 px-3 sm:px-4 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 bg-white text-sm sm:text-base text-slate-900 font-medium focus:border-purple-500 focus:ring-2 focus:ring-purple-200 transition-all appearance-none cursor-pointer hover:border-slate-300">
                                    <option value="">Todos los ciclos</option>
                                    <option value="2025">2025</option>
                                    <option value="2024">2024</option>
                                    <option value="2023">2023</option>
                                </select>
                                <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"/>
                                </svg>
                            </div>
                        </div>
                        
                        <!-- Stats rápidas -->
                        <div class="flex gap-3 sm:gap-4 overflow-x-auto pb-2 sm:pb-0 -mx-4 px-4 sm:mx-0 sm:px-0">
                            <div class="flex items-center gap-2 bg-purple-50 px-3 py-2 rounded-lg flex-shrink-0">
                                <div class="h-8 w-8 bg-purple-100 rounded-lg flex items-center justify-center">
                                    <svg class="h-4 w-4 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4"/>
                                    </svg>
                                </div>
                                <div>
                                    <p class="text-xs text-slate-500">Total</p>
                                    <p class="text-lg font-bold text-slate-900">{{ secciones.length }}</p>
                                </div>
                            </div>
                            <div class="flex items-center gap-2 bg-blue-50 px-3 py-2 rounded-lg flex-shrink-0">
                                <div class="h-8 w-8 bg-blue-100 rounded-lg flex items-center justify-center">
                                    <Users class="h-4 w-4 text-blue-600" />
                                </div>
                                <div>
                                    <p class="text-xs text-slate-500">Estudiantes</p>
                                    <p class="text-lg font-bold text-slate-900">{{ secciones.reduce((sum, s) => sum + s.estudiantes, 0) }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Secciones por Grupo - Responsive -->
            <div class="space-y-4 sm:space-y-6">
                <div v-for="grupo in ['7°', '8°', '9°']" :key="grupo" 
                    class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
                    
                    <!-- Header del grupo -->
                    <div class="bg-gradient-to-r from-purple-600 to-indigo-600 p-4 sm:p-5">
                        <div class="flex items-center justify-between gap-3">
                            <div class="flex items-center gap-3 min-w-0 flex-1">
                                <div class="h-10 w-10 sm:h-12 sm:w-12 bg-white/20 backdrop-blur rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                                    <span class="text-lg sm:text-xl font-bold text-white">{{ grupo }}</span>
                                </div>
                                <div class="min-w-0">
                                    <h2 class="text-lg sm:text-xl font-bold text-white">Grupo {{ grupo }}</h2>
                                    <p class="text-xs sm:text-sm text-purple-100">
                                        {{ secciones.filter(s => s.grupo === grupo).length }} secciones activas
                                    </p>
                                </div>
                            </div>
                            <div class="bg-white/20 backdrop-blur text-white text-xs sm:text-sm font-bold px-3 py-1.5 rounded-full flex-shrink-0">
                                {{ secciones.filter(s => s.grupo === grupo).reduce((sum, s) => sum + s.estudiantes, 0) }} alumnos
                            </div>
                        </div>
                    </div>

                    <!-- Grid de secciones -->
                    <div class="p-4 sm:p-6">
                        <div class="grid gap-4 sm:gap-6 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
                            <div v-for="seccion in secciones.filter(s => s.grupo === grupo)" :key="seccion.id"
                                class="group bg-gradient-to-br from-slate-50 to-slate-100 rounded-xl sm:rounded-2xl border-2 border-slate-200 hover:border-purple-300 hover:shadow-xl transition-all duration-300 overflow-hidden hover:-translate-y-1">
                                
                                <!-- Barra superior de color -->
                                <div class="h-1.5 sm:h-2 bg-gradient-to-r from-purple-500 via-purple-600 to-indigo-600"></div>
                                
                                <div class="p-4 sm:p-6 space-y-4">
                                    <!-- Header de la sección -->
                                    <div class="flex items-start justify-between gap-3">
                                        <div class="flex items-center gap-3 min-w-0 flex-1">
                                            <div class="h-12 w-12 sm:h-14 sm:w-14 bg-gradient-to-br from-purple-500 to-purple-600 rounded-xl sm:rounded-2xl flex items-center justify-center shadow-lg shadow-purple-500/30 group-hover:scale-110 transition-transform duration-200 flex-shrink-0">
                                                <span class="text-white font-bold text-base sm:text-lg">{{ seccion.nombre }}</span>
                                            </div>
                                            <div class="min-w-0 flex-1">
                                                <h3 class="text-base sm:text-lg font-bold text-slate-900 group-hover:text-purple-600 transition-colors truncate">
                                                    Sección {{ seccion.nombre }}
                                                </h3>
                                                <div class="flex items-center gap-1.5 mt-0.5">
                                                    <span class="text-xs sm:text-sm text-slate-500">Ciclo</span>
                                                    <span class="text-xs sm:text-sm font-bold text-purple-600 bg-purple-50 px-2 py-0.5 rounded">
                                                        {{ seccion.ciclo }}
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <button
                                            class="px-2.5 sm:px-3 py-1.5 border-2 border-slate-300 rounded-lg sm:rounded-xl text-slate-700 hover:bg-slate-50 hover:border-slate-400 transition-all text-xs sm:text-sm font-medium flex-shrink-0">
                                            Editar
                                        </button>
                                    </div>

                                    <!-- Información de la sección -->
                                    <div class="space-y-3 pt-3 border-t border-slate-200">
                                        <!-- Curso -->
                                        <div class="flex items-start gap-3">
                                            <div class="h-8 w-8 bg-blue-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                                <svg class="h-4 w-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"/>
                                                </svg>
                                            </div>
                                            <div class="min-w-0 flex-1">
                                                <p class="text-xs text-slate-500 font-medium">Curso</p>
                                                <p class="text-sm sm:text-base font-semibold text-slate-900 truncate">{{ seccion.curso }}</p>
                                            </div>
                                        </div>

                                        <!-- Profesor -->
                                        <div class="flex items-start gap-3">
                                            <div class="h-8 w-8 bg-green-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                                <UserCheck class="h-4 w-4 text-green-600" />
                                            </div>
                                            <div class="min-w-0 flex-1">
                                                <p class="text-xs text-slate-500 font-medium">Profesor</p>
                                                <p class="text-sm sm:text-base font-semibold text-slate-900 truncate">{{ seccion.profesor }}</p>
                                            </div>
                                        </div>

                                        <!-- Estudiantes -->
                                        <div class="flex items-start gap-3">
                                            <div class="h-8 w-8 bg-purple-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                                <Users class="h-4 w-4 text-purple-600" />
                                            </div>
                                            <div class="min-w-0 flex-1">
                                                <p class="text-xs text-slate-500 font-medium">Estudiantes</p>
                                                <p class="text-sm sm:text-base font-semibold text-slate-900">{{ seccion.estudiantes }} alumnos</p>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Botón de acción -->
                                    <button
                                        class="w-full flex items-center justify-center gap-2 px-4 py-2.5 sm:py-3 bg-gradient-to-r from-green-600 to-green-700 text-white rounded-lg sm:rounded-xl font-medium hover:from-green-700 hover:to-green-800 transition-all duration-200 shadow-lg shadow-green-500/25 hover:shadow-xl hover:shadow-green-500/40 text-sm sm:text-base group/btn">
                                        <Users class="h-4 w-4 group-hover/btn:scale-110 transition-transform" />
                                        <span>Ver Estudiantes</span>
                                    </button>
                                </div>
                            </div>
                        </div>

                        <!-- Empty state si no hay secciones -->
                        <div v-if="secciones.filter(s => s.grupo === grupo).length === 0" 
                            class="text-center py-12">
                            <div class="inline-flex h-16 w-16 items-center justify-center rounded-full bg-slate-100 mb-4">
                                <svg class="h-8 w-8 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 13V6a2 2 0 00-2-2H6a2 2 0 00-2 2v7m16 0v5a2 2 0 01-2 2H6a2 2 0 01-2-2v-5m16 0h-2.586a1 1 0 00-.707.293l-2.414 2.414a1 1 0 01-.707.293h-3.172a1 1 0 01-.707-.293l-2.414-2.414A1 1 0 006.586 13H4"/>
                                </svg>
                            </div>
                            <h3 class="text-lg font-semibold text-slate-900 mb-1">No hay secciones</h3>
                            <p class="text-sm text-slate-500">No se encontraron secciones para este grupo</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</template>