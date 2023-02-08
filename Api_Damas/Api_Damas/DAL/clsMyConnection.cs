using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsMyConnection
    {
        #region Atributos
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        #endregion
        #region Constructores
        public clsMyConnection()
        {
            this.server = "falbinana.database.windows.net";
            this.dataBase = "PacoBBDD";
            this.user = "falbinana";
            this.pass = "Mandaloriano69";
        }
        public clsMyConnection(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }
        #endregion
        #region Métodos
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};Trust Server Certificate = true;";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }
            return connection;
        }
        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}