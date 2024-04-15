/*
 * Descripción: Clase de conexion a la base de datos.
 * Autor: Marcelo H
 * Fecha creación: 15-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 * 15-04-2024       Marcelo H          Leves correcciones en el codigo.
 */
using System.Data.SqlClient;

namespace Prueba_Backend.Modelo.BDD
{
    public class ConexionSql
    {
        string cadCon = "Data source=DEVCL-JOSEFA;initial catalog=Prueba;persist security info=True;user id=aspnet;password=123;";
        SqlConnection conexion;
    

        private void conectarBD()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = cadCon;
            conexion.Open();
        }

        private void descontectarBD()
        {
            conexion.Close();
        }

    }
}

// SqlConnection conn = new SqlConnection("Data source=DEVCL-JOSEFA;initial catalog=Prueba;persist security info=True;user id=aspnet;password=123;");
