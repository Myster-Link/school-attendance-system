<script setup lang="ts">
interface Props {
    icon: string,
    title: string
    description?: string
    titleBtn?: string,
    iconBtn?: string,
    activeSlot?: boolean
}
defineProps<Props>()
</script>

<template>
    <div class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 p-4 sm:p-6 lg:p-8">
        <div class="flex flex-col gap-4 sm:gap-6 lg:flex-row lg:items-center lg:justify-between">
            <div class="space-y-2 sm:space-y-3">
                <div class="flex items-center gap-3">
                    <div
                        class="h-10 w-10 sm:h-12 sm:w-12 bg-gradient-to-br from-blue-600 to-blue-700 rounded-lg sm:rounded-xl flex items-center justify-center flex-shrink-0">
                        <Icon :name="icon" class="text-white" :size="30" />
                    </div>
                    <div class="min-w-0 flex-1">
                        <h1
                            class="text-2xl sm:text-3xl lg:text-4xl font-bold bg-gradient-to-r from-slate-900 to-slate-700 bg-clip-text text-transparent truncate">
                            {{ title }}
                        </h1>
                        <p class="text-sm sm:text-base text-slate-500 mt-0.5 sm:mt-1">{{ description }}</p>
                    </div>
                </div>
            </div>
            <button v-if="titleBtn"
                class="cursor-pointer group flex items-center justify-center gap-2 px-4 sm:px-6 py-2.5 sm:py-3 bg-gradient-to-r from-blue-600 to-blue-700 text-white rounded-lg sm:rounded-xl hover:from-blue-700 hover:to-blue-800 transition-all duration-200 shadow-lg shadow-blue-500/25 hover:shadow-xl hover:shadow-blue-500/40 hover:-translate-y-0.5 w-full lg:w-auto text-sm sm:text-base font-medium">
                <Icon :name="iconBtn ?? 'material-symbols:add-box-rounded'" :size="30"
                    class="h-4 w-4 sm:h-5 sm:w-5 group-hover:rotate-90 transition-transform duration-200" />
                <span class="font-semibold">{{ titleBtn }}</span>
            </button>
        </div>

        <div v-if="activeSlot"
            class="grid grid-cols-2 sm:grid-cols-4 gap-3 sm:gap-4 mt-4 sm:mt-6 pt-4 sm:pt-6 border-t border-slate-100">
            <slot />
        </div>
    </div>
</template>

<style scoped></style>