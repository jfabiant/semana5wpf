using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProducto
    {

        public List<Producto> Get()
        {
            string commandText = string.Empty;
            List<Producto> productosList = null;

            try
            {
                commandText = "USP_GetProducto";
                productosList = new List<Producto>();
                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText, CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        productosList.Add(new Producto
                        {
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreproducto"] != null ? Convert.ToString(reader["nombreproducto"]) : string.Empty,
                            NombreCompañia = reader["nombrecompañia"] != null ? Convert.ToString(reader["nombrecompañia"]) : string.Empty,
                            NombreCategoria = reader["nombrecategoria"] != null ? Convert.ToString(reader["nombrecategoria"]) : string.Empty,
                            CantidadPorUnidad = reader["cantidadporunidad"] != null ? Convert.ToString(reader["cantidadporunidad"]) : string.Empty,
                            PrecioUnidad = reader["preciounidad"] != null ? Convert.ToDouble(reader["preciounidad"]) : 0,
                            UnidadesEnExistencia = reader["unidadesenexistencia"] != null ? Convert.ToInt32(reader["unidadesenexistencia"]) : 0,
                            UnidadesEnPedido = reader["unidadesenpedido"] != null ? Convert.ToInt32(reader["unidadesenpedido"]) : 0,
                            NivelNuevoPedido = reader["nivelnuevopedido"] != null ? Convert.ToInt32(reader["nivelnuevopedido"]) : 0,
                            Suspendido = reader["suspendido"] != null ? Convert.ToInt32(reader["suspendido"]) : 0,
                            CategoriaProducto = reader["categoriaproducto"] != null ? Convert.ToString(reader["categoriaproducto"]) : string.Empty
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return productosList;
        }

        public Boolean Insert (Producto producto)
        {
            bool itsok;

            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[9];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@cantidadporunidad", SqlDbType.VarChar);
                parameters[2].Value = producto.CantidadPorUnidad;
                parameters[3] = new SqlParameter("@preciounidad", SqlDbType.Decimal);
                parameters[3].Value = producto.PrecioUnidad;
                parameters[4] = new SqlParameter("@unidadesenexistencia", SqlDbType.SmallInt);
                parameters[4].Value = producto.UnidadesEnExistencia;
                parameters[5] = new SqlParameter("@unidadesenpedido", SqlDbType.SmallInt);
                parameters[5].Value = producto.UnidadesEnPedido;
                parameters[6] = new SqlParameter("@nivelnuevopedido", SqlDbType.SmallInt);
                parameters[6].Value = producto.NivelNuevoPedido;
                parameters[7] = new SqlParameter("@suspendido", SqlDbType.SmallInt);
                parameters[7].Value = producto.Suspendido;
                parameters[8] = new SqlParameter("@categoriaproducto", SqlDbType.VarChar);
                parameters[8].Value = producto.CategoriaProducto;

                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
                itsok = true;
            }
            catch (Exception ex)
            {
                itsok = false;
                throw ex;
            }
            return itsok;
        }
    }
}
