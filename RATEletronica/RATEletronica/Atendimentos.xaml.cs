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
            Title = "Atendimentos Pendentes";
            foreach (var item in CarroselAtendimentos())
            {
                Children.Add(item);
            }

        }
        public List<Controles.Atendimento> ListaAtendimentos()
        {
            var ListaAtendimentos = new List<Controles.Atendimento>(){
               new Controles.Atendimento(1,1,1,"Serie1",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(2,1,1,"Serie2",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
               new Controles.Atendimento(3,1,1,"Serie3",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
            };

            var listStr = new List<string>();

            foreach (var item in ListaAtendimentos)
            {
                listStr.Add(item.Serie);
            }


            return ListaAtendimentos;
        }
        public List<ContentPage> CarroselAtendimentos()
        {
            List<ContentPage> pag = new List<ContentPage>(0);
            ListaAtendimentos();

            foreach (var item in ListaAtendimentos())
            {

              

                if (item.IdAtendimento == ListaAtendimentos().Last().IdAtendimento)
                {
                    pag.Add(new ContentPage
                    {
                        Content = new StackLayout
                        {
                            Children = {
                                { new Label { Text =  "Data Prevista: "+item.DataPrevista.ToString() , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                                { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = " < ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                                { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                            }
                        }
                    });
                }else
                if (item.IdAtendimento == ListaAtendimentos().First().IdAtendimento)
                {
                    pag.Add(new ContentPage
                    {
                        Content = new StackLayout
                        {
                            Children = {
                                { new Label { Text =  "Data Prevista: "+item.DataPrevista.ToString() , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                                { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = " > ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                                { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                            }
                        }
                    });
                }else               
                    pag.Add(new ContentPage
                    {
                        Content = new StackLayout
                        {
                            Children = {
                                { new Label { Text =  "Data Prevista: "+item.DataPrevista.ToString() , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                                { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                                { new Label { Text = "< -- > ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                                { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                            }
                        }
                    });         
            }
            return pag;


        }
        
	}
    
    
}