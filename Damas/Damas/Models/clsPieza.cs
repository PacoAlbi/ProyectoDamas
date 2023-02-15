using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.Models
{
	public class clsPieza
	{

			public Color colorPieza { get; set; }
			public Tipo tipoPieza { get; set; }

		public clsPieza(Color colorP, Tipo tipo)
		{
			colorPieza = colorP;
			tipoPieza = tipo;
		}

		public clsPieza(Color colorP)
		{
			colorPieza = colorP;
			tipoPieza = Tipo.Normal;
		}

	}

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

}
