export interface Persona {
  nombre: string;
  genero: string;
  ubicacion: string;
  correo: string;
  fechaNacimiento: string;
  foto: string;
}

//const API_URL = "http://localhost:61440/api/personas/Generar"; // Ajusta según tu backend

const API_URL = import.meta.env.VITE_API_URL;
const API_KEY = import.meta.env.VITE_API_KEY;

export async function obtenerPersonas(): Promise<Persona[]> {
  const response = await fetch(API_URL, {
    headers: {
      "X-API-KEY": API_KEY
    }
  });

  if (!response.ok) {
    throw new Error("Error al obtener personas");
  }

  return await response.json();
}
