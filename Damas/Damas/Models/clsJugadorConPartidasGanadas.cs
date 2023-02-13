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
        public List<clsSala> partidas{ get; set; }

		public clsJugadorConPartidasGanadas(String nombre, String password, List<clsSala> partidasJugadas)
		{
			base.nombre=nombre;
			base.password=password;
			partidas=partidasJugadas;
		}
	}
}
