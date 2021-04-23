using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa2
{
    class Diseño
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string id;
        private string descripcion;
        private string pack;
        
        //Publicos para el Grid

            public string ID { get { return id; } }
            public string DESCRIPCION { get { return descripcion; } }

        //------------------------------------------------------------------------------------------------
        //Constuctores
        public Diseño(string id, string descripcion,string pack = "GENERAL")
        {
            this.id = id;
            SetDescripcion(descripcion);
            this.pack = pack;
        }

        public Diseño()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set
        public string Getpack()
        {
            return pack;
        }
        public void SetPack(string pack)
        {
            this.pack = pack;
        }
        public string GetID()
        {
            return id;
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
            Controladores.ConnexionSQL.SetDiseño(this, Existe());
        }
        public static Diseño GetDiseño(string id,string pack = "GENERAL")
        {
            if (Controladores.ConnexionSQL.GetDiseño(id, pack) == null)
            {
                return Controladores.ConnexionSQL.GetDiseño(id, "GENERAL");
            }
            else
            {
                return Controladores.ConnexionSQL.GetDiseño(id, pack);
            }
        }

        public bool Existe()
        {
            //Si la consulta de la base es null no existe
            return (Controladores.ConnexionSQL.GetDiseño(id, pack) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteDiseño(this);
        }


        public static List<string> GetPacks()
        {
            return Controladores.ConnexionSQL.GetPacks("DISEÑO");
        }


        public static List<Diseño> GetDiseños(string pack = "GENERAL")
        {
            return Controladores.ConnexionSQL.GetDiseños(pack);
        }

    }
}
