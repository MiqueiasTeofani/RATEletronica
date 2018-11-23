using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RATEletronica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Atendimentos : ContentPage
	{

		public Atendimentos ()
		{

            InitializeComponent ();

            var list = new List<string>();

            foreach (var item in ListaAtendimentos())
            {
                list.Add(item.Serie);
            }

            var listView = new ListView
            {
                ItemsSource = list
            };

            Content = listView;
            


            
		}
        public List<Controles.Atendimento> ListaAtendimentos()
        {
            var ListaAtendimentos = new List<Controles.Atendimento>(){
               new Controles.Atendimento(1,1,1,"Serie1",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(1,1,1,"Serie2",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(1,1,1,"Serie3",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
            };
            return ListaAtendimentos;
        }
	}
    
}