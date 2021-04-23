using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa3
{
    class Tarifa
    {
        //------------------------------------------------------------------------------------------------
        //Atributos
        private string iD;
        private string @base;
        private string tipo;
        private decimal precio;
        private string pack;
        public string ID { get { return iD; }  }
        public decimal PRECIO { get { return precio; } set { precio = value; Save(); } }


        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Tarifa()
        {

        }

        public Tarifa(string iD, string @base, string tipo, decimal precio,string pack)
        {
            this.pack = pack;
            this.iD = iD;
            this.@base = @base;
            this.tipo = tipo;
            this.precio = precio;
        }


        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string GetID()
        {
            return iD;
        }

        public void SetID(string value)
        {
            iD = value;
        }

        

        public string GetBase()
        {
            return @base;
        }

        public void SetBase(string value)
        {
            @base = value;
        }

        

        public string GetTipo()
        {
            return tipo;
        }

        public void SetTipo(string value)
        {
            tipo = value;
        }


        public decimal GetPrecio()
        {
            return precio;
        }

        public void SetPrecio(decimal value)
        {
            precio = value;
        }
        public string Getpack()
        {
            return pack;
        }
        public void Setpack(string pack)
        {
            this.pack = pack;
        }

        //------------------------------------------------------------------------------------------------
        //Metodos
        public void Save()
        {
            Controladores.ConnexionSQL.SetTarifa(this, Existe());
        }
        public static Tarifa GetTarifa(string ID, string BASE, string TIPO, string pack)
        {
            return Controladores.ConnexionSQL.GetTarifa(ID, BASE,  TIPO, pack);
        }

        public bool Existe()
        {
            return (GetTarifa(this.iD, this.@base ,this.tipo,this.pack) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteTarifa(this);
        }

    }
}
