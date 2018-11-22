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
            ObservableCollection<string> employees = new ObservableCollection<string>();

            employees.Add("teste");
            employees.Add("teste");
            employees.Add("teste");
            employees.Add("teste");
            employees.Add("teste");
            employees.Add("teste");

            EmployeeView.ItemsSource = employees.ToList();
            //EmployeeView.ItemsSource = employees;

            InitializeComponent ();
		}
	}
}