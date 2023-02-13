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
			List<clsJugador> jugadors= new List<clsJugador>();
			HttpClient client = new HttpClient();
			string data;
			HttpContent content;
			string urlString = clsUriBase.getUriBase();
			Uri miUri = new($"{urlString}/jugadores");
			HttpResponseMessage miCodigoRespuesta;



			try
			{
				miCodigoRespuesta = await client.GetAsync(miUri);

				if(miCodigoRespuesta.IsSuccessStatusCode)
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
	}
}
