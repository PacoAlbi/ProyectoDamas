using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class clsJugador
	{

		#region Attributes
		private String _nombre;

		private String _password;

		// private List<clsSala> _partidasJugadas; consulta con inner join ¿?

		#endregion

		#region Properties

		public String nombre { get { return _nombre; } set { _nombre = value; } }

		public String password { get { return _password; } set { _password = value; } }

		public List<clsSala> partidasJugadas { get { return _partidasJugadas; } set { _partidasJugadas = value; } }

		#endregion

		#region Constructors

		public clsJugador() { }

		public clsJugador(string _nombre, string _password, List<clsSala> _partidasJugadas)
		{
			nombre=_nombre;
			password=_password;
			partidasJugadas=_partidasJugadas;
		}






		#endregion
	}
}
