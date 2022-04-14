using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlAnimation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Event theEvent)
        {
            InitializeComponent();
            this.Event = theEvent;
            this.BindingContext = this;
        }

        public Event Event { get; set; }
        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void OpenMaps(object sender, EventArgs e)
        {
            await Map.OpenAsync(Event.Latitude, Event.Longitude, new MapLaunchOptions
            {
                Name = Event.EventName,
                NavigationMode = NavigationMode.Walking
            });
        }
    }
}