<script setup lang="ts">
interface Props {
    icon: string,
    color: 'blue' | 'purple' | 'green' | 'amber'
    title: string
    dataValue: string
}
const props = defineProps<Props>()

const colorClasses: Record<string, string> = {
    blue: 'from-blue-500 to-blue-600 shadow-blue-500/30',
    purple: 'from-purple-500 to-purple-600 shadow-purple-500/30',
    green: 'from-green-500 to-green-600 shadow-green-500/30',
    amber: 'from-amber-500 to-amber-600 shadow-amber-500/30'
}
</script>

<template>
    <div class="group bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 
         hover:shadow-xl hover:border-blue-200 transition-all duration-300 hover:-translate-y-1 
         overflow-hidden relative">
        <div class="absolute top-0 right-0 w-24 h-24 sm:w-32 sm:h-32 bg-gradient-to-br from-blue-500/10 
           to-transparent rounded-full -mr-12 sm:-mr-16 -mt-12 sm:-mt-16" />

        <div class="relative">
            <div class="flex items-start justify-between mb-3 sm:mb-4">
                <div :class="[colorClasses[props.color]]"
                    class="flex items-center justify-center aspect-square p-2.5 sm:p-3 bg-gradient-to-br rounded-lg sm:rounded-xl shadow-lg group-hover:scale-110 transition-transform duration-200">
                    <Icon :name="icon" class="text-white h-5 w-5 sm:h-6 sm:w-6" :stroke-width="2" :aria-hidden="true" />
                </div>
            </div>

            <h3 class="text-slate-500 text-xs sm:text-sm font-medium mb-1">{{ title }}</h3>
            <p class="text-2xl sm:text-3xl font-bold text-slate-900">{{ dataValue }}</p>
        </div>
    </div>
</template>