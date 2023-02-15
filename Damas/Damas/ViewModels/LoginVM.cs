using Damas.ViewModels.Utilidades;
using Entities;
using Microsoft.Toolkit.Mvvm.ComponentModel;
namespace Damas.ViewModels
{
    public class LoginVM : clsVMBase
    {
        #region Atributos

        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        private DelegateCommand _comandoLogin;
		private DelegateCommand _comandoSignup;

		#endregion

		#region Propiedades

		public string username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        public string password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand ComandoLogin
        {
            get
            {
                _comandoLogin = new DelegateCommand(ComandoLogin_Execute, ComandoLogin_CanExecute);
                return _comandoLogin;
            }
        }

		public DelegateCommand ComandoSignup
		{
			get
			{
				_comandoSignup = new DelegateCommand(ComandoSignup_Execute, ComandoSignup_CanExecute);
				return _comandoSignup;
			}
		}

		#endregion

		#region Constructores

		public LoginVM()
        {
            _username = null;
            _password = null;
        }

        #endregion

        #region Comandos

        /// <summary>
        /// Metodo que se acciona al pulsar el boton de Log in, cuando se pulse, navegaremos hacia la siguiente pagina
        /// </summary>
        private void ComandoLogin_Execute()
        {
            clsJugador player = new(username, password);

            var dict = new Dictionary<string, object>();
            dict.Add("jugador", player);


            Shell.Current.GoToAsync("Main", true, dict);

        }

        /// <summary>
        /// Metodo que comprueba si el nombre y el usuario estan vacios para activar el boton de logeo o no
        /// </summary>
        /// <returns> bool </returns>
        private bool ComandoLogin_CanExecute()
        {
            bool botonLogin = true;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {

                botonLogin = false;

            }

            return botonLogin;
        }

		/// <summary>
		/// Metodo que se acciona al pulsar el boton de Log in, cuando se pulse, navegaremos hacia la siguiente pagina
		/// </summary>
		private void ComandoSignup_Execute()
		{
			clsJugador player = new(username, password);

			var dict = new Dictionary<string, object>();
			dict.Add("jugador", player);


			Shell.Current.GoToAsync("Main", true, dict);

		}

		/// <summary>
		/// Metodo que comprueba si el nombre y el usuario estan vacios para activar el boton de logeo o no
		/// </summary>dddddd
		/// <returns> bool </returns>
		private bool ComandoSignup_CanExecute()
		{
			bool botonSignUp = true;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{

				botonSignUp = false;

			}

			return botonSignUp;
		}

		#endregion

		#region Utilities

//		private bool TestLogin()
  //      {
    //        
    //
    //
      //  }
      //
        //private clsJugador TestSignUp()
        //{

        //}
		#endregion
	}
}
