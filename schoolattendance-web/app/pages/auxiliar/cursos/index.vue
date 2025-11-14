<script setup>
definePageMeta({
    requiredAuth: true,
    allowedRoles: ["auxiliar"]
});

const pageHeader = {
    icon: "material-symbols:book-3-rounded",
    title: "Cursos",
    description: "Gestiona y administra los cursos del colegio",
    titleBtn: "Crear Curso",
}

const cursos = [
    {
        id: 1,
        nombre: "Ciencias Informáticas",
        codigo: "CI",
        secciones: 4,
        estudiantes: 120,
        ciclo: "2025",
    },
    {
        id: 2,
        nombre: "Matemáticas",
        codigo: "MAT",
        secciones: 6,
        estudiantes: 180,
        ciclo: "2025",
    },
    {
        id: 3,
        nombre: "Español",
        codigo: "ESP",
        secciones: 5,
        estudiantes: 150,
        ciclo: "2025",
    },
    {
        id: 4,
        nombre: "Estudios Sociales",
        codigo: "ESO",
        secciones: 5,
        estudiantes: 145,
        ciclo: "2025",
    },
    {
        id: 5,
        nombre: "Ciencias",
        codigo: "CIE",
        secciones: 5,
        estudiantes: 148,
        ciclo: "2025",
    },
    {
        id: 6,
        nombre: "Inglés",
        codigo: "ING",
        secciones: 6,
        estudiantes: 175,
        ciclo: "2025",
    },
]
</script>

<template>
    <LayoutMainContainer>
        <LayoutAppPageHeader :icon="pageHeader.icon" :title="pageHeader.title" :description="pageHeader.description"
            :title-btn="pageHeader.titleBtn" :active-slot="true">

            <MetricsMiniStatsItem title="Total Cursos" :content="cursos.length" color="blue"
                icon="material-symbols:book-ribbon" />

            <MetricsMiniStatsItem title="Total Secciones" :content="cursos.reduce((sum, c) => sum +
                c.secciones, 0)" color="purple" icon="sidekickicons:bars-3-bottom-center-16-solid" />

            <MetricsMiniStatsItem title="Total Estudiantes" :content="cursos.reduce((sum, c) => sum +
                c.estudiantes, 0)
                " color="green" icon="hugeicons:students" />
        </LayoutAppPageHeader>


        <GridCards min-width="320" cols="3">
            <div v-for="course in cursos" :key="course.id">
                <MetricsCourseCard :name="course.nombre" :code="course.codigo" :sections="course.secciones"
                    :students="course.estudiantes" :term="course.ciclo" />
            </div>
        </GridCards>

    </LayoutMainContainer>
</template>