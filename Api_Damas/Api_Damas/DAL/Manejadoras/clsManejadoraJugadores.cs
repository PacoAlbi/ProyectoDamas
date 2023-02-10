using Api_Damas.Entidades;
using DAL;
using Microsoft.Data.SqlClient;

namespace Api_Damas.DAL.Manejadoras
{
    public class clsManejadoraJugadores
    {
        /// <summary>
        /// Descripcion: Recibe un entero que es el id de el jugador a eliminar y accede a la base de datos para eliminarlo. Lanza los errores a la capa superior.
        /// Precondiciones: Deber recibir la id de un jugador.
        /// Postcondiciones: Borra la persona accediendo a la BBDD.
        /// </summary>
        /// <param name="idJugador">Entero que es el ID de el jugador.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int borrarJugadorDAL(int idJugador)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = idJugador;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "DELETE FROM Jugadores WHERE idJugador=@idJugador";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Descripcion: Recibe un Jugador ya editado para actualizarlo en la base de datos. Lanza los errores a la capa superior.
        /// Precondiciones: Deber recibir la id de un jugador.
        /// Postcondiciones: Edita al Jugador accediendo a la BBDD.
        /// </summary>
        /// <param name="jugador">Persona para editar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int editarJugadorDAL(clsJugador jugador)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = jugador.idJugador;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = jugador.nombre;
            miComando.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = jugador.password;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "UPDATE Personas SET nombre=@nombre, password=@password";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Descripcion: Recibe un jugador ya relleno para insertarlo en la base de datos. Lanza los errores a la capa superior.
        /// Precondiciones: Debe reciibir un jugador relleno.
        /// Postcondiciones: Inserta un nuevo jugador accediendo a la BBDD.
        /// </summary>
        /// <param name="jugador">Persona para insertar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int insertarJugadorDAL(clsJugador jugador)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = jugador.idJugador;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = jugador.nombre;
            miComando.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = jugador.password;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "INSERT INTO Jugadores VALUES(@nombre,@password)";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return numeroFilasAfectadas;
        }
    }
}
