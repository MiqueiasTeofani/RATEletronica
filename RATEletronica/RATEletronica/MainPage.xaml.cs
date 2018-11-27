using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RATEletronica
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void btnLogar_ClickedAsync(object sender, EventArgs e)
        {
            if (lbUsuario.Text != "")
            {
                if (lbSenha.Text != "")
                {
                    await AutenticarAsync(lbUsuario.Text);

                }
                else { }

            }
            else { }
        }
        private async Task<bool> AutenticarAsync(string tecnico)
        {
            try
            {
                HttpClient client =new HttpClient();
                string url = "http://tecnicos.gearhostpreview.com/api/Atendimentos?tecnico="+tecnico;
                var response = await client.GetStringAsync(url);
                var autenticidade = JsonConvert.DeserializeObject<bool>(response);

                if (autenticidade)
                {
                    await Navigation.PushModalAsync(new Atendimentos());
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
