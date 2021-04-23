using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using AltasBisreg.Modelos.Capa2;
namespace AltasBisreg.Modelos.Capa1
{
    class Documento
    {
        private List<Item> items = new List<Item>();
        public Documento()
        {

        }
        public void addItem(Item item)
        {
            items.Add(item);
        }


        //Mira si el index es correcto i develve el item
        public Item getItem(int index)
        {
            if (index < items.Count)
            {
                return items[index];
            }
            return null;
        }
        public List<Item> GetListItems()
        {
            return items;
        }

        public void RecalcularDiseños(string pack)
        {
            foreach(Item i in items)
            {
                Diseño d = Diseño.GetDiseño(i.Getdiseño().GetID(), pack);
                if (d != null)
                {
                    i.Setdiseño(d);
                }
            }
        }
        
    }

    
}
