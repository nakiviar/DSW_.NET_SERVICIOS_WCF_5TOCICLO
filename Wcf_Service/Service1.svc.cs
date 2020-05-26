using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Wcf_Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public List<Cliente> filtro(string nombre)
        {
            List<Cliente> temporal = new List<Cliente>();
            if (nombre.Trim() == string.Empty)
                return temporal;
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-E659MS0\\SQLEXPRESS;database=Negocios2020;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("Select * from tb_clientes Where nombrecia LIKE @nom", cn);
                cmd.Parameters.AddWithValue("@nom", nombre + "%");
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente()
                    {
                        idcliente = dr.GetString(0),
                        nombrecia = dr.GetString(1),
                        direccion = dr.GetString(2),
                        idpais = dr.GetString(3),
                        telefono = dr.GetString(4)
                    };
                    temporal.Add(c);
                }
                cn.Close();
                dr.Close();
            }
            return temporal;
        }

        public List<Cliente> listado()
        {
            List<Cliente> temporal = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection("server=DESKTOP-E659MS0\\SQLEXPRESS;database=Negocios2020;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("Select * from tb_clientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente()
                    {
                        idcliente = dr.GetString(0),
                        nombrecia = dr.GetString(1),
                        direccion = dr.GetString(2),
                        idpais = dr.GetString(3),
                        telefono = dr.GetString(4)
                    };
                    temporal.Add(c);
                }
                cn.Close();
                dr.Close();
            }
            return temporal;
        }
    }
}
