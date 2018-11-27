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
        public static HttpClient cliente;
        public static string NomeTecnico = "Tecnico1";
        
        public Atendimentos ()
		{
            

            InitializeComponent();
            Title = "Atendimentos Pendentes";

            CarroselAtendimentosAsync();

        }
        public async Task<List<Controles.Atendimento>> ListaAtendimentosAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://tecnicos.gearhostpreview.com/api/Atendimentos?tecnico=Tecnico1";
                var response = await client.GetStringAsync(url);
                var autenticidade = JsonConvert.DeserializeObject<bool>(response);
                NomeTecnico = "Tecnico1";
                if (autenticidade)
                {
                    var uri2 = "http://tecnicos.gearhostpreview.com/api/Atendimentos";
                    var response2 = await client.GetStringAsync(uri2);
                    var listaAtendimentos = JsonConvert.DeserializeObject<List<Controles.Atendimento>>(response2);

                    return listaAtendimentos;
                }

                return null;

            }
            catch (Exception ex)
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

        foreach (var item in lista)
        {
            if (item.IdAtendimento == lista.Last().IdAtendimento)
            {
                    
                    pag.Add(new ContentPage
                    {
                        Content = new StackLayout
                        {
                            Children = {
                            { new Label
                                {
                                    Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },

                            { new Label
                                {
                                    Text =  "Data Prevista:  "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },
                            { new Label
                                {
                                    Text = "Serie:  "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },
                            { new Label
                                {
                                    Text = "Requisição:  "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },
                            { new Label
                                {
                                    Text = " < ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center
                                } },
                            { new Button
                                {
                                    Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White
                                } }

                        }
                    }
                });
            }else
            if (item.IdAtendimento == lista.First().IdAtendimento)
            {
                pag.Add(new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children = {
                            { new Label
                                {
                                    Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },
                            { new Label { Text =  "Data Prevista: "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
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
                            { new Label
                                {
                                    Text =  "Tecnico:  "+NomeTecnico , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
                                } },
                            { new Label { Text =  "Data Prevista: "+item.DataPrevista.Value.ToString("dd/MM/yyyy") , FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                            { new Label { Text = "Serie: "+item.Serie.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))  } },
                            { new Label { Text = "Requisição: "+item.IdRequisicao.ToString(), FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)) } },
                            { new Label { Text = "< -- > ", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),TextColor=Color.Blue, HorizontalTextAlignment= TextAlignment.Center } },
                            { new Button { Text = "Editar/Encerrar", BackgroundColor = Color.Blue , BorderColor = Color.Black , TextColor = Color.White } }

                        }
                    }
                });         
        }
        foreach (var item in pag)
        {
            Children.Add(item);
        }

        }
        
	}
    
    
}