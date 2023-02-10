using Api_Damas.Entidades;
using DAL;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Api_Damas.DAL.Listados
{
    public class clsListadoJugadores
    {
        /// <summary>
        /// Precondiciones: No tiene.
        /// Conecta con la BBDD y obtenemos una lista de jugadores de la tabla Jugadores.
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve una lista de jugadores de la BBDD.
        /// </summary>
        /// <returns>List de personas.</returns>
        public static List<clsJugador> ObtenerListadoJugadoresDAL()
        {
            List<clsJugador> listaJugadores = new List<clsJugador>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsJugador miJugador;
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Jugadores";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        miJugador = new clsJugador();
                        miJugador.nombre = (string)miLector["nombre"];
                        miJugador.password = (string)miLector["password"];
                        listaJugadores.Add(miJugador);
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
            return listaJugadores;
        }

        /// <summary>
        /// Precondiciones: Debe recibir el id de una persona.
        /// Busco en la base de datos a un jugador pasando el id como parámetro
        /// Lanza los errores a la capa superior.
        /// Postcondiciones: Devuelve un jugador de la BBDD.
        /// </summary>
        /// <param name="id">Entero que representa el id de la persona a buscar.</param>
        /// <returns> Devuelve un clsJugador encontrado por su id. </returns>
        public static clsJugador ObtenerJugadorPorIdDAL(int id)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsJugador miJugador = null;
            try
            {
                miComando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Jugadores WHERE id = @id";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        miJugador = new clsJugador();
                        miJugador.nombre = (string)miLector["nombre"];
                        miJugador.password = (string)miLector["password"];
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
            return miJugador;
        }
    }
}