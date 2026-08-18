import { AppShell } from "@/components/layout/AppShell";
import { ResourceManager, type FieldDef } from "@/components/shared/ResourceManager";
import { prescriptionsApi, type Prescription } from "@/lib/consultorio-api";

const fields: FieldDef<Prescription>[] = [
  { key: "consultationId", label: "ID Consulta", type: "number" },
  { key: "patientId", label: "ID Paciente", type: "number" },
  { key: "medication", label: "Medicamento", type: "text" },
  { key: "dosage", label: "Dosis", type: "text" },
  { key: "instructions", label: "Instrucciones", type: "textarea" },
  { key: "issueDate", label: "Fecha de emisión", type: "date" },
];

export default function Recetas() {
  return (
    <AppShell>
      <ResourceManager<Prescription>
        title="Recetas"
        description="Recetas médicas emitidas a los pacientes."
        queryKey="Prescription"
        api={prescriptionsApi}
        fields={fields}
        searchKeys={["medication"]}
      />
    </AppShell>
  );
}
