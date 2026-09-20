using System;

namespace CV262526_Desafio02
{
    public class Docente : Persona
    {
        private string profesion;
        private string asignatura;

        public string Profesion
        {
            get { return profesion; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("La profesion es obligatoria.");
                profesion = value.Trim();
            }
        }

        public string Asignatura
        {
            get { return asignatura; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("La asignatura es obligatoria.");
                asignatura = value.Trim();
            }
        }

        public Docente(string nombres, string apellidos, DateTime fechaNacimiento,
                       string sexo, string profesion, string asignatura)
            : base(nombres, apellidos, fechaNacimiento, sexo)
        {
            Profesion = profesion;
            Asignatura = asignatura;
        }
    }
}