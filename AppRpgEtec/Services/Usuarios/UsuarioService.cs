using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppRpgEtec.Models;
using System.Threading.Tasks;


namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://rpgapi20242pam.azurewebsites.net/Usuarios";

        public UsuarioService() { 
        _request = new Request();

        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplmentar = "/Registrar/";
            u.Id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplmentar, u);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplmentar = "/Autenticar/";
            u = await _request.PostAsync(_apiUrlBase + urlComplmentar, u, string.Empty);
            return u;
        }
    }
}
