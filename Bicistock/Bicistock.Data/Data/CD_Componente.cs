﻿using System.Data;
using System.Data.SqlClient;

namespace Bicistock.Data.Data
{
    public class CD_Componente
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable MostrarComponentes()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarComponentes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void InsertarComponente(string nombreComponente, int idComponente, string rutaImagen)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "CrearComponente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreComponente", nombreComponente);
            comando.Parameters.AddWithValue("@idmarca", idComponente);
            comando.Parameters.AddWithValue("@rutaImagen", rutaImagen);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


    }
}
