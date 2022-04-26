using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UniversalSerializerLib3;
namespace BisregApi.Utilidades
{
    //Clase para guardar los perfiles de catalogos en archivos binarios

    public class PerfilCatalogo
    { 
        public string NombrePerfil { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public double Ancho { get; set; }
        public double Alto { get; set; }
        public List<CampoCanvas> CamposPerfil { get; set; } = new List<CampoCanvas> { };
        public static PerfilCatalogo GetPerfilCatalogo(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            try
            {
                UniversalSerializer formatter = new UniversalSerializer(fs);
                return (PerfilCatalogo)formatter.Deserialize();
            }
            catch (SerializationException e)
            {
                return new PerfilCatalogo();
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public static int SavePerfilCatalogo(PerfilCatalogo perfil, string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create);

            UniversalSerializer formatter = new UniversalSerializer(fs);

            int ok = -1;
            try
            {
                formatter.Serialize(perfil);
                ok = 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                fs.Close();
            }
            return ok;

        }
    }
}
