<script setup lang="ts">
interface Props {
    section: string
    present: number
    total: number
}

const props = defineProps<Props>()

const calcularPorcentaje = (presente: number, total: number): number => {
    return Math.round((presente / total) * 100)
}
</script>

<template>
    <div
        class="group bg-gradient-to-br from-slate-50 to-slate-100 rounded-lg sm:rounded-xl p-4 sm:p-5 border-2 border-slate-200 hover:border-blue-300 hover:shadow-lg transition-all duration-200">

        <!-- Header de la tarjeta - Responsive -->
        <div class="flex items-center justify-between mb-3 sm:mb-4 gap-3">
            <div class="flex items-center gap-2 sm:gap-3 min-w-0 flex-1">
                <div
                    class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-blue-500 to-blue-600 rounded-lg sm:rounded-xl flex items-center justify-center shadow-lg shadow-blue-500/30 flex-shrink-0">
                    <span class="text-white font-bold text-sm sm:text-lg">{{ section }}</span>
                </div>
                <div class="min-w-0">
                    <p class="text-xs sm:text-sm text-slate-500 font-medium">Sección</p>
                    <p class="text-base sm:text-lg font-bold text-slate-900">{{ section }}</p>
                </div>
            </div>
            <div class="text-right flex-shrink-0">
                <p class="text-xl sm:text-2xl font-bold text-slate-900">{{
                    calcularPorcentaje(present, total) }}%</p>
            </div>
        </div>

        <!-- Barra de progreso -->
        <div class="space-y-2">
            <div class="flex justify-between items-center text-xs sm:text-sm">
                <span class="text-slate-600 font-medium">
                    <span class="text-blue-600 font-bold">{{ present }}</span> de {{
                        total }}
                </span>
                <span class="text-slate-400 text-xs">presents</span>
            </div>
            <div class="h-2.5 sm:h-3 bg-slate-200 rounded-full overflow-hidden shadow-inner">
                <div class="h-full bg-gradient-to-r from-blue-500 to-blue-600 rounded-full transition-all duration-500 shadow-lg relative overflow-hidden group-hover:from-blue-600 group-hover:to-blue-700"
                    :style="{ width: `${calcularPorcentaje(present, total)}%` }">
                    <div
                        class="absolute inset-0 bg-gradient-to-r from-transparent via-white/30 to-transparent animate-shimmer">
                    </div>
                </div>
            </div>
        </div>

        <!-- Indicador de estado -->
        <div class="mt-2.5 sm:mt-3 pt-2.5 sm:pt-3 border-t border-slate-200">
            <div class="flex items-center gap-2">
                <div :class="[
                    'h-2 w-2 rounded-full flex-shrink-0',
                    calcularPorcentaje(present, total) >= 90 ? 'bg-green-500' :
                        calcularPorcentaje(present, total) >= 75 ? 'bg-yellow-500' : 'bg-red-500'
                ]"></div>
                <span class="text-[10px] sm:text-xs font-medium truncate" :class="[
                    calcularPorcentaje(present, total) >= 90 ? 'text-green-600' :
                        calcularPorcentaje(present, total) >= 75 ? 'text-yellow-600' : 'text-red-600'
                ]">
                    {{ calcularPorcentaje(present, total) >= 90 ? 'Excelente asistencia'
                        :
                        calcularPorcentaje(present, total) >= 75 ? 'Buena asistencia' :
                            calcularPorcentaje(present, total) >= 75 ? 'Buena asistencia' :
                                'Asistencia baja' }}
                </span>
            </div>
        </div>
    </div>
</template>