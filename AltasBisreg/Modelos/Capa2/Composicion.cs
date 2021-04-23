using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa2
{
    class Composicion
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string id;
        private string @base;
        private string tipo;
        private decimal cantidad;

        public string ID { get { return id; } set { Delete(); id = value; Save(); } }

        public string DESCRIPCION { get { return ProdComposicion.GetProdComposicion(id).GetDescripcion(); } }
        public string CANTIDAD { get { return cantidad.ToString(); } 
            set {
                cantidad = Convert.ToDecimal(value);
                Save(); }
        }

        public string PRECIO { get { return ProdComposicion.GetProdComposicion(id).GetPrecio().ToString(); } }
        public string PRECIO_KIT
        {
            get
            {
                return (ProdComposicion.GetProdComposicion(id).GetPrecio() * cantidad).ToString();
            }
        }
        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Composicion(string id, string @base, string tipo, decimal cantidad)
        {
            this.id= id;
            this.@base= @base;
            this.tipo = tipo;
            SetCantidad(cantidad);


        }
        public Composicion(string id, string @base, string tipo, double cantidad)
        {
            this.id = id;
            this.@base = @base;
            this.tipo = tipo;
            SetCantidad(cantidad);


        }
        public Composicion(string id)
        {

            this.id = id;
            this.@base = "";
            this.tipo = "";
            this.cantidad = 0;
            
        }
        public Composicion()
        {
        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string GetID()
        {
            return id;
        }




        public string GetBase()
        {
            return @base;
        }


        public string GetTipo()
        {
            return tipo;
        }


        public decimal GetCantidad()
        {
            return cantidad;
        }

        public void SetCantidad(decimal value)
        {

            cantidad = value;
        }
        //Sobrecarga con double
        public void SetCantidad(double value)
        {

            cantidad = new decimal(value);
        }



        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetComposicion(this, Existe());
        }

        public ProdComposicion GetProdComposicion()
        {
            return Controladores.ConnexionSQL.GetProdComposicion(GetID());
        }

        public static Composicion GetComposicion(string ID, string @base, string tipo)
        {
            return Controladores.ConnexionSQL.GetComposicion(ID, @base, tipo);
        }

        public bool Existe()
        {
            //Si la consulta de la base es null no existe
            return (GetComposicion(this.id, this.@base,this.tipo) != null);
        }
        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteComposicion(this);
        }

    }
}