<script setup lang="ts">
import Sidebar from '~/components/common/sidebar.vue';

</script>

<template>
    <Sidebar />
    <main class="flex-1 lg:ml-64">
        <div class="p-6 lg:p-8">
            <slot />
        </div>
    </main>
</template>

<style scoped></style>