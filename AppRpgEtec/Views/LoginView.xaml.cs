using AppRpgEtec.ViewModels.Usuarios;

namespace AppRpgEtec.Views;

public partial class LoginView : ContentPage
{
	UsuarioViewModel _usuarioViewModel;
	public LoginView()
	{
		InitializeComponent();
		_usuarioViewModel = new UsuarioViewModel();
		BindingContext = _usuarioViewModel;
	}
}