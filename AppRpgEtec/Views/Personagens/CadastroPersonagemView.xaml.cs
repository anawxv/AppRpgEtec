using AppRpgEtec.Models;
using AppRpgEtec.Models.Personagens;
using AppRpgEtec.ViewModels.Personagens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AppRpgEtec.Views.Personagens;

public partial class CadastroPersonagemView : ContentPage

{

    private CadastroPersonagemViewModel cadViewModel;

    public CadastroPersonagemView()
    {
        InitializeComponent();

        cadViewModel = new CadastroPersonagemViewModel();
        BindingContext = cadViewModel;
        Title = "Novo Personagem";


    }

 
}


