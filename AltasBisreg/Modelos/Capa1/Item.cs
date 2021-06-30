using AltasBisreg.Modelos.Capa2;
using AltasBisreg.Modelos.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltasBisreg.Modelos.Capa1
{
    class Item
    {
        private Pueblo pueblo;
        private Base @base;
        private Diseño diseño;
        private string ReferenciaTemporal;



        private Thread thread;


        public string GetReferenciaTemporal()
        {
            return ReferenciaTemporal;
        }
        public void recalular()
        {
            if (ReferenciaTemporal != null)
            {
                SetItem(ReferenciaTemporal);

            }
        }

        public bool Algunnull()
        {
            return (pueblo == null || @base == null || diseño == null);
        }

        //Public Atributos para Grid View
        public string Referencia {

            get { if (Algunnull()) { return ReferenciaTemporal; } else {  return this.GetReferencia(); }; }
            set { SetItem(value); ReferenciaTemporal = value; } 
        }
        public string Descripcion
        {
            get { if (Algunnull()) { return null; } else {
                    return GetDescripcion();
                }

            }
        }



        public string Familia
        {
            //Retorna el nombre de la Familia
            get
            {
                if (Algunnull()) { return null; } 
                else 
                {
                    string r = null;
                    thread = new Thread(
                    () =>
                    {
                        r = Modelos.Capa3.Familia.GetFamilia(this.GetBase().GetFamilia()).GetDescripcion();


                });

                thread.Start();
                thread.Join();
                return r;
            }
            }
        }
        public string Pedido_Minimo
        {
            get
            {
                if (Algunnull()) { return null; } else { return this.GetBase().GetpedidoMinimo().ToString(); }
            }
        }
        public string Localidad
        {
            get
            {
                if (Algunnull()) { return null; } 
                else 
                {
                    string r = null;
                    thread = new Thread(
                    () =>
                    {
                        r = Capa3.Localidad.GetLocalidad(this.GetPueblo().GetLocalidad()).GetNombre();
                    });

                    thread.Start();
                    thread.Join();
                    return r;
                }
            }
        }
        public string Seccion
        {
            get
            {
                if (Algunnull()) { return null; }
                else
                {
                    string r = null;
                    thread = new Thread(
                    () =>
                    {
                        r = Capa3.Seccion.GetSeccion(this.GetBase().GetSeccion()).GetDescripcion();
                    });

                    thread.Start();
                    thread.Join();
                    return r;
                }
            }
        }
        public decimal PV1
        {
            get
            {
                if (Algunnull()) { return 0; } else { return this.GetBase().GetPv1(); }
            }
        }
        public decimal PV2
        {
            get
            {
                if (Algunnull()) { return 0; } else { return this.GetBase().GetPv2(); }
            }
        }
        public decimal PV3
        {
            get
            {
                if (Algunnull()) { return 0; } else { return this.GetBase().GetPv3(); }
            }
        }
        public decimal Precio_Coste
        {
            get
            {

                if (Algunnull()) { return 0; } 
                
                else 
                {
                    decimal r = 0;
                    thread = new Thread(
                    () =>
                    {
                         r = this.GetBase().GetCoste();
                    });
                    thread.Start();
                    thread.Join();
                    return r;
                }
                
            }
        }
        public string Atributo
        {
            get
            {
                if (Algunnull()) { return null; } else { return Capa3.Atributo.GetAtributo(this.@base.GetAtributo()).Getdescripcion(); }
            }
        }
       public string Valor_Atributo
        {
            get
            {
                if (Algunnull()) { return null; } else { return Capa3.RelAtributo.GetRelAtributo(this.GetBase().GetRelAtributo(), this.GetBase().GetAtributo()).GetNombre(); }
            }
        }
        public string Ubicacion
        {
            get
            {
                if (Algunnull()) { return null; } else { return Capa3.Seccion.GetSeccion(this.GetBase().GetSeccion()).GetUbicacion(); }
            }
        }

        public Item(string Referencia)
        {
            SetItem(Referencia);
        }
        public Item(Pueblo pueblo, Base @base, Diseño diseño)
        {
            this.pueblo = pueblo;
            this.@base = @base;
            this.diseño = diseño;

        }
        public Item(string tipo, string pueblo,string @base,string diseño,string pack = "GENERAL")
        {
            this.pueblo = Pueblo.GetPueblo(pueblo);
            this.@base = Base.GetBase(@base, tipo, this.pueblo.GetID());
            this.diseño = Diseño.GetDiseño(diseño, pack);
        }
        public Item()
        {

        }
        public Pueblo GetPueblo()
        {
            return pueblo;
        }

        public void SetPueblo(Pueblo value)
        {
            pueblo = value;
        }


        public Base GetBase()
        {
            return @base;
        }

        public void SetBase(Base value)
        {
            @base = value;
        }


        public Diseño Getdiseño()
        {
            if (diseño != null){
                return diseño;

            }
            else
            {
                return new Diseño();
            }
        }

        public void Setdiseño(Diseño value)
        {
          diseño = value;
            

        }
        public string GetReferencia()
        {

            string Letra = "";
            
            if (@base.GetId().Length == 3 && diseño.GetID().Length == 2)
            {
                Letra = "B";
            }
            if (@base.GetId().Length == 2 && diseño.GetID().Length == 3)
            {
                Letra = "D";
            }
            return @base.GetTipo() + pueblo.GetID() + @base.GetId() + diseño.GetID()+Letra;
        }
        public string GetDescripcion()
        {
            
            return @base.GetNombre().Replace("-p",pueblo.GetNombre()) + diseño.GetDescripcion();

            

        }
        //Introduces una cadena de texto con la referencia y crea el Item
        private void SetItem(string Referencia)
        {
            if (Referencia != null){

                if (Referencia.Length == 11 || Referencia.Length == 9 || Referencia.Length == 15 || Referencia.Length == 16 || Referencia.Length == 17)
                {
                    char[] r = Referencia.ToCharArray();
                    string pueblo;
                    string @base;
                    string tipo;
                    string diseño;

                    tipo = r[0].ToString() + r[1].ToString();
                    pueblo = r[2].ToString() + r[3].ToString() + r[4].ToString();

                    if (Referencia.Length == 11)
                    {
                        if (r[10] == 'D')
                        {

                            //Dos numeros de Base
                            @base = r[5].ToString() + r[6].ToString();
                            //Tres numeros de diseño
                            diseño = r[7].ToString() + r[8].ToString() + r[9].ToString();

                            this.pueblo = Pueblo.GetPueblo(pueblo);
                            this.@base = Base.GetBase(@base, tipo);
                            this.diseño = Diseño.GetDiseño(diseño);
                        }
                        else if (r[10] == 'B')
                        {
                            //Tres numeros de Base
                            @base = r[5].ToString() + r[6].ToString() + r[7].ToString();
                            //Dos numeros de diseño
                            diseño = r[8].ToString() + r[9].ToString();


                            this.pueblo = Pueblo.GetPueblo(pueblo);
                            this.@base = Base.GetBase(@base, tipo);
                            this.diseño = Diseño.GetDiseño(diseño);
                        }
                        else
                        {
                            //Tres numeros de Base
                            @base = r[5].ToString() + r[6].ToString() + r[7].ToString();
                            //Tres numeros de diseño
                            diseño = r[8].ToString() + r[9].ToString() + r[10].ToString();

                            this.pueblo = Pueblo.GetPueblo(pueblo);
                            this.@base = Base.GetBase(@base, tipo);
                            this.diseño = Diseño.GetDiseño(diseño);
                        }
                    }
                    if (Referencia.Length == 9)
                    {

                        //Dos numeros de Base
                        @base = r[5].ToString() + r[6].ToString();
                        //Dos numeros de diseño
                        diseño = r[7].ToString() + r[8].ToString();

                        var Serializador = new Controladores.SerlizadorAlertas();
                        Serializador.GetAlertas();
                        
                        foreach (Alerta a in Serializador.alertas)
                        {
                            if (a.ID == @base && a.TIPO == tipo)
                            {
                                MessageBox.Show(a.ALERTA);
                                break;
                            }
                        }
                        
                        this.pueblo = Pueblo.GetPueblo(pueblo);
                        this.@base = Base.GetBase(@base, tipo);
                        this.diseño = Diseño.GetDiseño(diseño);
                    }
                    
                }
            }
            else
            {
                this.pueblo = null;
                this.@base = null;
                this.diseño = null;
            }

            string hola = "";
            MessageBox.Show(this.pueblo.GetID() + this.@base.GetId() + this.diseño.GetID());
        }
    }
}
