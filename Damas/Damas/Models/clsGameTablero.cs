using Damas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.ViewModels
{
	partial class clsGameTablero : VMBase
	{
		public const int FILAS = 8;
		public const int COLUMNAS = 8;
		

		public 


		clsPieza[] piezasBlancas = new clsPieza[8];
		clsPieza[] piezasNegras = new clsPieza[8];

		

		
		void SetUpPiezas()
		{
			foreach(var p in piezasBlancas)
			{
				
			}
		}


		public clsGameTablero() {
		}

	}
}
