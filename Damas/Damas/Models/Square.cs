using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.Models
{
	public class Square
	{
		int _posX;
		int _posY;

		
		bool _esPosibleMover;




		public bool esPosibleMover { get { return _esPosibleMover; } set { _esPosibleMover = value; } }
		public int posX { get { return _posX; } set { _posX = value; } }
		public int posY { get { return _posY; } set { _posY = value; } }


		public clsPieza pieza { get; set; }


		//Constructor para insertar directamente una pieza.
		public Square(int posX, int posY, clsPieza pieza)
		{
			this.posX=posX;
			this.posY=posY;
			this.pieza=pieza;
		}


		//Constructor para insertar un square sin pieza.
		public Square(int posX, int posY)
		{
			this.posX=posX;
			this.posY=posY;
			this.pieza = null;
		}


	}
}
