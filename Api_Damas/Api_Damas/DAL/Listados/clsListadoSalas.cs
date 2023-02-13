using Api_Damas.Entidades;
using DAL;
using Microsoft.Data.SqlClient;

namespace Api_Damas.DAL.Listados
{
    public class clsListadoSalas
    {
        /// <summary>
        /// Precondiciones: No tiene.
        /// Conecta con la BBDD y saco una lista completa de salas
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una lista con todas las salas.
        /// </summary>
        /// <returns> List de salas. </returns>
        public static List<clsSala> ObtenerListadoCompletoSalasDAL()
        {
            List<clsSala> listadoSalas = new List<clsSala>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsSala miSala;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM FROM Salas";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        miSala = new clsSala();
                        miSala.codSala = miLector.GetInt32(0);
                        miSala.nombreSala = miLector.GetString(1);
                        miSala.cantidadFichasArriba = miLector.GetInt32(2);
                        miSala.cantidadFichasAbajo = miLector.GetInt32(3);
                        miSala.tiempo = miLector.GetInt32(4);
                        miSala.cantidadFichasArriba = miLector.GetInt32(5);
                        miSala.cantidadFichasAbajo = miLector.GetInt32(6);
                        listadoSalas.Add(miSala);
                    }
                }
                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoSalas;
        }

        /// <summary>
        /// Precondiciones: No tiene.
        /// Conecta con la BBDD y saco una lista de salas disponibles de la tabla Salas.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una lista de salas en las que se pueda entrar.
        /// </summary>
        /// <returns> List de salas. </returns>
        //public static List<clsSala> ObtenerListadoSalasDisponiblesDAL()
        //{
        //    List<clsSala> listadoSalas = new List<clsSala>();
        //    clsMyConnection miConexion = new clsMyConnection();
        //    SqlConnection conexion = new SqlConnection();
        //    SqlCommand miComando = new SqlCommand();
        //    SqlDataReader miLector;
        //    clsSala miSala;

        //    try
        //    {
        //        conexion = miConexion.getConnection();
        //        miComando.CommandText = "SELECT * FROM FROM Salas WHERE jugadorArriba = NULL OR jugadorAbajo = NULL";
        //        miComando.Connection = conexion;
        //        miLector = miComando.ExecuteReader();
        //        if (miLector.HasRows)
        //        {
        //            while (miLector.Read())
        //            {
        //                miSala = new clsSala();
        //                miSala.codSala = miLector.GetInt32(0);
        //                miSala.nombreSala = miLector.GetString(1);
        //                miSala.cantidadFichasArriba = miLector.GetInt32(2);
        //                miSala.cantidadFichasAbajo = miLector.GetInt32(3);
        //                miSala.tiempo = miLector.GetInt32(4);
        //                miSala.cantidadFichasArriba = miLector.GetInt32(5);
        //                miSala.cantidadFichasAbajo = miLector.GetInt32(6);
        //                listadoSalas.Add(miSala);
        //            }
        //        }
        //        miLector.Close();
        //        miConexion.closeConnection(ref conexion);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        throw sqlEx;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return listadoSalas;
        //}

        /// <summary>
        /// Precondiciones: Debe recibir el id de una sala.
        /// Busco en la base de datos una sala por su id.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una sala de la BBDD.
        /// </summary>
        /// <param name="Id">Entero que representa el id de la sala a buscar.</param>
        /// <returns> Devuelve una clsSala encontrada por su id. </returns>
        public static clsSala ObtenerSalaPorIdDAL(int id)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsSala miSala = null;

            try
            {
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Salas WHERE codSala = @id";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        miSala = new clsSala();
                        miSala.codSala = miLector.GetInt32(0);
                        miSala.nombreSala = miLector.GetString(1);
                        miSala.cantidadFichasArriba = miLector.GetInt32(2);
                        miSala.cantidadFichasAbajo = miLector.GetInt32(3);
                        miSala.tiempo = miLector.GetInt32(4);
                        miSala.cantidadFichasArriba = miLector.GetInt32(5);
                        miSala.cantidadFichasAbajo = miLector.GetInt32(6);
                    }
                }
                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return miSala;
        }

        /// <summary>
        /// Precondiciones: Debe recibir el id de un jugador.
        /// Busco en la base de datos una sala en la que un jugador haya participado.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una sala de la BBDD.
        /// </summary>
        /// <param name="Id">Entero que representa el id del jugador para obtener sus partidas</param>
        /// <returns> Devuelve una clsSala encontrada por id del jugador de arriba o de abajo. </returns>
        //public static clsSala ObtenerSalaPorJugadorDAL(int id)
        //{
        //    clsMyConnection miConexion = new clsMyConnection();
        //    SqlConnection conexion = new SqlConnection();
        //    SqlCommand miComando = new SqlCommand();
        //    SqlDataReader miLector;
        //    clsSala miSala = null;

        //    try
        //    {
        //        miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
        //        conexion = miConexion.getConnection();
        //        miComando.CommandText = "SELECT * FROM Salas WHERE jugadorArriba = @id OR jugadorAbajo = @id";
        //        miComando.Connection = conexion;
        //        miLector = miComando.ExecuteReader();
        //        if (miLector.HasRows)
        //        {
        //            while (miLector.Read())
        //            {
        //                miSala = new clsSala();
        //                miSala.codSala = miLector.GetInt32(0);
        //                miSala.nombreSala = miLector.GetString(1);
        //                miSala.cantidadFichasArriba = miLector.GetInt32(2);
        //                miSala.cantidadFichasAbajo = miLector.GetInt32(3);
        //                miSala.tiempo = miLector.GetInt32(4);
        //                miSala.cantidadFichasArriba = miLector.GetInt32(5);
        //                miSala.cantidadFichasAbajo = miLector.GetInt32(6);
        //            }
        //        }
        //        miLector.Close();
        //        miConexion.closeConnection(ref conexion);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        throw sqlEx;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return miSala;
        //}
    }
}