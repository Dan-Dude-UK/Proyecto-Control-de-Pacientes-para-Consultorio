import { useQuery } from "@tanstack/react-query";
import { Link } from "react-router-dom";
import { ClipboardList, Pill, UserRound, Users } from "lucide-react";
import { AppShell } from "@/components/layout/AppShell";
import {
  consultationsApi,
  doctorsApi,
  patientsApi,
  prescriptionsApi,
} from "@/lib/consultorio-api";

function StatCard({
  label,
  value,
  loading,
  icon: Icon,
  to,
}: {
  label: string;
  value: number;
  loading: boolean;
  icon: typeof Users;
  to: string;
}) {
  return (
    <Link
      to={to}
      className="group rounded-xl border border-border bg-card p-5 transition-colors hover:border-primary hover:shadow-sm"
    >
      <div className="flex items-center justify-between">
        <span className="text-xs font-semibold uppercase tracking-wide text-muted-foreground">
          {label}
        </span>
        <span className="flex size-8 items-center justify-center rounded-lg bg-accent text-accent-foreground">
          <Icon className="size-4" />
        </span>
      </div>
      <p className="mt-3 text-3xl font-bold tabular-nums text-foreground">
        {loading ? "—" : value}
      </p>
    </Link>
  );
}

export default function Dashboard() {
  const patients = useQuery({ queryKey: ["Patient"], queryFn: patientsApi.list, retry: false });
  const doctors = useQuery({ queryKey: ["Doctor"], queryFn: doctorsApi.list, retry: false });
  const consultations = useQuery({
    queryKey: ["Consultation"],
    queryFn: consultationsApi.list,
    retry: false,
  });
  const prescriptions = useQuery({
    queryKey: ["Prescription"],
    queryFn: prescriptionsApi.list,
    retry: false,
  });

  return (
    <AppShell>
      <div className="space-y-8">
        <header>
          <p className="text-xs font-bold uppercase tracking-[0.2em] text-primary">
            Sistema de gestión
          </p>
          <h1 className="mt-2 text-3xl font-bold tracking-tight text-foreground">
            Panel del consultorio
          </h1>
          <p className="mt-2 max-w-xl text-sm text-muted-foreground">
            Administra pacientes, doctores, consultas y recetas desde un mismo lugar.
          </p>
        </header>

        <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4">
          <StatCard
            label="Pacientes"
            value={patients.data?.length ?? 0}
            loading={patients.isLoading}
            icon={Users}
            to="/pacientes"
          />
          <StatCard
            label="Doctores"
            value={doctors.data?.length ?? 0}
            loading={doctors.isLoading}
            icon={UserRound}
            to="/doctores"
          />
          <StatCard
            label="Consultas"
            value={consultations.data?.length ?? 0}
            loading={consultations.isLoading}
            icon={ClipboardList}
            to="/consultas"
          />
          <StatCard
            label="Recetas"
            value={prescriptions.data?.length ?? 0}
            loading={prescriptions.isLoading}
            icon={Pill}
            to="/recetas"
          />
        </div>
      </div>
    </AppShell>
  );
}
