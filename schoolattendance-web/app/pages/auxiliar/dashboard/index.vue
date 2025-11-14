<script setup lang="ts">
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const pageHeader = {
    icon: "material-symbols:dashboard-2",
    title: "Dashboard",
    description: "Resumen general del sistema de asistencia"
}

interface AttendanceSection {
    section: string
    present: number
    total: number
}


const attendanceSection: AttendanceSection[] = [
    { section: "7-1", present: 28, total: 30 },
    { section: "7-2", present: 25, total: 28 },
    { section: "8-1", present: 30, total: 32 },
    { section: "8-2", present: 27, total: 29 },
    { section: "9-1", present: 20, total: 31 },
]

const year = new Date().toLocaleString('en-US', {
    timeZone: 'America/Costa_Rica',
    year: 'numeric'
})

</script>

<template>
    <LayoutMainContainer>
        <LayoutAppPageHeader :icon="pageHeader.icon" :title="pageHeader.title" :description="pageHeader.description" />

        <GridCards>
            <CardsStats icon="hugeicons:students" color="blue" title="Estudiantes Activos" data-value="324" />
            <CardsStats icon="sidekickicons:bars-3-bottom-center-16-solid" color="purple" title="Secciones"
                data-value="18" />
            <CardsStats icon="material-symbols:check-circle" color="green" title="Asistencia Promedio"
                data-value="94.2%" />
            <CardsStats icon="material-symbols:calendar-today-outline-rounded" color="amber" title="Ciclo Lectivo"
                :data-value="year" />
        </GridCards>

        <LayoutSectionPanel icon="gridicons:stats-up-alt" title="Asistencia por Sección"
            description="Registro del día de hoy">

            <GridCards>
                <div v-for="item in attendanceSection" :key="item.section">
                    <CardsAssistance :section="item.section" :present="item.present" :total="item.total" />
                </div>
            </GridCards>
        </LayoutSectionPanel>
    </LayoutMainContainer>
</template>

<style>
@keyframes shimmer {
    0% {
        transform: translateX(-100%);
    }

    100% {
        transform: translateX(100%);
    }
}

.animate-shimmer {
    animation: shimmer 2s infinite;
}
</style>