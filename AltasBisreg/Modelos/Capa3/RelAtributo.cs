using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class RelAtributo
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string id;
        private string atributo;
        private string nombre;

        //------------------------------------------------------------------------------------------------
        //Constuctores


        public string ID
        {
            get { return id; }
        }
        public string NOMBRE
        {
            get { return nombre; }
        }

        public RelAtributo(string id, string atributo, string nombre)
        {
            this.id = id;
            this.atributo = atributo;
            this.nombre = nombre;

        }

        public RelAtributo()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string Getid()
        {
            return id;
        }


        public string Getatributo()
        {
            return atributo;
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
            Controladores.ConnexionSQL.SetRelAtributo(this, Existe());
        }
        public static RelAtributo GetRelAtributo(string id, string atributo)
        {
            return Controladores.ConnexionSQL.GetRelAtributo(id, atributo);
        }

        public bool Existe()
        {
            return (GetRelAtributo(this.id, this.atributo) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteRelAtributo(this);
        }
    }
}
