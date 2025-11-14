<script setup lang="ts">
interface Props {
    name: string
    code: string
    sections: number
    students: number
    term: string
}
const props = defineProps<Props>()

const cursos = [
    { nombre: "Español", icono: "book-open" },
    { nombre: "Matemáticas", icono: "calculator" },
    { nombre: "Ciencias Naturales", icono: "flask" },
    { nombre: "Estudios Sociales", icono: "globe" },
    { nombre: "Inglés", icono: "language" },
    { nombre: "Educación Cívica", icono: "scale" },
    { nombre: "Educación Física", icono: "dumbbell" },
    { nombre: "Arte / Música", icono: "palette" },
    { nombre: "Tecnología / Informática", icono: "desktop" },
    { nombre: "Educación Religiosa", icono: "church" }
];
</script>

<template>
    <div
        class="group bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 hover:shadow-xl hover:border-blue-200 transition-all duration-300 overflow-hidden hover:-translate-y-1">

        <!-- Header del curso con gradiente -->
        <div class="h-1.5 sm:h-2 bg-gradient-to-r from-blue-500 via-blue-600 to-blue-700"></div>

        <div class="p-4 sm:p-6 space-y-4 sm:space-y-6">
            <!-- Información principal -->
            <div class="space-y-3 sm:space-y-4">
                <div class="flex items-start justify-between gap-3">
                    <div class="flex items-center gap-3 flex-1 min-w-0">
                        <div
                            class="p-2 sm:p-3 bg-gradient-to-br from-blue-50 to-blue-100 rounded-lg sm:rounded-xl group-hover:scale-110 transition-transform duration-200 flex-shrink-0">
                            <BookOpen class="h-5 w-5 sm:h-7 sm:w-7 text-blue-600" />
                        </div>
                        <div class="flex-1 min-w-0">
                            <h3
                                class="text-base sm:text-xl font-bold text-slate-900 group-hover:text-blue-600 transition-colors truncate">
                                {{ name }}
                            </h3>
                            <div class="flex items-center gap-2 mt-1">
                                <span class="text-xs sm:text-sm font-medium text-slate-500">Código:</span>
                                <span class="text-xs sm:text-sm font-bold text-blue-600 bg-blue-50 px-2 py-0.5 rounded">
                                    {{ code }}
                                </span>
                            </div>
                        </div>
                    </div>
                    <span
                        class="bg-gradient-to-r from-slate-100 to-slate-200 text-slate-700 px-2 sm:px-3 py-1 rounded-full text-xs sm:text-sm font-semibold shadow-sm flex-shrink-0">
                        {{ term }}
                    </span>
                </div>

                <!-- Estadísticas del curso - Responsive -->
                <div class="grid grid-cols-2 gap-3 sm:gap-4 pt-3 sm:pt-4">
                    <div
                        class="bg-gradient-to-br from-blue-50 to-blue-100/50 rounded-lg sm:rounded-xl p-3 sm:p-4 border border-blue-100">
                        <div class="flex items-center gap-1.5 sm:gap-2 mb-1.5 sm:mb-2">
                            <Icon name="sidekickicons:bars-3-bottom-center-16-solid" />
                            <span
                                class="text-[10px] sm:text-xs font-medium text-blue-600 uppercase tracking-wide truncate">sections</span>
                        </div>
                        <p class="text-xl sm:text-2xl font-bold text-slate-900">{{ sections }}</p>
                    </div>
                    <div
                        class="bg-gradient-to-br from-green-50 to-green-100/50 rounded-lg sm:rounded-xl p-3 sm:p-4 border border-green-100">
                        <div class="flex items-center gap-1.5 sm:gap-2 mb-1.5 sm:mb-2">
                            <Icon name="" class="h-3 w-3 sm:h-4 sm:w-4 text-green-600 flex-shrink-0" />
                            <span
                                class="text-[10px] sm:text-xs font-medium text-green-600 uppercase tracking-wide truncate">students</span>
                        </div>
                        <p class="text-xl sm:text-2xl font-bold text-slate-900">{{ students }}</p>
                    </div>
                </div>
            </div>

            <!-- Botones de acción - Responsive -->
            <div class="flex flex-col xs:flex-row gap-2 sm:gap-3 pt-3 sm:pt-4 border-t border-slate-100">
                <button
                    class="flex-1 flex items-center justify-center gap-2 px-3 sm:px-4 py-2 sm:py-2.5 border-2 border-slate-200 rounded-lg sm:rounded-xl text-slate-700 font-medium hover:bg-slate-50 hover:border-slate-300 transition-all duration-200 group/btn text-sm">
                    <Eye
                        class="h-3.5 w-3.5 sm:h-4 sm:w-4 group-hover/btn:scale-110 transition-transform flex-shrink-0" />
                    <span>Ver sections</span>
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
</template>

<style lang="css" scoped></style>