using Damas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Damas.Models.Color;

namespace Damas.ViewModels
{
	partial class clsGameTablero : VMBase
	{
		public const int FILAS = 8;
		public const int COLUMNAS = 8;


		public List<Square> Huecos = new List<Square>();






		clsPieza[] piezasBlancas = new clsPieza[8];
		clsPieza[] piezasNegras = new clsPieza[8];




		void SetUpPiezas()
		{
			for (int i = 1; i <=8; i++)
			{
				for (int j = 1; j <= 8; j++)
				{

					if (i < 4)
					{
						if ((i%2!=0 && j%2!=0) || (i%2==0 && j%2==0))
							Huecos.Add(new Square(i, j, new clsPieza(Color.Blanco)));
					}
					else if (i > 5 && i < 9)
					{
						if ((i%2!=0 && j%2!=0) || (i%2==0 && j%2==0))
							Huecos.Add(new Square(i, j, new clsPieza(Color.Negro)));
					}

				}

			}
		}


		public clsGameTablero()
		{
			SetUpPiezas();
		}






	}

}

