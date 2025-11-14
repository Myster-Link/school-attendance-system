<script setup>
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const estudiantes = [
    {
        id: 1,
        nombre: "Ana María Rodríguez",
        cedula: "1-0234-0567",
        seccion: "7-1",
        activo: true,
    },
    {
        id: 2,
        nombre: "Carlos Jiménez Castro",
        cedula: "1-0345-0678",
        seccion: "7-1",
        activo: true,
    },
    {
        id: 3,
        nombre: "María Fernanda López",
        cedula: "1-0456-0789",
        seccion: "8-2",
        activo: true,
    },
    {
        id: 4,
        nombre: "José Miguel Mora",
        cedula: "1-0567-0890",
        seccion: "9-1",
        activo: true,
    },
    {
        id: 5,
        nombre: "Laura Sofía Vargas",
        cedula: "1-0678-0901",
        seccion: "7-2",
        activo: false,
    },
]

</script>

<template>
    <div class="min-h-screen bg-gradient-to-br from-slate-50 via-cyan-50 to-slate-50 p-4 sm:p-6 lg:p-8">
        <div class="max-w-7xl mx-auto space-y-6 sm:space-y-8">

            <!-- Header con diseño moderno - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 lg:p-8">
                <div class="flex flex-col gap-4 sm:gap-6 lg:flex-row lg:items-center lg:justify-between">
                    <div class="space-y-2 sm:space-y-3">
                        <div class="flex items-center gap-3">
                            <div
                                class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-cyan-600 to-blue-700 rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                                <svg class="h-5 w-5 sm:h-6 sm:w-6 text-white" fill="currentColor" viewBox="0 0 24 24">
                                    <path
                                        d="M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z" />
                                </svg>
                            </div>
                            <div class="min-w-0 flex-1">
                                <h1
                                    class="text-2xl sm:text-3xl lg:text-4xl font-bold bg-gradient-to-r from-slate-900 to-cyan-700 bg-clip-text text-transparent truncate">
                                    Estudiantes
                                </h1>
                                <p class="text-sm sm:text-base text-slate-500 mt-0.5 sm:mt-1">Gestiona los estudiantes
                                    del colegio</p>
                            </div>
                        </div>
                    </div>
                    <button
                        class="group flex items-center justify-center gap-2 px-4 sm:px-6 py-2.5 sm:py-3 bg-gradient-to-r from-cyan-600 to-blue-700 text-white rounded-lg sm:rounded-xl hover:from-cyan-700 hover:to-blue-800 transition-all duration-200 shadow-lg shadow-cyan-500/25 hover:shadow-xl hover:shadow-cyan-500/40 hover:-translate-y-0.5 w-full lg:w-auto text-sm sm:text-base font-medium">
                       <Icon name="material-symbols:add-2" class="font-semibold"/>
                        <span class="font-semibold">Agregar Estudiante</span>
                    </button>
                </div>

                <!-- Stats rápidas -->
                <div
                    class="grid grid-cols-2 sm:grid-cols-4 gap-3 sm:gap-4 mt-4 sm:mt-6 pt-4 sm:pt-6 border-t border-slate-100">
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-cyan-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-cyan-600" fill="currentColor" viewBox="0 0 24 24">
                                <path
                                    d="M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{ estudiantes.length }}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Total</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-green-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-green-600" fill="none" stroke="currentColor"
                                viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{estudiantes.filter(e =>
                                e.activo).length}}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Activos</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
                        <div
                            class="h-8 w-8 sm:h-10 sm:w-10 bg-slate-100 rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-4 w-4 sm:h-5 sm:w-5 text-slate-600" fill="none" stroke="currentColor"
                                viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M18.364 18.364A9 9 0 005.636 5.636m12.728 12.728A9 9 0 015.636 5.636m12.728 12.728L5.636 5.636" />
                            </svg>
                        </div>
                        <div class="min-w-0">
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{estudiantes.filter(e =>
                                !e.activo).length}}</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Inactivos</p>
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
                            <p class="text-xl sm:text-2xl font-bold text-slate-900">6</p>
                            <p class="text-xs sm:text-sm text-slate-500 truncate">Secciones</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Filtros y Búsqueda - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6">
                <div class="grid gap-3 sm:gap-4 grid-cols-1 sm:grid-cols-2 lg:grid-cols-4">
                    <!-- Búsqueda -->
                    <div class="relative sm:col-span-2">
                        <Search
                            class="absolute left-3 sm:left-4 top-1/2 -translate-y-1/2 h-4 w-4 sm:h-5 sm:w-5 text-slate-400 pointer-events-none" />
                        <input type="text" placeholder="Buscar por nombre o cédula..."
                            class="pl-10 sm:pl-12 pr-4 w-full h-10 sm:h-11 border-2 border-slate-200 rounded-lg sm:rounded-xl text-sm sm:text-base text-slate-900 placeholder:text-slate-400 focus:outline-none focus:border-cyan-500 focus:ring-2 focus:ring-cyan-200 transition-all" />
                    </div>

                    <!-- Filtro por sección -->
                    <div class="relative">
                        <select
                            class="w-full h-10 sm:h-11 px-3 sm:px-4 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 bg-white text-sm sm:text-base text-slate-900 font-medium focus:border-cyan-500 focus:ring-2 focus:ring-cyan-200 transition-all appearance-none cursor-pointer hover:border-slate-300">
                            <option value="">Todas las secciones</option>
                            <option value="7-1">Sección 7-1</option>
                            <option value="7-2">Sección 7-2</option>
                            <option value="8-1">Sección 8-1</option>
                            <option value="8-2">Sección 8-2</option>
                            <option value="9-1">Sección 9-1</option>
                            <option value="9-2">Sección 9-2</option>
                        </select>
                        <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                            fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </div>

                    <!-- Filtro por año -->
                    <div class="relative">
                        <select
                            class="w-full h-10 sm:h-11 px-3 sm:px-4 pr-10 rounded-lg sm:rounded-xl border-2 border-slate-200 bg-white text-sm sm:text-base text-slate-900 font-medium focus:border-cyan-500 focus:ring-2 focus:ring-cyan-200 transition-all appearance-none cursor-pointer hover:border-slate-300">
                            <option value="2025">Año 2025</option>
                            <option value="2024">Año 2024</option>
                            <option value="2023">Año 2023</option>
                            <option value="2022">Año 2022</option>
                        </select>
                        <svg class="absolute right-3 top-1/2 -translate-y-1/2 h-5 w-5 text-slate-400 pointer-events-none"
                            fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Tabla de Estudiantes - Responsive -->
            <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
                <!-- Header de tabla -->
                <div class="bg-gradient-to-r from-cyan-600 to-blue-600 p-4 sm:p-6">
                    <div class="flex items-center gap-3">
                        <div
                            class="h-10 w-10 bg-white/20 backdrop-blur rounded-lg flex items-center justify-center flex-shrink-0">
                            <svg class="h-5 w-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                    d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2m-3 7h3m-3 4h3m-6-4h.01M9 16h.01" />
                            </svg>
                        </div>
                        <div>
                            <h2 class="text-xl sm:text-2xl font-bold text-white">Lista de Estudiantes</h2>
                            <p class="text-cyan-100 text-xs sm:text-sm">{{ estudiantes.length }} estudiantes registrados
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
                                    Nombre</th>
                                <th
                                    class="text-left py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Cédula</th>
                                <th
                                    class="text-left py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Sección</th>
                                <th
                                    class="text-left py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Estado</th>
                                <th
                                    class="text-right py-4 px-6 font-semibold text-sm text-slate-600 uppercase tracking-wide">
                                    Acciones</th>
                            </tr>
                        </thead>
                        <tbody class="divide-y divide-slate-200">
                            <tr v-for="estudiante in estudiantes" :key="estudiante.id"
                                class="hover:bg-slate-50 transition-colors group">
                                <td class="py-4 px-6">
                                    <div class="flex items-center gap-3">
                                        <div
                                            class="h-10 w-10 bg-gradient-to-br from-cyan-500 to-blue-600 rounded-full flex items-center justify-center flex-shrink-0">
                                            <span class="text-white font-bold text-base sm:text-lg">
                                                {{
                                                    estudiante.nombre
                                                        .split(' ')
                                                        .map(n => n[0])
                                                        .slice(0, 2)
                                                        .join('')
                                                        .toUpperCase()
                                                }}
                                            </span>
                                        </div>
                                        <span
                                            class="font-semibold text-slate-900 group-hover:text-cyan-600 transition-colors">{{
                                                estudiante.nombre }}</span>
                                    </div>
                                </td>
                                <td class="py-4 px-6">
                                    <span class="text-slate-600 font-medium">{{ estudiante.cedula }}</span>
                                </td>
                                <td class="py-4 px-6">
                                    <span
                                        class="inline-flex items-center gap-1.5 bg-purple-100 text-purple-700 text-sm font-semibold px-3 py-1.5 rounded-lg">
                                        <svg class="h-3.5 w-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                                d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                        </svg>
                                        {{ estudiante.seccion }}
                                    </span>
                                </td>
                                <td class="py-4 px-6">
                                    <span
                                        class="inline-flex items-center gap-1.5 px-3 py-1.5 rounded-lg text-sm font-semibold"
                                        :class="estudiante.activo
                                            ? 'bg-green-100 text-green-700'
                                            : 'bg-slate-200 text-slate-700'">
                                        <span class="h-2 w-2 rounded-full"
                                            :class="estudiante.activo ? 'bg-green-500' : 'bg-slate-500'"></span>
                                        {{ estudiante.activo ? 'Activo' : 'Inactivo' }}
                                    </span>
                                </td>
                                <td class="py-4 ">
                                    <div class="flex items-center justify-center gap-4">
                                        <button
                                            class="flex items-center justify-center p-3 rounded-lg hover:bg-cyan-100 transition-colors group"
                                            title="Editar">
                                            <Icon name="material-symbols:edit-sharp"
                                                class="h-6 w-6 text-slate-600 group-hover:text-cyan-600" />
                                        </button>
                                        <button
                                            class="flex items-center justify-center p-3 rounded-lg hover:bg-red-100 transition-colors group"
                                            title="Eliminar">
                                            <Icon name="material-symbols:delete-rounded"
                                                class="h-6 w-6 text-slate-600 group-hover:text-red-600" />
                                        </button>
                                    </div>
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- Vista Mobile/Tablet - Cards -->
                <div class="lg:hidden p-4 sm:p-6 space-y-4">
                    <div v-for="estudiante in estudiantes" :key="estudiante.id"
                        class="bg-gradient-to-br from-slate-50 to-slate-100 rounded-xl border-2 border-slate-200 p-4 sm:p-5 hover:border-cyan-300 hover:shadow-lg transition-all duration-200">

                        <!-- Header de la card -->
                        <div class="flex items-start justify-between gap-3 mb-4">
                            <div class="flex items-center gap-3 min-w-0 flex-1">
                                <div
                                    class="h-12 w-12 sm:h-14 sm:w-14 bg-gradient-to-br from-cyan-500 to-blue-600 rounded-full flex items-center justify-center flex-shrink-0">
                                    <span class="text-white font-bold text-base sm:text-lg">
                                        {{
                                            estudiante.nombre
                                                .split(' ')
                                                .map(n => n[0])
                                                .slice(0, 2)
                                                .join('')
                                                .toUpperCase()
                                        }}
                                    </span>

                                </div>
                                <div class="min-w-0 flex-1">
                                    <h3 class="font-bold text-slate-900 text-base sm:text-lg truncate">{{
                                        estudiante.nombre }}</h3>
                                    <p class="text-sm text-slate-500 font-medium">{{ estudiante.cedula }}</p>
                                </div>
                            </div>
                            <span
                                class="inline-flex items-center gap-1.5 px-2.5 py-1 rounded-lg text-xs font-semibold flex-shrink-0"
                                :class="estudiante.activo
                                    ? 'bg-green-100 text-green-700'
                                    : 'bg-slate-200 text-slate-700'">
                                <span class="h-1.5 w-1.5 rounded-full"
                                    :class="estudiante.activo ? 'bg-green-500' : 'bg-slate-500'"></span>
                                {{ estudiante.activo ? 'Activo' : 'Inactivo' }}
                            </span>
                        </div>

                        <!-- Info -->
                        <div class="space-y-3 mb-4 pb-4 border-b border-slate-200">
                            <div class="flex items-center gap-3">
                                <div
                                    class="h-8 w-8 bg-purple-100 rounded-lg flex items-center justify-center flex-shrink-0">
                                    <svg class="h-4 w-4 text-purple-600" fill="none" stroke="currentColor"
                                        viewBox="0 0 24 24">
                                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                            d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                                    </svg>
                                </div>
                                <div>
                                    <p class="text-xs text-slate-500 font-medium">Sección</p>
                                    <p class="text-sm font-bold text-slate-900">{{ estudiante.seccion }}</p>
                                </div>
                            </div>
                        </div>

                        <!-- Acciones -->
                        <div class="flex gap-2">
                            <button
                                class="flex-1 flex items-center justify-center gap-2 px-4 py-2.5 border-2 border-slate-300 rounded-lg text-slate-700 hover:bg-slate-50 hover:border-slate-400 transition-all font-medium text-sm">
                                <Edit class="h-4 w-4" />
                                <span>Editar</span>
                            </button>
                            <button
                                class="flex-1 flex items-center justify-center gap-2 px-4 py-2.5 bg-red-600 text-white rounded-lg hover:bg-red-700 transition-all font-medium text-sm shadow-lg shadow-red-500/25">
                                <Trash2 class="h-4 w-4" />
                                <span>Eliminar</span>
                            </button>
                        </div>
                    </div>
                </div>

                <!-- Empty State -->
                <div v-if="estudiantes.length === 0" class="p-12 text-center">
                    <div class="inline-flex h-16 w-16 items-center justify-center rounded-full bg-slate-100 mb-4">
                        <svg class="h-8 w-8 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold text-slate-900 mb-1">No hay estudiantes</h3>
                    <p class="text-sm text-slate-500">Comienza agregando estudiantes al sistema</p>
                </div>
            </div>

        </div>
    </div>
</template>