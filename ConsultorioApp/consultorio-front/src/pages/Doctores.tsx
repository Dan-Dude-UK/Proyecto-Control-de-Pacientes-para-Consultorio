import { AppShell } from "@/components/layout/AppShell";
import { ResourceManager, type FieldDef } from "@/components/shared/ResourceManager";
import { doctorsApi, type Doctor } from "@/lib/consultorio-api";

const fields: FieldDef<Doctor>[] = [
  { key: "firstName", label: "Nombre", type: "text" },
  { key: "lastName", label: "Apellido", type: "text" },
  { key: "age", label: "Edad", type: "number" },
  { key: "email", label: "Email", type: "email" },
  { key: "phoneNumber", label: "Teléfono", type: "text" },
  { key: "specialty", label: "Especialidad", type: "text" },
  { key: "licenseNumber", label: "N.º de licencia", type: "text" },
  { key: "active", label: "Activo", type: "boolean" },
];

export default function Doctores() {
  return (
    <AppShell>
      <ResourceManager<Doctor>
        title="Doctores"
        description="Personal médico del consultorio."
        queryKey="Doctor"
        api={doctorsApi}
        fields={fields}
        searchKeys={["firstName", "lastName", "specialty", "email"]}
      />
    </AppShell>
  );
}
