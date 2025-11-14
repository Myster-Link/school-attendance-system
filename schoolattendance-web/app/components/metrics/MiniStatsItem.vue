<script setup lang="ts">
interface Props {
    title: string
    content: string
    color: 'blue' | 'purple' | 'green' | 'amber'
    icon: string
}
defineProps<Props>()

const colorMap: Record<string, { bg: string; text: string }> = {
    blue: {
        bg: "bg-blue-100",
        text: "text-blue-600"
    },
    purple: {
        bg: "bg-purple-100",
        text: "text-purple-600"
    },
    green: {
        bg: "bg-green-100",
        text: "text-green-600"
    },
    amber: {
        bg: "bg-amber-100",
        text: "text-amber-600"
    }
}
</script>

<template>
    <div class="flex items-center gap-2 sm:gap-3 p-3 sm:p-0">
        <div
            :class="['h-8 w-8 sm:h-10 sm:w-10 rounded-lg flex items-center justify-center flex-shrink-0', colorMap[color]!.bg]">
            <Icon :name="icon" :class="['h-4 w-4 sm:h-5 sm:w-5', colorMap[color]!.text]" />
        </div>

        <div class="min-w-0">
            <p class="text-xl sm:text-2xl font-bold text-slate-900">{{ content }}</p>
            <p class="text-xs sm:text-sm text-slate-500 truncate">{{ title }}</p>
        </div>
    </div>
</template>
