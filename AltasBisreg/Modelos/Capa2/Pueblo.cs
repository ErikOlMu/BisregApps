using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa2
{
    class Pueblo
    {

        //------------------------------------------------------------------------------------------------
        //Atributos

        private string iD;
        private string nombre;
        private string localidad;

        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Pueblo(string iD, string nombre, string localidad)
        {
            this.iD = iD;
            SetNombre(nombre);
            SetLocalidad(localidad);

        }

        public Pueblo()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string GetID()
        {
            return iD;
        }



        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public string GetLocalidad()
        {
            return localidad;
        }

        public void SetLocalidad(string value)
        {
            localidad = value;
        }

        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetPueblo(this, Existe());
        }
        public static Pueblo GetPueblo(string id)
        {
            return Controladores.ConnexionSQL.GetPueblo(id);
        }

        public bool Existe()
        {
            return (GetPueblo(this.iD) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeletePueblo(this);
        }
    }
}
