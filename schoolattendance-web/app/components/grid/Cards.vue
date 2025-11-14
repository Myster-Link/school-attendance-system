<script setup lang="ts">
interface Props {
  /** Ancho mínimo de cada card en px */
  minWidth?: number
  /** Gap entre las cards */
  gap?: number
}

const props = defineProps<Props>()
const minWidth = props.minWidth ?? 250
const gap = props.gap ?? 16 // equivalente a gap-4
</script>

<template>
  <div
    class="grid"
    :style="{
      gap: gap + 'px',
      gridTemplateColumns: `repeat(auto-fit, minmax(${minWidth}px, 1fr))`
    }"
  >
    <slot />
  </div>
</template>
