using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.Models
{
	public class clsPieza
	{
		public enum Color
		{
			Blanco,
			Negro
		}
		public enum Tipo
		{
			Normal,
			Reina	
		}

		public class Pieza
		{
			public Color colorPieza { get; set; }
			public Tipo tipoPieza { get; set; }
		}

	}
}
