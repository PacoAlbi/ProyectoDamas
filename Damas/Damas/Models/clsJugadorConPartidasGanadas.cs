using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.Models
{
    class clsJugadorConPartidasGanadas : clsJugador
    {
        public int partidasGanadas { get; set; }

		public clsJugadorConPartidasGanadas(String nombre, String password, List<clsSala> partidasJugadas, int partidasGanadas)
		{
			base.nombre=nombre;
			base.password=password;
			base.partidasJugadas=partidasJugadas;
			this.partidasGanadas=partidasGanadas;
		}
	}
}
