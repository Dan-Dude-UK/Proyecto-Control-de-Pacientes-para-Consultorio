import { Link, useLocation } from "react-router-dom";
import { Stethoscope, Users, UserRound, ClipboardList, Pill, LayoutDashboard } from "lucide-react";
import type { ReactNode } from "react";
import { Toaster } from "@/components/ui/sonner";

const nav = [
  { to: "/", label: "Panel", icon: LayoutDashboard },
  { to: "/pacientes", label: "Pacientes", icon: Users },
  { to: "/doctores", label: "Doctores", icon: UserRound },
  { to: "/consultas", label: "Consultas", icon: ClipboardList },
  { to: "/recetas", label: "Recetas", icon: Pill },
] as const;

export function AppShell({ children }: { children: ReactNode }) {
  const { pathname } = useLocation();

  return (
    <div className="flex min-h-screen bg-background text-foreground">
      <aside className="sticky top-0 hidden h-screen w-64 shrink-0 flex-col border-r border-border bg-sidebar p-5 md:flex">
        <div className="mb-8 flex items-center gap-3 px-1">
          <span className="flex size-10 items-center justify-center rounded-xl bg-primary text-primary-foreground shadow-sm">
            <Stethoscope className="size-5" />
          </span>
          <div className="leading-tight">
            <p className="text-sm font-bold tracking-tight text-foreground">Consultorio</p>
            <p className="text-xs text-muted-foreground">Gestión clínica</p>
          </div>
        </div>
        <nav className="flex flex-1 flex-col gap-1">
          {nav.map((item) => {
            const active = pathname === item.to;
            const Icon = item.icon;
            return (
              <Link
                key={item.to}
                to={item.to}
                className={`flex items-center gap-3 rounded-lg px-3 py-2.5 text-sm font-medium transition-colors ${
                  active
                    ? "bg-primary text-primary-foreground shadow-sm"
                    : "text-muted-foreground hover:bg-accent hover:text-accent-foreground"
                }`}
              >
                <Icon className="size-4" />
                {item.label}
              </Link>
            );
          })}
        </nav>
        <div className="rounded-lg border border-border bg-muted/50 p-3 text-xs text-muted-foreground">
          Sistema interno de administración del consultorio.
        </div>
      </aside>

      <div className="flex min-w-0 flex-1 flex-col">
        <div className="flex gap-1 overflow-x-auto border-b border-border bg-card p-2 md:hidden">
          {nav.map((item) => (
            <Link
              key={item.to}
              to={item.to}
              className={`rounded-md px-3 py-1.5 text-xs font-medium whitespace-nowrap ${
                pathname === item.to
                  ? "bg-primary text-primary-foreground"
                  : "text-muted-foreground"
              }`}
            >
              {item.label}
            </Link>
          ))}
        </div>
        <main className="flex-1 p-6 md:p-10">{children}</main>
      </div>
      <Toaster richColors position="top-right" />
    </div>
  );
}
