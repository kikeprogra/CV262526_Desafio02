using System;

namespace CV262526_Desafio02
{
    public class Persona
    {
        private string nombres;
        private string apellidos;
        private DateTime fechaNacimiento;
        private string sexo;

        public string Nombres
        {
            get { return nombres; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("Los nombres no pueden estar vacios.");
                nombres = value.Trim();
            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (value == null || value.Trim() == "")
                    throw new ArgumentException("Los apellidos no pueden estar vacios.");
                apellidos = value.Trim();
            }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
                fechaNacimiento = value;
            }
        }

        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (value != "Masculino" && value != "Femenino")
                    throw new ArgumentException("Seleccione un sexo valido.");
                sexo = value;
            }
        }

        public Persona(string nombres, string apellidos, DateTime fechaNacimiento, string sexo)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
        }
    }
}