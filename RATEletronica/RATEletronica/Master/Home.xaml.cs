using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RATEletronica.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : MasterDetailPage
    {
        public Home()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeMenuItem;
            if (item == null)
                return;
            
            switch (item.Title)     
            {
                case "Atendimentos Pendentes":
                    {
                        item.TargetType = typeof(Atendimentos);
                        var page = (CarouselPage)Activator.CreateInstance(item.TargetType);
                        page.Title = item.Title;
                        Detail = new NavigationPage(page);
                    }
                    break;
                case "Home":
                    {
                        item.TargetType = typeof(HomeDetail);
                        var page = (Page)Activator.CreateInstance(item.TargetType);
                        page.Title = item.Title;
                        Detail = new NavigationPage(page);
                    }
                    break;
                case "Sair":
                    {
                        Navigation.PushModalAsync(new MainPage());
                        
                        //item.TargetType = typeof(MainPage);
                        //var page = (Page)Activator.CreateInstance(item.TargetType);
                        //page.Title = item.Title;
                        //Detail = new NavigationPage(page);
                    }
                    break;
                default:
                    {
                        item.TargetType = typeof(HomeDetail);
                        var page = (Page)Activator.CreateInstance(item.TargetType);
                        page.Title = item.Title;
                        Detail = new NavigationPage(page);
                    }
                    break;
            }

            //var page = (CarouselPage) Activator.CreateInstance(item.TargetType);
            //var page =  (Page)  Activator.CreateInstance(item.TargetType);
            
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}