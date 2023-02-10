using Api_Damas.Entidades;
using DAL;
using Microsoft.Data.SqlClient;

namespace Api_Damas.DAL.Manejadoras
{
    public class clsManejadoraSalas
    {
        /// <summary>
        /// Descripcion: Recibe un entero que es el codigo de la sala a eliminar y accede a la base de datos para eliminarla. Lanza los errores a la capa superior.
        /// Precondiciones: Deber recibir el codigo de un de una sala.
        /// Postcondiciones: Borra la sala accediendo a la BBDD.
        /// </summary>
        /// <param name="codSala">Entero que representa el codigo de la sala a eliminar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int borrarSalaDAL(int codSala)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@codSala", System.Data.SqlDbType.Int).Value = codSala;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "DELETE FROM Salas WHERE codSala=@codSala";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Descripcion: Recibe una sala ya editada para actualizarla en la base de datos. Lanza los errores a la capa superior.
        /// Precondiciones: Deber recibir el codigo de una sala
        /// Postcondiciones: Edita la sala accediendo a la BBDD.
        /// </summary>
        /// <param name="sala">Sala para editar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int editarSalaDAL(clsSala sala)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@codSala", System.Data.SqlDbType.Int).Value = sala.codSala;
            miComando.Parameters.Add("@nombreSala", System.Data.SqlDbType.VarChar).Value = sala.nombreSala;
            miComando.Parameters.Add("@jugadorArriba", System.Data.SqlDbType.Int).Value = sala.jugadorArriba;
            miComando.Parameters.Add("@jugadorAbajo", System.Data.SqlDbType.Int).Value = sala.jugadorAbajo;
            miComando.Parameters.Add("@tiempo", System.Data.SqlDbType.BigInt).Value = sala.tiempo;
            miComando.Parameters.Add("@cantidadFichasArriba", System.Data.SqlDbType.Int).Value = sala.cantidadFichasArriba;
            miComando.Parameters.Add("@cantidadFichasAbajo", System.Data.SqlDbType.Int).Value = sala.cantidadFichasAbajo;


            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "UPDATE Salas SET nombreSala=@nombreSala, jugadorArriba=@jugadorArriba, jugadorAbajo=@jugadorAbajo, tiempo=@tiempo, fichasArriba=@fichasArriba, fichasAbajo=@fichasAbajo FROM Departamentos WHERE ID=@id";
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
        /// Descripcion: Recibe una sala ya rellena para insertarla en la base de datos. Lanza los errores a la capa superior.
        /// Precondiciones: Debe recibir una sala rellena.
        /// Postcondiciones: Inserta una nueva sala accediendo a la BBDD.
        /// </summary>
        /// <param name="sala">Sala para insertar.</param>
        /// <returns>Entero con el número de filas afectadas si las hay.</returns>
        public static int insertarSalaDAL(clsSala sala)
        {
            int numeroFilasAfectadas = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@codSala", System.Data.SqlDbType.Int).Value = sala.codSala;
            miComando.Parameters.Add("@nombreSala", System.Data.SqlDbType.VarChar).Value = sala.nombreSala;
            miComando.Parameters.Add("@jugadorArriba", System.Data.SqlDbType.Int).Value = sala.jugadorArriba;
            miComando.Parameters.Add("@jugadorAbajo", System.Data.SqlDbType.Int).Value = sala.jugadorAbajo;
            miComando.Parameters.Add("@tiempo", System.Data.SqlDbType.BigInt).Value = sala.tiempo;
            miComando.Parameters.Add("@cantidadFichasArriba", System.Data.SqlDbType.Int).Value = sala.cantidadFichasArriba;
            miComando.Parameters.Add("@cantidadFichasAbajo", System.Data.SqlDbType.Int).Value = sala.cantidadFichasAbajo;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "INSERT INTO Salas VALUES(@nombreSalas, @jugadorArriba, @jugadorAbajo, @tiempo, @cantidadFichasArriba, @cantidadFichasAbajo)";
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