using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class Seccion
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string iD;
        private string descripcion;
        private string ubicacion;

        public string ID { get { return iD; } set { iD = value; } }
        public string NOMBRE { get { return descripcion; } set { descripcion = value; } }

        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Seccion(string iD, string descripcion, string ubicacion)
        {
            this.ID = iD;
            this.descripcion = descripcion;
            this.ubicacion = ubicacion;

        }

        public Seccion()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set
        public string GetUbicacion()
        {
            return ubicacion;
        }

        public void SetUbicacion(string value)
        {
            ubicacion = value;
        }
        public string GetID()
        {
            return ID;
        }

        public string GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(string value)
        {
            descripcion = value;
        }

        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetSeccion(this, Existe());
        }
        public static Seccion GetSeccion(string id)
        {
            return Controladores.ConnexionSQL.GetSeccion(id);
        }
        
        public bool Existe()
        {
            return (GetSeccion(this.ID) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteSeccion(this);
        }
    }
}
