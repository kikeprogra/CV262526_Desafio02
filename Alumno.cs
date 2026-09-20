using System;

namespace CV262526_Desafio02
{
    public class Alumno : Persona
    {
        private string carrera;
        private string carnet;

        public string Carrera
        {
            get { return carrera; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("La carrera es obligatoria.");
                carrera = value.Trim();
            }
        }

        public string Carnet
        {
            get { return carnet; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("El carnet es obligatorio.");
                carnet = value.Trim().ToUpper();
            }
        }

        public Alumno(string nombres, string apellidos, DateTime fechaNacimiento,
                      string sexo, string carrera, string carnet)
            : base(nombres, apellidos, fechaNacimiento, sexo)
        {
            Carrera = carrera;
            Carnet = carnet;
        }
    }
}