﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.ViewModels
{
	partial class VMBase : ObservableObject
	{
		/// <summary>
		/// ViewModel Base con la herencia de ObservableObject del CommunityToolkit
		/// Esto hace que se implemente ayutomáticamente la interfaz INotifyPropertyChanged
		/// de una forma mucho más sencilla.
		/// 
		/// Tambiñén autogenera las propiedades públicas con la implementacion de NotifyPropertyChanged, lo que hace los bindings un poco más sencillos
		/// </summary>
		public partial class clsVMBase : ObservableObject
		{

			//Cuando se notifique el cambio de IsBusy tambien se notificará el de IsNotBusy
			[ObservableProperty]
			[AlsoNotifyChangeFor(nameof(IsNotBusy))]
			//atributo que comprueba si se ha llamado, en la vista, a algúna acción del viewModel
			private bool isBusy;

			[ObservableProperty]
			//título de la página
			private string title;


			public clsVMBase()
			{
			}


			//Propiedad que toma el valor contrario al atributo que comprueba si se ha llamado, en la vista, a algúna acción del viewModel
			public bool IsNotBusy => !IsBusy;



			#region Commands

			#endregion


		}
	}
}
