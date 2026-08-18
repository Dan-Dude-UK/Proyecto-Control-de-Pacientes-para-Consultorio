import { AppShell } from "@/components/layout/AppShell";
import { ResourceManager, type FieldDef } from "@/components/shared/ResourceManager";
import { consultationsApi, type Consultation } from "@/lib/consultorio-api";

const fields: FieldDef<Consultation>[] = [
  { key: "patientId", label: "ID Paciente", type: "number" },
  { key: "doctorId", label: "ID Doctor", type: "number" },
  { key: "consultationDate", label: "Fecha", type: "date" },
  { key: "reason", label: "Motivo", type: "text" },
  { key: "diagnosis", label: "Diagnóstico", type: "text" },
  { key: "notes", label: "Notas", type: "textarea" },
];

export default function Consultas() {
  return (
    <AppShell>
      <ResourceManager<Consultation>
        title="Consultas"
        description="Consultas médicas registradas."
        queryKey="Consultation"
        api={consultationsApi}
        fields={fields}
        searchKeys={["reason", "diagnosis"]}
      />
    </AppShell>
  );
}
