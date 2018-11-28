using CarouselView.FormsPlugin.Abstractions;
using CarouselView.FormsPlugin.Android;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RATEletronica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Atendimentos : CarouselPage/*ContentPage*/
	{
        
        public static string NTecnico ;
        
        public Atendimentos ()
		{
            
            InitializeComponent();
            Title = "Atendimentos Pendentes";

            CarroselAtendimentosAsync();

        }
        public async Task<List<Controles.Atendimento>> ListaAtendimentosAsync()
        {
            HttpClient client = new HttpClient();
            string url = "http://tecnicos.gearhostpreview.com/api/Atendimentos?tecnico=" + NTecnico;

            var uri2 = "http://tecnicos.gearhostpreview.com/api/Atendimentos";

            try
            {
                var response = await client.GetStringAsync(url);
                var autenticidade = JsonConvert.DeserializeObject<bool>(response);
                if (autenticidade)
                { 
                    var response2 = await client.GetStringAsync(uri2);
                    var listaAtendimentos = JsonConvert.DeserializeObject<List<Controles.Atendimento>>(response2);

                    return listaAtendimentos;
                }

                return null;

            }
            catch (Exception)
            {
                return null;
                
            }
        }
        #region Teste
        //    var ListaAtendimentos = new List<Controles.Atendimento>(){
        //   new Controles.Atendimento(1,1,1,"Serie1",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
        //   new Controles.Atendimento(2,1,1,"Serie2",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
        //   new Controles.Atendimento(3,1,1,"Serie3",Controles.Atendimento.TipoAtendimentos.Instalação,DateTime.Now,DateTime.Now,1,new TimeSpan(1,1,1),new TimeSpan(1,1,1),new TimeSpan(1,1,1),Controles.Atendimento.Itinerarios.BC,1,Controles.Atendimento.Itinerarios.CB,1,Controles.Atendimento.Condicaofinal.Parado,Controles.Atendimento.CondicaoMaterial.Necessita_peças,"Obs1"),
        //};

        //var listStr = new List<string>();

        //foreach (var item in ListaAtendimentos)
        //{
        //    listStr.Add(item.Serie);
        //}


        //return ListaAtendimentos;
        #endregion
    
        public async void CarroselAtendimentosAsync()
        {
            List<ContentPage> pag = new List<ContentPage>(0);
            List<Controles.Atendimento> lista = await ListaAtendimentosAsync();


            List<ContentPage> lPage = new List<ContentPage>();
            ContentPage cPage = new ContentPage();
            StackLayout stackLay;

            foreach (var item in lista)
            {
                Label NomeTecnico = new Label();
                Label DataPrevista = new Label();
                Label Serie = new Label();
                Label idRequisicao = new Label();
                Button btnEditar = new Button();
                Label Seta = new Label();
                Grid grid = new Grid();

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(400) });

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

                NomeTecnico.Text = "Tecnico:  " + NTecnico;
                NomeTecnico.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                NomeTecnico.HorizontalOptions = LayoutOptions.Center;
                NomeTecnico.VerticalOptions = LayoutOptions.Center;
                grid.Children.Add(NomeTecnico,1,1);


                DataPrevista.Text = "Data Prevista:  " + item.DataPrevista.Value.ToString("dd/MM/yyyy");
                DataPrevista.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                DataPrevista.HorizontalOptions = LayoutOptions.Center;
                DataPrevista.VerticalOptions = LayoutOptions.Center;
                grid.Children.Add(DataPrevista, 1, 2);


                Serie.Text = "Serie:  " + item.Serie.ToString();
                Serie.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                Serie.HorizontalOptions = LayoutOptions.Center;
                Serie.VerticalOptions = LayoutOptions.Center;
                grid.Children.Add(Serie, 1, 3);

                idRequisicao.Text = "Requisição:  " + item.IdRequisicao.ToString();
                idRequisicao.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                idRequisicao.HorizontalOptions = LayoutOptions.Center;
                idRequisicao.VerticalOptions = LayoutOptions.Center;
                grid.Children.Add(idRequisicao, 1, 4);

                btnEditar.Text = "Editar/Encerrar";
                btnEditar.BackgroundColor = Color.Blue;
                btnEditar.BorderColor = Color.Black;
                btnEditar.TextColor = Color.White;
                btnEditar.Clicked += async (sender, args) => await RedirecionarAsync(item);
                grid.Children.Add(btnEditar, 1, 5);

                if (item.IdAtendimento == lista.Last().IdAtendimento)
                {
                    Seta.Text = " <-- ";
                    Seta.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    Seta.TextColor = Color.Blue;
                    Seta.HorizontalTextAlignment = TextAlignment.Center;
                    grid.Children.Add(Seta, 1, 6);
                }
                else if (item.IdAtendimento == lista.First().IdAtendimento)
                {
                    Seta.Text = " --> ";
                    Seta.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    Seta.TextColor = Color.Blue;
                    Seta.HorizontalTextAlignment = TextAlignment.Center;
                    grid.Children.Add(Seta, 1, 6);
                }
                else
                {
                    Seta.Text = " < -- > ";
                    Seta.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                    Seta.TextColor = Color.Blue;
                    Seta.HorizontalTextAlignment = TextAlignment.Center;
                    grid.Children.Add(Seta, 1, 6);
                }

                stackLay = new StackLayout() { Children = {grid,NomeTecnico,DataPrevista,Serie,idRequisicao,btnEditar,Seta }};

                lPage.Add(new ContentPage() { Content = stackLay , Title="Atendimentos Pendendes"}); 
                

                #region Antiga


                //if (item.IdAtendimento == lista.Last().IdAtendimento)
                //{
                //        pag.Add(new ContentPage
                //        {
                //            Content = new StackLayout
                //            {
                //                Children = {
                //                { new Label
                //                    {
                //                        Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label
                //                    {
                //                        Text =  "Data Prevista:  "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label
                //                    {
                //                        Text = "Serie:  "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label
                //                    {
                //                        Text = "Requisição:  "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label
                //                    {
                //                        Text = " < ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center
                //                    } },
                //                { btnEditar}
                //            }
                //        }
                //    });
                //}else
                //if (item.IdAtendimento == lista.First().IdAtendimento)
                //{
                //    pag.Add(new ContentPage
                //    {
                //        Content = new StackLayout
                //        {
                //            Children = {
                //                { new Label
                //                    {
                //                        Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label { Text =  "Data Prevista: "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                //                { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                //                { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                //                { new Label { Text = " > ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                //                { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                //            }
                //        }
                //    });
                //}else               
                //    pag.Add(new ContentPage
                //    {
                //        Content = new StackLayout
                //        {
                //            Children = {
                //                { new Label
                //                    {
                //                        Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                //                    } },
                //                { new Label { Text =  "Data Prevista: "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                //                { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                //                { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                //                { new Label { Text = "< -- > ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                //                { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                //            }
                //        }
                //    });       
                #endregion
            }
            foreach (var item in lPage)
            {
                Children.Add(item);
            }

        }

        private async Task RedirecionarAsync(Controles.Atendimento atend)
        {
            Edicao.atendimento = atend;
            await Navigation.PushModalAsync(new Edicao());
        }
        
	}
    
    
}