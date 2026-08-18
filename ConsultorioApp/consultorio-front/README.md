# Consultorio — Frontend

Panel de administración para el sistema de Consultorio (pacientes, doctores,
consultas y recetas). Construido con React + Vite + TypeScript + Tailwind v4 +
shadcn/ui + TanStack Query, tomando como referencia la arquitectura de
`fit-business-front` pero con una paleta de color propia (tema claro,
acentos en teal) y adaptado al dominio médico.

## Requisitos

- Node.js 18+
- El backend de Consultorio (`Consultorio.Api`) corriendo localmente

## Configuración

1. Instala las dependencias:

   ```bash
   npm install
   ```

2. Copia el archivo de variables de entorno y ajusta la URL de tu API si es
   necesario (por defecto asume `http://localhost:5140`, que es el puerto
   configurado en `launchSettings.json` del backend):

   ```bash
   cp .env.example .env
   ```

3. Levanta el backend .NET (`dotnet run` dentro de `Consultorio.Api`) y luego
   el frontend:

   ```bash
   npm run dev
   ```

4. Abre `http://localhost:5173`.

## Estructura

```
src/
  components/
    layout/AppShell.tsx        # Sidebar + navegación
    shared/ResourceManager.tsx # Tabla + formulario CRUD genérico y reutilizable
    ui/                        # Primitivos de shadcn/ui (botón, input, dialog, etc.)
  lib/
    consultorio-api.ts         # Cliente HTTP hacia la API (.NET). La URL base
                                # se lee de VITE_API_URL y nunca se expone en la UI.
  pages/
    Dashboard.tsx
    Pacientes.tsx
    Doctores.tsx
    Consultas.tsx
    Recetas.tsx
```

## Notas

- Cada página (Pacientes, Doctores, Consultas, Recetas) reutiliza el mismo
  componente `ResourceManager`, solo cambiando los campos (`fields`) y el
  endpoint. Para agregar un nuevo recurso, basta con crear una nueva página
  siguiendo el mismo patrón.
- La paleta de colores vive en `src/styles.css` (variables `oklch`). Puedes
  ajustar `--primary`, `--accent`, etc. para cambiar el estilo sin tocar los
  componentes.
- Los mensajes de error mostrados al usuario son genéricos a propósito: no
  exponen la URL ni detalles internos de la API.
