using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapp_2.entidades
{
    public class persona
    {
        private string documento;
        private string apellido;
        private string nombre;
        private DateTime fechaNacimiento;
        private int IdSexo;
        private int IdTipoDocumento;
        private string NroCasa;
        private string Calle;
        private bool Soltero;
        private bool Casado;
        private bool Hijos;
        private int CantidadHijos;
        private int IdCarrera;

        public persona(string doc, string ape, string nom)
        {

            documento = doc;
            apellido = ape;
            nombre = nom;

        }

        public persona()
        {

        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public string Documento
        {
            get => documento;
            set => documento = value;
        }

        public DateTime fechaNacimientoPersona
        {
            get => fechaNacimiento;
            set => fechaNacimiento = value;
        }

        public int IdSexoPersona
        {
            get => IdSexo;
            set => IdSexo = value;
        }

        public int IdTipoDocumentoPersona
        {
            get => IdTipoDocumento;
            set => IdTipoDocumento = value;
        }

        public string NroCasaPersona
        {
            get => NroCasa;
            set => NroCasa = value;
        }

        public string CallePersona
        {
            get => Calle;
            set => Calle  = value;
        }

        public bool SolteroPersona
        {
            get => Soltero;
            set => Soltero = value;
        }

        public bool CasadoPersona
        {
            get => Casado;
            set => Casado = value;
        }

        public bool HijosPersona
        {
            get => Hijos;
            set => Hijos = value;
        }

        public int CantidadHijosPersona
        {
            get => CantidadHijos;
            set => CantidadHijos = value;
        }

        public int IdCarreraPersona
        {
            get => IdCarrera;
            set => IdCarrera = value;
        }
    }
}

