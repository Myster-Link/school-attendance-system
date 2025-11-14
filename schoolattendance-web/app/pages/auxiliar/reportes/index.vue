<script setup lang="ts">
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const tipoReporte = ref < "seccion" | "estudiante" > ("seccion")
const searchEstudiante = ref("")
const selectedEstudiante = ref < { id: string; nombre: string } | null > (null)
const showSuggestions = ref(false)

const estudiantes = [
    { id: "1", nombre: "Ana María Rodríguez", seccion: "7-1" },
    { id: "2", nombre: "Carlos Jiménez Castro", seccion: "7-2" },
    { id: "3", nombre: "Diana López Mora", seccion: "8-1" },
    { id: "4", nombre: "Eduardo Vargas Soto", seccion: "8-2" },
    { id: "5", nombre: "Fernanda Pérez Gómez", seccion: "9-1" },
    { id: "6", nombre: "Gabriel Hernández López", seccion: "9-2" },
    { id: "7", nombre: "Isabella Castro Ruiz", seccion: "7-1" },
    { id: "8", nombre: "José Ramírez Mora", seccion: "7-2" },
    { id: "9", nombre: "Laura Solís Vargas", seccion: "8-1" },
    { id: "10", nombre: "Miguel Ángel Rojas", seccion: "8-2" },
]

const filteredEstudiantes = computed(() =>
    estudiantes.filter((e) =>
        e.nombre.toLowerCase().includes(searchEstudiante.value.toLowerCase())
    )
)

function handleSelectEstudiante(e: { id: string; nombre: string }) {
    selectedEstudiante.value = e
    searchEstudiante.value = e.nombre
    showSuggestions.value = false
}

const reporteData = [
    { seccion: "7-1", presente: 850, ausente: 45, tardia: 25, total: 920 },
    { seccion: "7-2", presente: 790, ausente: 52, tardia: 30, total: 872 },
    { seccion: "8-1", presente: 920, ausente: 38, tardia: 22, total: 980 },
    { seccion: "8-2", presente: 835, ausente: 48, tardia: 27, total: 910 },
    { seccion: "9-1", presente: 890, ausente: 41, tardia: 19, total: 950 },
    { seccion: "9-2", presente: 765, ausente: 55, tardia: 35, total: 855 },
]
</script>

