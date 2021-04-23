using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using System.Collections;
using iTextSharp.text.pdf;

namespace Catalogos_Bisreg_WinForms
{

    class Item
    {


        //Diccionario de Valores
        public ArrayList Valores = new ArrayList();

        //Referencia del Item
        public string Referencia;


        // Constuctor
        public Item()
        {

        }
        public Item(string Referencia)
        {
            this.Referencia = Referencia;
        }

        //Metodo para añadir Campos con su valor al Item
        public void addCampo(string Valor)
        {
            Valores.Add(Valor);
            
        }

        //Metodo Para Obtener el Valor de un campo
        public string getValor(string Campo)
        {
            return null;

        }



    }
}


