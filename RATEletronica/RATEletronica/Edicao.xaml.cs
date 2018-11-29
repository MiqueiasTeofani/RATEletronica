using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RATEletronica
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Edicao : ContentPage
	{
        public static Controles.Atendimento atendimento;
		public Edicao ()
		{

            InitializeComponent ();


            PreencherPickers();
            PreencherDateTimes();
         
            
        }
        private void PreencherPickers()
        {
            List<string> tipos = Enum.GetNames(typeof(Controles.Atendimento.TipoAtendimentos)).ToList();
            var TipoAtendimento = tipos;
            lsAtendimentos.ItemsSource = TipoAtendimento;
        }
        private void PreencherDateTimes()
        {
            lbDataPrevista.MinimumDate = DateTime.Now;
            lbDataPrevista.HorizontalOptions = LayoutOptions.Center;
            lbDataPrevista.Format = "dd/MM/yyyy";

            lbDataAtendimento.MinimumDate = DateTime.Now;
            lbDataAtendimento.HorizontalOptions = LayoutOptions.Center;
            lbDataAtendimento.Format = "dd/MM/yyyy";

        }
        private void PreencherTimeSpan()
        {
            //lbTempoViagem.Time = new TimeSpan(1, 1, 1);
            lbHoraInicio.Time = new TimeSpan(1, 1, 1);
            
            
        }

        private void btnEncerrar_Clicked(object sender, EventArgs e)
        {
             var intem = lsAtendimentos.SelectedIndex;
             var item = lbDataPrevista.Date;
             


        }
    }
}