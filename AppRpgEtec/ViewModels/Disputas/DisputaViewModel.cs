using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Personagens;
using System.Collections.ObjectModel;
using AppRpgEtec.Models.Personagens;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Disputas
{
    public class DisputaViewModel
    {
        private PersonagemService pService;
        public ObservableCollection<Personagem> PersonagensEncontrados { get; set; }
        public Personagem Atacante { get; set; }
        public Personagem Oponente { get; set; }

        public DisputaViewModel() 
        { 
        string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new PersonagemService(token);

            Atacante = new Personagem();
            Oponente = new Personagem();

            PesquisarPersonagensCommand = 
                new Command<string>(async (string pesquisa) => { await PesquisarPersonagens(pesquisa); });
        }   

        public ICommand PesquisarPersonagensCommand { get; set; }

        public async Task PesquisarPersonagens(string textoPesquisaPersonagem)
        {
            try
            {
                PersonagensEncontrados = await pService.GetPersonagensByNomeAsync(textoPesquisaPersonagem);
                    OnPropertyChanged(nameof(PersonagensEncontrados));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
