using System;

namespace CV262526_Desafio02
{
    public static class Almacen
    {
        public static Docente[] Docentes = new Docente[100];
        public static int TotalDocentes = 0;

        public static Alumno[] Alumnos = new Alumno[100];
        public static int TotalAlumnos = 0;

        public static void AgregarDocente(Docente d)
        {
            if (TotalDocentes >= Docentes.Length)
                throw new InvalidOperationException("El arreglo de docentes esta lleno.");
            Docentes[TotalDocentes] = d;
            TotalDocentes++;
        }

        public static void EliminarDocente(int posicion)
        {
            if (posicion < 0 || posicion >= TotalDocentes)
                throw new InvalidOperationException("Docente no encontrado.");
            for (int i = posicion; i < TotalDocentes - 1; i++)
            {
                Docentes[i] = Docentes[i + 1];
            }
            Docentes[TotalDocentes - 1] = null;
            TotalDocentes--;
        }

        public static void AgregarAlumno(Alumno a)
        {
            if (TotalAlumnos >= Alumnos.Length)
                throw new InvalidOperationException("El arreglo de alumnos esta lleno.");
            Alumnos[TotalAlumnos] = a;
            TotalAlumnos++;
        }

        public static void EliminarAlumno(int posicion)
        {
            if (posicion < 0 || posicion >= TotalAlumnos)
                throw new InvalidOperationException("Alumno no encontrado.");
            for (int i = posicion; i < TotalAlumnos - 1; i++)
            {
                Alumnos[i] = Alumnos[i + 1];
            }
            Alumnos[TotalAlumnos - 1] = null;
            TotalAlumnos--;
        }

        // Devuelve true si el carnet ya existe (ignora la posicion indicada)
        public static bool CarnetExiste(string carnet, int posicionIgnorada)
        {
            for (int i = 0; i < TotalAlumnos; i++)
            {
                if (i != posicionIgnorada && Alumnos[i].Carnet == carnet.Trim().ToUpper())
                    return true;
            }
            return false;
        }
    }
}