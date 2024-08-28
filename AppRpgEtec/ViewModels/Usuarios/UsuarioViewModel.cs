using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModels
    {
        private UsuarioService _uService;
        public ICommand AutenticarCommand { get; set; }

        public UsuarioViewModel()
        {
            _uService = new UsuarioService();
            InicializarCommands();
        }

            public void InicializarCommands() {
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
             }

        #region AtributoPropriedades
        private string login = string.Empty;
        private string senha = string.Empty;

        //CTRL +R+E
        

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }


        
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public async Task AutenticarUsuario()
        {
            try
            {


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("informação", ex.Message + "Detalhes:" + ex.InnerException, "ok");
            }

            Usuario u = new Usuario();
            u.Username = login;
            u.PasswordString = senha;
            Usuario uAutenticado = await _uService.PostAutenticarUsuarioAsync(u);
            if (!string.IsNullOrEmpty(u.Token))
            {
                string mensagem = $"bem vindo { u.Username}";
                Preferences.Set("UsuarioToken", uAutenticado.Token);
                Preferences.Set("UsuarioId", uAutenticado.Id);
                Preferences.Set("UsuarioUsername", uAutenticado.Username);
                Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);


                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Dados Incorretos", "OK");
            }
        }
    }
}
