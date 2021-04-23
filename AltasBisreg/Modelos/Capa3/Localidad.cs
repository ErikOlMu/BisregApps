using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class Localidad
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string iD;
        private string nombre;


        public string ID{ get { return iD; } set { iD = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Localidad(string iD, string nombre)
        {
            this.iD = iD;
            SetNombre(nombre);

        }

        public Localidad()
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

        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetLocalidad(this, Existe());
        }
        public static Localidad GetLocalidad(string id)
        {
            return Controladores.ConnexionSQL.GetLocalidad(id);
        }

        public bool Existe()
        {
            return (GetLocalidad(this.iD) != null);
        }
        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteLocalidad(this);
        }
    }
}
