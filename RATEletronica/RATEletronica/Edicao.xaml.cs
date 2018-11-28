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
		}
	}
}