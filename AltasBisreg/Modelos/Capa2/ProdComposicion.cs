using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa2
{
    class ProdComposicion
    {

        //------------------------------------------------------------------------------------------------
        //Atributos

        private string id;
        private string descripcion;
        private decimal precio;

        //------------------------------------------------------------------------------------------------
        //Constuctores

        public ProdComposicion(string id, string descripcion, decimal precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;

        }
        public ProdComposicion(string id, string descripcion, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = new decimal(precio);

        }
        public ProdComposicion()
        {

        }

        //------------------------------------------------------------------------------------------------
        //Get and Set

        public string GetId()
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


        public decimal GetPrecio()
        {
            return precio;
        }

        
        
        public void SetPrecio(decimal value)
        {
            precio = value;
        }
        //Sobrecarga con double
        public void SetPrecio(double value)
        {
            precio = new decimal(value);
        }

        //------------------------------------------------------------------------------------------------
        //Metodos

        public void Save()
        {
            Controladores.ConnexionSQL.SetProdComposicion(this, Existe());
        }

        public static ProdComposicion GetProdComposicion(string ID)
        {
            return Controladores.ConnexionSQL.GetProdComposicion(ID);
        }

        public bool Existe()
        {
            return (GetProdComposicion(this.id) != null);
        }

        public void Delete()
        {
            Controladores.ConnexionSQL.DeleteProdComposicion(this);
        }
    }
}
