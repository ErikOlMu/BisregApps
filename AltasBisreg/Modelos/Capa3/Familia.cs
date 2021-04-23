using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class Familia
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string iD;
        private string descripcion;


        public string ID { get { return iD; } set { iD = value; } }
        public string NOMBRE { get { return descripcion; } set { descripcion = value; } }
        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Familia(string iD, string descripcion)
        {
            this.iD = iD;
            SetDescripcion(descripcion);

        }

        public Familia()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string GetID()
        {
            return iD;
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
            Controladores.ConnexionSQL.SetFamilia(this, Existe());
        }
        public static Familia GetFamilia(string id)
        {
            return Controladores.ConnexionSQL.GetFamilia(id);
        }

        public bool Existe()
        {
            return (GetFamilia(this.iD) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteFamilia(this);
        }
    }
}
