using Damas.Models;
using Entities;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.ViewModels
{
	partial class GameVM : VMBase
	{

		clsGameTablero tablero;

		clsJugador jugadorArriba;
		clsJugador jugadorAbajo;

		[ObservableProperty]
		Square huecoSeleccionado; 



		[ICommand]
		public void GetPosiblePosicion(int i, int j)
		{
			if(HuecoSeleccionado != null)
			{

			}
		}
	}


	public enum EstadosJuego
	{
		TurnoBlancas, 
		TurnoNegras,
		BlancasMoviendo, 
		NegrasMoviendo,
		NegroGana,
		BlancoGana
	}
}
