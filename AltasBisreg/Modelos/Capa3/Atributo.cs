using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class Atributo
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string id;
        private string descripcion;

        public string ID { get { return id; } set { id = value; } }
        public string NOMBRE { get { return descripcion; } set { descripcion = value; } }
        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Atributo(string id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public Atributo()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string Getid()
        {
            return id;
        }



        public string Getdescripcion()
        {
            return descripcion;
        }
        public void Setdescripcion(string value)
        {
            descripcion = value;
        }

        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetAtributo(this,Existe());
        }
        public bool Existe()
        {
            return (GetAtributo(this.id) != null);
        }
        public static Atributo GetAtributo(string id)
        {
            return Controladores.ConnexionSQL.GetAtributo(id);
        }
        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteAtributo(this);
        }
        public List<RelAtributo> GetRelaciones()
        {
            return Controladores.ConnexionSQL.GetRelaciones(this);
        }
    }
}
