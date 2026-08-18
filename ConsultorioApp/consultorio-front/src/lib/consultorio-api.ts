/**
 * Cliente HTTP para la API de Consultorio (.NET).
 *
 * La URL base se toma de una variable de entorno (ver .env.example) y no se
 * expone en ningún componente visual: la interfaz solo trabaja con los datos
 * ya resueltos, nunca con la ruta o detalles técnicos de la API.
 */

const BASE_URL: string = import.meta.env.VITE_API_URL ?? "http://localhost:5140";

export interface BasePerson {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
  email: string;
  phoneNumber: string;
}

export interface Doctor extends BasePerson {
  specialty: string;
  licenseNumber: string;
  active: boolean;
}

export interface Patient extends BasePerson {
  registrationDate: string;
  bloodType: string;
  medicalHistory: string;
  active: boolean;
}

export interface Consultation {
  id: number;
  patientId: number;
  doctorId: number;
  consultationDate: string;
  reason: string;
  diagnosis: string;
  notes: string;
}

export interface Prescription {
  id: number;
  consultationId: number;
  patientId: number;
  medication: string;
  dosage: string;
  instructions: string;
  issueDate: string;
}

async function request<T>(path: string, init?: RequestInit): Promise<T> {
  const res = await fetch(`${BASE_URL}${path}`, {
    ...init,
    headers: { "Content-Type": "application/json", ...(init?.headers || {}) },
  });
  if (!res.ok) {
    throw new Error("No se pudo completar la solicitud. Verifica el servidor e inténtalo de nuevo.");
  }
  if (res.status === 204) return undefined as T;
  const body = await res.text();
  return (body ? JSON.parse(body) : undefined) as T;
}

/** CRUD genérico sobre un recurso de la API */
function createResourceApi<T extends { id: number }>(controller: string) {
  return {
    list: () => request<T[]>(`/api/${controller}`),
    get: (id: number) => request<T>(`/api/${controller}/${id}`),
    create: (data: Partial<T>) =>
      request<void>(`/api/${controller}`, { method: "POST", body: JSON.stringify(data) }),
    update: (id: number, data: Partial<T>) =>
      request<void>(`/api/${controller}/${id}`, {
        method: "PUT",
        body: JSON.stringify({ ...data, id }),
      }),
    remove: (id: number) =>
      request<void>(`/api/${controller}/${id}`, { method: "DELETE" }),
  };
}

export const doctorsApi = createResourceApi<Doctor>("Doctor");
export const patientsApi = createResourceApi<Patient>("Patient");
export const consultationsApi = createResourceApi<Consultation>("Consultation");
export const prescriptionsApi = createResourceApi<Prescription>("Prescription");
