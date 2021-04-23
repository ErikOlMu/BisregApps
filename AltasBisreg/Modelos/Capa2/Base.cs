using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltasBisreg.Modelos.Capa2
{
    class Base
    {
        //------------------------------------------------------------------------------------------------
        //Atributos

        private string pack;
        private string id;
        private string tipo;
        private string nombre;
        private string familia;
        private string seccion;
        private decimal pv1;
        private decimal pv2;
        private decimal pv3;
        private string atributo;
        private string relAtributo;
        private int pedidoMinimo;

        public string TIPO { get { return tipo; } }
        public string ID { get { return id; } }
        public string DESCRIPCION { get { return nombre ; } }


        //------------------------------------------------------------------------------------------------
        //Constuctores

        public Base(string id, string tipo, string nombre, string familia, string seccion, decimal pv1, decimal pv2, decimal pv3, string atributo, string relAtributo, int pedidoMinimo,string pack = "GENERAL")
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.familia = familia;
            this.seccion = seccion;
            this.pv1 = pv1;
            this.pv2 = pv2;
            this.pv3 = pv3;
            this.atributo = atributo;
            this.relAtributo = relAtributo;
            this.SetpedidoMinimo(pedidoMinimo);
            this.pack = pack;

        }

        public Base(string id, string tipo, string nombre, string familia, string seccion, double pv1, double pv2, double pv3, string atributo, string relAtributo, int pedidoMinimo, string pack = "GENERAL")
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.familia = familia;
            this.seccion = seccion;
            this.pv1 = new decimal(pv1);
            this.pv2 = new decimal(pv2);
            this.pv3 = new decimal(pv3);
            this.atributo = atributo;
            this.relAtributo = relAtributo;
            this.SetpedidoMinimo(pedidoMinimo);
            this.pack = pack;

        }

        public Base() { }


        //------------------------------------------------------------------------------------------------
        //Get and Set
        public string Getpack()
        {
            return pack;
        }
        public int GetpedidoMinimo()
        {
            return pedidoMinimo;
        }
        public void SetpedidoMinimo(int value)
        {
            pedidoMinimo = value;
        }
        public string GetId()
        {
            return id;
        }
        public string GetTipo()
        {
            return tipo;
        }
        public string GetFamilia()
        {
            return familia;
        }
        public void SetFamilia(string value)
        {
            familia = value;
        }
        public string GetSeccion()
        {
            return seccion;
        }
        public void SetSeccion(string value)
        {
            seccion = value;
        }
        public decimal GetPv1()
        {
            return pv1;
        }
        public void SetPv1(decimal value)
        {
            pv1 = value;
        }
        //Sobrecarga con double
        public void SetPV1(double value)
        {
            pv1 = new decimal(value);
        }
        public decimal GetPv2()
        {
            return pv2;
        }
        public void SetPv2(decimal value)
        {
            pv2 = value;
        }
        //Sobrecarga con double
        public void SetPV2(double value)
        {
            pv2 = new decimal(value);
        }
        public decimal GetPv3()
        {
            return pv3;
        }
        public void SetPv3(decimal value)
        {
            pv3 = value;
        }
        //Sobrecarga con double
        public void SetPV3(double value)
        {
            pv3 = new decimal(value);
        }
        public string GetAtributo()
        {
            return atributo;
        }
        public void SetAtributo(string value)
        {
            atributo = value;
        }
        public string GetRelAtributo()
        {
            return relAtributo;
        }
        public void SetRelAtributo(string value)
        {
            relAtributo = value;
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
            Controladores.ConnexionSQL.SetBase(this, Existe());
        }
        public static Base GetBase(string id, string tipo,string pack = "GENERAL")
        {
            Base b = Controladores.ConnexionSQL.GetBase(id, tipo,pack);
            if (b != null)
            {
                return b;
            }
            else
            {
                return Controladores.ConnexionSQL.GetBase(id, tipo, "GENERAL");
            }

        }
        public void Delete()
        {
            if (Existe())
            {
                Controladores.ConnexionSQL.DeleteBase(this);
            }
        }
        public bool Existe()
        {
            //Si la consulta de la base es null no existe
            return (GetBase(this.id, this.tipo,this.pack) != null);
        }



        //retorna todas las composiciones de la base
        public List<Composicion> GetComposiciones()
        {
            return Controladores.ConnexionSQL.GetComposiciones(this);
        }
        public List<Capa3.Tarifa> GetTarifas()
        {
            return Controladores.ConnexionSQL.GetTarifas(this);
        }
        // Obtendra el Calculo del coste a partir de las composiciones
        public decimal GetCoste()
        {
            decimal Coste = 0;

            
                    List<Composicion> lista = GetComposiciones();

                    foreach (Composicion c in lista)
                    {
                        Coste = Coste + ProdComposicion.GetProdComposicion(c.GetID()).GetPrecio() * c.GetCantidad();
                    }
                
            
            return Coste;
        }
        public void tCoste()
        {
            
        }

        public static List<string> GetPacks()
        {
            return Controladores.ConnexionSQL.GetPacks("BASE");
        }
        public static List<Base> GetBases(string pack = "GENERAL")
        {
            return Controladores.ConnexionSQL.GetBases(pack);

        }

    }
}
