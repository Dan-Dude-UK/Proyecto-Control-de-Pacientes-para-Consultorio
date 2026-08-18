import { AppShell } from "@/components/layout/AppShell";
import { ResourceManager, type FieldDef } from "@/components/shared/ResourceManager";
import { patientsApi, type Patient } from "@/lib/consultorio-api";

const fields: FieldDef<Patient>[] = [
  { key: "firstName", label: "Nombre", type: "text" },
  { key: "lastName", label: "Apellido", type: "text" },
  { key: "age", label: "Edad", type: "number" },
  { key: "email", label: "Email", type: "email" },
  { key: "phoneNumber", label: "Teléfono", type: "text" },
  { key: "registrationDate", label: "Fecha de registro", type: "date" },
  { key: "bloodType", label: "Tipo de sangre", type: "text" },
  { key: "medicalHistory", label: "Historial médico", type: "textarea" },
  { key: "active", label: "Activo", type: "boolean" },
];

export default function Pacientes() {
  return (
    <AppShell>
      <ResourceManager<Patient>
        title="Pacientes"
        description="Pacientes registrados en el consultorio."
        queryKey="Patient"
        api={patientsApi}
        fields={fields}
        searchKeys={["firstName", "lastName", "email"]}
      />
    </AppShell>
  );
}
