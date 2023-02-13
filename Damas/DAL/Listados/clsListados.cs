using Entities;
using Newtonsoft.Json;

namespace DAL.Listados
{
	public class clsListados
	{


		/// <summary>
		/// Método que se encarga de recoger un objeto Json
		/// que contiene los datos de todos los jugadores de la base de datos, 
		/// lo convierte en objetos clsJugador, los introduce en una lista 
		/// y la devuelve
		/// 
		/// Precondiciones:
		/// 
		/// Postcondiciones:
		/// </summary>
		/// <returns></returns>
		public async Task<List<clsJugador>> GetJugadores()
		{
			List<clsJugador> jugadors = new List<clsJugador>();
			HttpClient client = new HttpClient();
			string data;
			HttpContent content;
			string urlString = clsUriBase.getUriBase();
			Uri miUri = new($"{urlString}/jugadores");
			HttpResponseMessage miCodigoRespuesta;



			try
			{
				miCodigoRespuesta = await client.GetAsync(miUri);

				if (miCodigoRespuesta.IsSuccessStatusCode)
				{
					data = await client.GetStringAsync(miUri);

					client.Dispose();

					jugadors = JsonConvert.DeserializeObject<List<clsJugador>>(data);


				}
			}
			catch (Exception e)
			{
				throw e;
			}

			return jugadors;
		}



		/// <summary>
		/// Método que se encarga de recoger un objeto Json
		/// que contiene los datos de todos las salas de la base de datos, 
		/// lo convierte en objetos clsSala, los introduce en una lista 
		/// y la devuelve
		/// 
		/// Precondiciones:
		/// 
		/// Postcondiciones:
		/// </summary>
		/// <returns></returns>
		public async Task<List<clsSala>> GetSalas()
		{
			List<clsSala> salas = new List<clsSala>();
			HttpClient client = new HttpClient();
			string data;
			HttpContent content;
			string urlString = clsUriBase.getUriBase();
			Uri miUri = new($"{urlString}/salas");
			HttpResponseMessage miCodigoRespuesta;



			try
			{
				miCodigoRespuesta = await client.GetAsync(miUri);

				if (miCodigoRespuesta.IsSuccessStatusCode)
				{
					data = await client.GetStringAsync(miUri);

					client.Dispose();

					salas = JsonConvert.DeserializeObject<List<clsSala>>(data);


				}
			}
			catch (Exception e)
			{
				throw e;
			}

			return salas;
		}





		public async Task<clsSala> GetSala(int id)
		{
			clsSala sala = new clsSala();
			HttpClient client = new HttpClient();
			string data;
			HttpContent content;
			string miUri = clsUriBase.getUriBase();
			Uri uri = new($"{miUri}/salas/{id}");

			HttpResponseMessage miCodigoRespuesta;

			try
			{
				miCodigoRespuesta= await client.GetAsync(uri);
				if (miCodigoRespuesta.IsSuccessStatusCode)
				{
					data = await client.GetStringAsync(uri);
					client.Dispose();
					sala = JsonConvert.DeserializeObject<clsSala>(data);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return sala;
		}




		/// <summary>
		/// Método que se encarga de recoger un registro de la tabla jugadores de k
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<clsJugador> GetJugador(int id)
		{

			clsJugador jugador = new clsJugador();
			HttpClient client = new HttpClient();
			string data;
			HttpContent content;
			string miUri = clsUriBase.getUriBase();
			Uri uri = new($"{miUri}/jugadores/{id}");

			HttpResponseMessage miCodigoRespuesta;

			try
			{
				miCodigoRespuesta= await client.GetAsync(uri);
				if (miCodigoRespuesta.IsSuccessStatusCode)
				{
					data = await client.GetStringAsync(uri);
					client.Dispose();
					jugador = JsonConvert.DeserializeObject<clsJugador>(data);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return jugador;
		}
	}
}
