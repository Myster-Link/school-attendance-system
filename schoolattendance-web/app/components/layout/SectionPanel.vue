<script setup lang="ts">
interface Props {
    icon: string,
    title: string
    description: string
}
const props = defineProps<Props>()
</script>

<template>
    <section class="bg-white rounded-xl sm:rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
        <div class="bg-gradient-to-r from-blue-600 to-indigo-600 p-4 sm:p-6">
            <div class="flex items-center gap-2 sm:gap-3">
                <div class="h-8 w-8 sm:h-10 sm:w-10 bg-white/20 backdrop-blur rounded-lg 
                            flex items-center justify-center flex-shrink-0">
                    <Icon :name="icon" class="text-white" size="25" :stroke-width="2" :aria-hidden="true" />
                </div>

                <div class="min-w-0 flex-1">
                    <h3 class="text-xl sm:text-2xl font-bold text-white">{{ title }}</h3>
                    <p class="text-blue-100 text-xs sm:text-sm">{{ description }}</p>
                </div>
            </div>
        </div>

        <div class="p-4 sm:p-6">
            <slot />
        </div>
    </section>
</template>