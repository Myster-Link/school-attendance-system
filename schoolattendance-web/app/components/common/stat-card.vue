<script setup lang="ts">
interface Trend {
    value: string
    isPositive: boolean
}

interface Props {
    title: string
    value: string | number
    description?: string
    icon: string
    trend?: Trend
    className?: string
}

defineProps<Props>()
</script>

<template>
    <div :class="['overflow-hidden rounded-lg border bg-card text-card-foreground shadow-sm', className]">
        <div class="p-6">
            <div class="flex items-start justify-between">
                <div class="space-y-2">
                    <p class="text-sm font-medium text-muted-foreground">{{ title }}</p>
                    <p class="text-3xl font-bold text-foreground">{{ value }}</p>
                    <p v-if="description" class="text-sm text-muted-foreground">{{ description }}</p>
                    <div v-if="trend" class="flex items-center gap-1 text-sm">
                        <span :class="['font-medium', trend.isPositive ? 'text-accent' : 'text-destructive']">
                            {{ trend.value }}
                        </span>
                        <span class="text-muted-foreground">vs mes anterior</span>
                    </div>
                </div>
                <div class="flex items-center justify-center p-3 bg-primary/10 rounded-lg">
                    <Icon :name="icon" class="h-6 w-6 text-primary" />
                </div>

            </div>
        </div>
    </div>
</template>