using CarouselView.FormsPlugin.Abstractions;
using CarouselView.FormsPlugin.Android;
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
	public partial class Atendimentos : CarouselPage/*ContentPage*/
	{

		public Atendimentos ()
		{
            

            InitializeComponent();

            foreach (var item in CarroselAtendimentos())
            {
                Children.Add(item);
            }

        }
        public List<string> ListaAtendimentos()
        {
            var ListaAtendimentos = new List<Controles.Atendimento>(){
               new Controles.Atendimento(1,1,1,"Serie1",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(1,1,1,"Serie2",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(1,1,1,"Serie3",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
            };

            var listStr = new List<string>();

            foreach (var item in ListaAtendimentos)
            {
                listStr.Add(item.Serie);
            }


            return listStr;
        }
        public List<ContentPage> CarroselAtendimentos()
        {
            List<ContentPage> pag = new List<ContentPage>(0);
            ListaAtendimentos();

            foreach (var item in ListaAtendimentos())
            {
                pag.Add(new ContentPage{
                            Content = new StackLayout{
                                Children = { new Label { Text = item.ToString(), HorizontalTextAlignment = TextAlignment.Center,VerticalTextAlignment = TextAlignment.Center }       
                            }
                        }
                });
            }

            return pag;


        }
        
	}
    
    
}