<template>
    <div class="min-h-screen bg-gradient-to-br from-slate-50 via-indigo-50 to-slate-50 p-4 sm:p-6 lg:p-8">
        <div class="max-w-7xl mx-auto space-y-6 sm:space-y-8">

            <!-- Header con diseño moderno - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 lg:p-8">
                <div class="flex items-center gap-3">
                    <div
                        class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-indigo-600 to-violet-700 rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                        <svg class="h-5 w-5 sm:h-6 sm:w-6 text-white" fill="none" stroke="currentColor"
                            viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                        </svg>
                    </div>
                    <div class="min-w-0 flex-1">
                        <h1
                            class="text-2xl sm:text-3xl lg:text-4xl font-bold bg-gradient-to-r from-slate-900 to-indigo-700 bg-clip-text text-transparent truncate">
                            Reportes
                        </h1>
                        <p class="text-sm sm:text-base text-slate-500 mt-0.5 sm:mt-1">Consulta reportes de asistencia
                            general</p>
                    </div>
                </div>
            </div>

            <!-- Panel de Filtros - Responsive -->
            <div
                class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 space-y-4 sm:space-y-6">
                <!-- Selector de Tipo de Reporte -->
                <div>
                    <label class="block text-xs sm:text-sm font-medium text-slate-700 mb-2 sm:mb-3">Tipo de
                        Reporte</label>
                    <div class="flex flex-col xs:flex-row gap-2 sm:gap-3">
                        <button
                            class="flex-1 px-4 py-2.5 sm:py-3 rounded-lg sm:rounded-xl font-medium transition-all text-sm sm:text-base border-2"
                            :class="tipoReporte === 'seccion'
                                ? 'bg-gradient-to-r from-indigo-600 to-violet-600 text-white border-indigo-600 shadow-lg shadow-indigo-500/25'
                                : 'border-slate-300 text-slate-700 hover:bg-slate-50 hover:border-slate-400'"
                            @click="tipoReporte = 'seccion'">
                            <div class="flex items-center justify-center gap-2">
                                <svg class="h-4 w-4 sm:h-5 sm:w-5" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                </svg>
                                <span>Por Sección</span>
                            </div>
                        </button>
                        <button
                            class="flex-1 px-4 py-2.5 sm:py-3 rounded-lg sm:rounded-xl font-medium transition-all text-sm sm:text-base border-2"
                            :class="tipoReporte === 'estudiante'
                                ? 'bg-gradient-to-r from-indigo-600 to-violet-600 text-white border-indigo-600 shadow-lg shadow-indigo-500/25'
                                : 'border-slate-300 text-slate-700 hover:bg-slate-50 hover:border-slate-400'"
                            @click="tipoReporte = 'estudiante'">
                            <div class="flex items-center justify-center gap-2">
                                <svg class="h-4 w-4 sm:h-5 sm:w-5" fill="currentColor" viewBox="0 0 24 24">
                                    <path
                                        d="M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z" />
                                </svg>
                                <span>Por Estudiante</span>
                            </div>
                        </button>
                    </div>
                </div>

                <!-- Filtros dinámicos - Por Sección -->
                <div v-if="tipoReporte === 'seccion'" class="grid gap-4 grid-cols-1 sm:grid-cols-2 lg:grid-cols-4">
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Fecha Inicio
                        </label>
                        <input type="date"
                            class="w-full border-2 border-slate-200 rounded-lg sm:rounded-xl h-10 sm:h-11 px-3 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all" />
                    </div>
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Fecha Fin
                        </label>
                        <input type="date"
                            class="w-full border-2 border-slate-200 rounded-lg sm:rounded-xl h-10 sm:h-11 px-3 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all" />
                    </div>
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                            </svg>
                            Sección
                        </label>
                        <div class="relative">
                            <select
                                class="w-full h-10 sm:h-11 px-3 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all appearance-none cursor-pointer">
                                <option>Todas las secciones</option>
                                <option>7-1</option>
                                <option>7-2</option>
                                <option>8-1</option>
                                <option>8-2</option>
                                <option>9-1</option>
                                <option>9-2</option>
                            </select>
                            <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                                fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M19 9l-7 7-7-7" />
                            </svg>
                        </div>
                    </div>
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Ciclo Lectivo
                        </label>
                        <div class="relative">
                            <select
                                class="w-full h-10 sm:h-11 px-3 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all appearance-none cursor-pointer">
                                <option value="2025">Año 2025</option>
                                <option value="2024">Año 2024</option>
                                <option value="2023">Año 2023</option>
                                <option value="2022">Año 2022</option>
                            </select>
                            <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                                fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M19 9l-7 7-7-7" />
                            </svg>
                        </div>
                    </div>
                </div>

                <!-- Filtros dinámicos - Por Estudiante -->
                <div v-else class="grid gap-4 grid-cols-1 sm:grid-cols-2 lg:grid-cols-4">
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Fecha Inicio
                        </label>
                        <input type="date"
                            class="w-full border-2 border-slate-200 rounded-lg sm:rounded-xl h-10 sm:h-11 px-3 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all" />
                    </div>
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Fecha Fin
                        </label>
                        <input type="date"
                            class="w-full border-2 border-slate-200 rounded-lg sm:rounded-xl h-10 sm:h-11 px-3 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all" />
                    </div>
                    <div class="space-y-2 sm:col-span-2 lg:col-span-1 relative">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="currentColor" viewBox="0 0 24 24">
                                <path
                                    d="M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z" />
                            </svg>
                            Buscar Estudiante
                        </label>
                        <input type="text" placeholder="Escribir nombre..." v-model="searchEstudiante"
                            @focus="showSuggestions = true"
                            class="w-full border-2 border-slate-200 rounded-lg sm:rounded-xl h-10 sm:h-11 px-3 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all" />

                        <!-- Dropdown de sugerencias -->
                        <div v-if="showSuggestions && searchEstudiante"
                            class="absolute z-50 w-full mt-1 bg-white border-2 border-slate-200 rounded-xl shadow-xl max-h-64 overflow-y-auto">
                            <button v-for="e in filteredEstudiantes" :key="e.id"
                                class="w-full text-left px-4 py-3 hover:bg-indigo-50 transition-colors flex justify-between items-center border-b border-slate-100 last:border-0"
                                @click="handleSelectEstudiante(e)">
                                <div class="min-w-0 flex-1">
                                    <p class="text-sm font-semibold text-slate-900 truncate">{{ e.nombre }}</p>
                                    <p class="text-xs text-slate-500">Sección: {{ e.seccion }}</p>
                                </div>
                                <svg v-if="selectedEstudiante?.id === e.id"
                                    class="h-5 w-5 text-indigo-600 flex-shrink-0 ml-2" fill="currentColor"
                                    viewBox="0 0 24 24">
                                    <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z" />
                                </svg>
                            </button>

                            <div v-if="filteredEstudiantes.length === 0" class="px-4 py-6 text-center">
                                <svg class="h-12 w-12 text-slate-300 mx-auto mb-2" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                                </svg>
                                <p class="text-sm text-slate-500">No se encontraron estudiantes</p>
                            </div>
                        </div>

                        <p v-if="selectedEstudiante"
                            class="text-xs text-indigo-600 font-medium mt-2 flex items-center gap-1.5">
                            <svg class="h-4 w-4" fill="currentColor" viewBox="0 0 24 24">
                                <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z" />
                            </svg>
                            Seleccionado: {{ selectedEstudiante.nombre }}
                        </p>
                    </div>
                    <div class="space-y-2">
                        <label class="text-xs sm:text-sm font-medium text-slate-700 flex items-center gap-1.5">
                            <svg class="h-4 w-4 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                            </svg>
                            Ciclo Lectivo
                        </label>
                        <div class="relative">
                            <select
                                class="w-full h-10 sm:h-11 px-3 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 text-sm sm:text-base focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200 transition-all appearance-none cursor-pointer">
                                <option value="2025">Año 2025</option>
                                <option value="2024">Año 2024</option>
                                <option value="2023">Año 2023</option>
                                <option value="2022">Año 2022</option>
                            </select>
                            <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                                fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M19 9l-7 7-7-7" />
                            </svg>
                        </div>
                    </div>
                </div>

                <!-- Botones de acción -->
                <div class="flex flex-col xs:flex-row gap-2 sm:gap-3 pt-2">
                    <button
                        class="flex-1 xs:flex-initial px-4 sm:px-6 py-2.5 sm:py-3 bg-gradient-to-r from-indigo-600 to-violet-600 text-white rounded-lg sm:rounded-xl font-medium hover:from-indigo-700 hover:to-violet-700 transition-all shadow-lg shadow-indigo-500/25 hover:shadow-xl hover:shadow-indigo-500/40 text-sm sm:text-base flex items-center justify-center gap-2">
                        <svg class="h-4 w-4 sm:h-5 sm:w-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                        </svg>
                        Generar Reporte
                    </button>
                    <button
                        class="flex-1 xs:flex-initial px-4 sm:px-6 py-2.5 sm:py-3 border-2 border-slate-300 rounded-lg sm:rounded-xl font-medium hover:bg-slate-50 hover:border-slate-400 transition-all text-sm sm:text-base flex items-center justify-center gap-2 text-slate-700">
                        <svg class="h-4 w-4 sm:h-5 sm:w-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M12 10v6m0 0l-3-3m3 3l3-3m2 8H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                        </svg>
                        Exportar CSV
                    </button>
                </div>
            </div>

            <!-- Resumen - Stats Grid Responsive -->
            <div class="grid gap-4 sm:gap-6 grid-cols-2 lg:grid-cols-4">
                <div
                    class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 hover:shadow-lg transition-shadow">
                    <div class="flex items-center gap-3 mb-3">
                        <div class="h-10 w-10 bg-slate-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-5 w-5 text-slate-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2" />
                            </svg>
                        </div>
                        <p class="text-xs sm:text-sm text-slate-500 font-medium">Total Registros</p>
                    </div>
                    <p class="text-2xl sm:text-3xl font-bold text-slate-900">5,487</p>
                </div>

                <div
                    class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 hover:shadow-lg transition-shadow overflow-hidden relative">
                    <div
                        class="absolute top-0 right-0 w-24 h-24 bg-gradient-to-br from-green-500/10 to-transparent rounded-full -mr-12 -mt-12">
                    </div>
                    <div class="relative">
                        <div class="flex items-center gap-3 mb-3">
                            <div
                                class="h-10 w-10 bg-green-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                <svg class="h-5 w-5 text-green-600" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                            </div>
                            <p class="text-xs sm:text-sm text-slate-500 font-medium">Presentes</p>
                        </div>
                        <p class="text-2xl sm:text-3xl font-bold text-green-600 mb-1">5,050</p>
                        <p class="text-xs sm:text-sm text-slate-500 font-medium">92.0%</p>
                    </div>
                </div>

                <div
                    class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 hover:shadow-lg transition-shadow overflow-hidden relative">
                    <div
                        class="absolute top-0 right-0 w-24 h-24 bg-gradient-to-br from-red-500/10 to-transparent rounded-full -mr-12 -mt-12">
                    </div>
                    <div class="relative">
                        <div class="flex items-center gap-3 mb-3">
                            <div class="h-10 w-10 bg-red-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                <svg class="h-5 w-5 text-red-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                            </div>
                            <p class="text-xs sm:text-sm text-slate-500 font-medium">Ausentes</p>
                        </div>
                        <p class="text-2xl sm:text-3xl font-bold text-red-600 mb-1">279</p>
                        <p class="text-xs sm:text-sm text-slate-500 font-medium">5.1%</p>
                    </div>
                </div>

                <div
                    class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 hover:shadow-lg transition-shadow overflow-hidden relative col-span-2 lg:col-span-1">
                    <div
                        class="absolute top-0 right-0 w-24 h-24 bg-gradient-to-br from-amber-500/10 to-transparent rounded-full -mr-12 -mt-12">
                    </div>
                    <div class="relative">
                        <div class="flex items-center gap-3 mb-3">
                            <div
                                class="h-10 w-10 bg-amber-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                <svg class="h-5 w-5 text-amber-600" fill="none" stroke="currentColor"
                                    viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                            </div>
                            <p class="text-xs sm:text-sm text-slate-500 font-medium">Tardías</p>
                        </div>
                        <p class="text-2xl sm:text-3xl font-bold text-amber-600 mb-1">158</p>
                        <p class="text-xs sm:text-sm text-slate-500 font-medium">2.9%</p>
                    </div>
                </div>
            </div>

            <!-- Tabla de Reportes - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
                <!-- Header de la tabla -->
                <div class="bg-gradient-to-r from-indigo-600 to-violet-600 p-4 sm:p-6">
                    <div class="flex items-center gap-3">
                        <div
                            class="h-10 w-10 bg-white/20 backdrop-blur rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-5 w-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                            </svg>
                        </div>
                        <div>
                            <h2 class="text-xl sm:text-2xl font-bold text-white">
                                {{ tipoReporte === "seccion" ? "Reporte por Sección" : "Reporte por Estudiante" }}
                            </h2>
                            <p class="text-indigo-100 text-xs sm:text-sm">{{ reporteData.length }} registros encontrados
                            </p>
                        </div>
                    </div>
                </div>

                <!-- Vista Desktop - Tabla -->
                <div class="hidden lg:block overflow-x-auto">
                    <table class="w-full">
                        <thead>
                            <tr class="border-b-2 border-slate-200 bg-slate-50">
                                <th
                                    class="text-left py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    {{ tipoReporte === "seccion" ? "Sección" : "Estudiante" }}
                                </th>
                                <th
                                    class="text-center py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Presente
                                </th>
                                <th
                                    class="text-center py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Ausente
                                </th>
                                <th
                                    class="text-center py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Tardía
                                </th>
                                <th
                                    class="text-center py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Total
                                </th>
                                <th
                                    class="text-center py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    % Asistencia
                                </th>
                            </tr>
                        </thead>
                        <tbody class="divide-y divide-slate-200">
                            <tr v-for="r in reporteData" :key="r.seccion"
                                class="hover:bg-slate-50 transition-colors group">
                                <td class="py-4 px-6">
                                    <div class="flex items-center gap-3">
                                        <div
                                            class="h-10 w-10 bg-gradient-to-br from-indigo-500 to-violet-600 rounded-lg flex items-center justify-center">
                                            <span class="text-white font-bold text-sm">{{ r.seccion }}</span>
                                        </div>
                                        <span class="font-semibold text-slate-900">
                                            {{ tipoReporte === "seccion" ? `Sección ${r.seccion}` : r.seccion }}
                                        </span>
                                    </div>
                                </td>
                                <td class="py-4 px-6 text-center">
                                    <span
                                        class="inline-flex items-center gap-1.5 bg-green-100 text-green-700 font-bold px-3 py-1.5 rounded-lg text-sm">
                                        <svg class="h-3.5 w-3.5" fill="currentColor" viewBox="0 0 24 24">
                                            <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z" />
                                        </svg>
                                        {{ r.presente }}
                                    </span>
                                </td>
                                <td class="py-4 px-6 text-center">
                                    <span
                                        class="inline-flex items-center gap-1.5 bg-red-100 text-red-700 font-bold px-3 py-1.5 rounded-lg text-sm">
                                        <svg class="h-3.5 w-3.5" fill="currentColor" viewBox="0 0 24 24">
                                            <path
                                                d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z" />
                                        </svg>
                                        {{ r.ausente }}
                                    </span>
                                </td>
                                <td class="py-4 px-6 text-center">
                                    <span
                                        class="inline-flex items-center gap-1.5 bg-amber-100 text-amber-700 font-bold px-3 py-1.5 rounded-lg text-sm">
                                        <svg class="h-3.5 w-3.5" fill="currentColor" viewBox="0 0 24 24">
                                            <path
                                                d="M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm.5-13H11v6l5.25 3.15.75-1.23-4.5-2.67z" />
                                        </svg>
                                        {{ r.tardia }}
                                    </span>
                                </td>
                                <td class="py-4 px-6 text-center">
                                    <span class="font-bold text-slate-900 text-base">{{ r.total }}</span>
                                </td>
                                <td class="py-4 px-6 text-center">
                                    <div class="flex items-center justify-center gap-2">
                                        <div class="flex-1 max-w-[100px] h-2 bg-slate-200 rounded-full overflow-hidden">
                                            <div class="h-full rounded-full transition-all duration-500"
                                                :class="Math.round((r.presente / r.total) * 100) >= 90 ? 'bg-green-500' :
                                                    Math.round((r.presente / r.total) * 100) >= 75 ? 'bg-amber-500' : 'bg-red-500'"
                                                :style="{ width: `${Math.round((r.presente / r.total) * 100)}%` }">
                                            </div>
                                        </div>
                                        <span class="font-bold text-slate-900 text-sm min-w-[45px]">
                                            {{ Math.round((r.presente / r.total) * 100) }}%
                                        </span>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- Vista Mobile/Tablet - Cards -->
                <div class="lg:hidden p-4 sm:p-6 space-y-4">
                    <div v-for="r in reporteData" :key="r.seccion"
                        class="bg-gradient-to-br from-slate-50 to-slate-100 rounded-xl border-2 border-slate-200 p-4 hover:border-indigo-300 hover:shadow-lg transition-all duration-200">

                        <!-- Header -->
                        <div class="flex items-center justify-between mb-4">
                            <div class="flex items-center gap-3">
                                <div
                                    class="h-12 w-12 bg-gradient-to-br from-indigo-500 to-violet-600 rounded-xl flex items-center justify-center shadow-lg shadow-indigo-500/30">
                                    <span class="text-white font-bold text-base">{{ r.seccion }}</span>
                                </div>
                                <div>
                                    <h3 class="font-bold text-slate-900 text-base">
                                        {{ tipoReporte === "seccion" ? `Sección ${r.seccion}` : r.seccion }}
                                    </h3>
                                    <p class="text-xs text-slate-500">{{ r.total }} registros totales</p>
                                </div>
                            </div>
                            <div class="text-right">
                                <p class="text-2xl font-bold text-slate-900">{{ Math.round((r.presente / r.total) * 100)
                                    }}%</p>
                                <p class="text-xs text-slate-500">Asistencia</p>
                            </div>
                        </div>

                        <!-- Barra de progreso -->
                        <div class="mb-4">
                            <div class="h-3 bg-slate-200 rounded-full overflow-hidden shadow-inner">
                                <div class="h-full rounded-full transition-all duration-500" :class="Math.round((r.presente / r.total) * 100) >= 90 ? 'bg-gradient-to-r from-green-500 to-green-600' :
                                    Math.round((r.presente / r.total) * 100) >= 75 ? 'bg-gradient-to-r from-amber-500 to-amber-600' :
                                        'bg-gradient-to-r from-red-500 to-red-600'"
                                    :style="{ width: `${Math.round((r.presente / r.total) * 100)}%` }">
                                </div>
                            </div>
                        </div>

                        <!-- Stats Grid -->
                        <div class="grid grid-cols-3 gap-3">
                            <div class="bg-white rounded-lg p-3 border border-green-200">
                                <div class="flex items-center gap-1.5 mb-1">
                                    <svg class="h-3.5 w-3.5 text-green-600" fill="currentColor" viewBox="0 0 24 24">
                                        <path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z" />
                                    </svg>
                                    <p class="text-[10px] text-slate-500 font-medium uppercase">Presente</p>
                                </div>
                                <p class="text-lg font-bold text-green-600">{{ r.presente }}</p>
                            </div>
                            <div class="bg-white rounded-lg p-3 border border-red-200">
                                <div class="flex items-center gap-1.5 mb-1">
                                    <svg class="h-3.5 w-3.5 text-red-600" fill="currentColor" viewBox="0 0 24 24">
                                        <path
                                            d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z" />
                                    </svg>
                                    <p class="text-[10px] text-slate-500 font-medium uppercase">Ausente</p>
                                </div>
                                <p class="text-lg font-bold text-red-600">{{ r.ausente }}</p>
                            </div>
                            <div class="bg-white rounded-lg p-3 border border-amber-200">
                                <div class="flex items-center gap-1.5 mb-1">
                                    <svg class="h-3.5 w-3.5 text-amber-600" fill="currentColor" viewBox="0 0 24 24">
                                        <path
                                            d="M11.99 2C6.47 2 2 6.48 2 12s4.47 10 9.99 10C17.52 22 22 17.52 22 12S17.52 2 11.99 2zM12 20c-4.42 0-8-3.58-8-8s3.58-8 8-8 8 3.58 8 8-3.58 8-8 8zm.5-13H11v6l5.25 3.15.75-1.23-4.5-2.67z" />
                                    </svg>
                                    <p class="text-[10px] text-slate-500 font-medium uppercase">Tardía</p>
                                </div>
                                <p class="text-lg font-bold text-amber-600">{{ r.tardia }}</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Empty State -->
                <div v-if="reporteData.length === 0" class="p-12 text-center">
                    <div class="inline-flex h-16 w-16 items-center justify-center rounded-full bg-slate-100 mb-4">
                        <svg class="h-8 w-8 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold text-slate-900 mb-1">No hay datos disponibles</h3>
                    <p class="text-sm text-slate-500">Ajusta los filtros para ver los reportes</p>
                </div>
            </div>

        </div>
    </div>
</template>