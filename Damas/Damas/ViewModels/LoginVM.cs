using Damas.ViewModels.Utilidades;
using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas.ViewModels
{
    public class LoginVM : clsVMBase
    {
        #region Atributos

        private string _username;
        private string _password;
        private DelegateCommand _comandoLogin;

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
            // navegar a la siguiente pagina
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

        #endregion
    }
}
