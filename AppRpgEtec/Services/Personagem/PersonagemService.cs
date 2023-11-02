using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models.Personagens;

namespace AppRpgEtec.Services.Personagens
{
    public class PersonagemService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://bsite.net/luizfernando987/Personagens";

        private string _token;
        public PersonagemService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<ObservableCollection<Personagem>>GetPersonagensByNomeAsync(string busca)
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Models.Personagem> listaPersonagem = await
                _request.GetAsync<ObservableCollection<Models.Personagem>>(apiUrlBase + urlComplementar, _token);
            var personagensFiltrados = listaPersonagem.Where(p => p.Nome.ToLower().Contains(busca.ToLower()));

            return new ObservableCollection<Personagem>((List<Personagem>)personagensFiltrados);
        }

        public async Task<int> PostPersonagemAsync(Personagem p)
        {
            return await _request.PostReturnIntTokenAsync(apiUrlBase, p, _token);
        }
        public async Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Personagens.Personagem> listaPersonagens = await
            _request.GetAsync<ObservableCollection<Models.Personagens.Personagem>>(apiUrlBase + urlComplementar,
            _token);
            return listaPersonagens;
        }
        public async Task<Personagem> GetPersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var personagem = await _request.GetAsync<Models.Personagens.Personagem>(apiUrlBase +
            urlComplementar, _token);
            return personagem;
        }
        public async Task<int> PutPersonagemAsync(Personagem p)
        {
            var result = await _request.PutAsync(apiUrlBase, p, _token);
            return result;
        }
        public async Task<int> DeletePersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token);
            return result;
        }

     
    }

}
