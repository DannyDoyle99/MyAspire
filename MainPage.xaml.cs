using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamlAnimation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<EventType> EventTypeList => GetEventTypes();

        public List<Event> EventsList => GetEvents();

        private List<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType { TypeName = "All"},
                new EventType { TypeName = "Concerts"},
                new EventType { TypeName = "Meetings"},
                new EventType { TypeName = "Training"},
            };
        }

        private List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event { Image = "fireworks.jpg", Address = "23 Goodlass Road", Location = "Business First", EventName = "Eagle Firework Display", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Mi bibendum neque egestas congue quisque egestas diam in arcu. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing. Pretium viverra suspendisse potenti nullam ac tortor vitae purus. Fames ac turpis egestas sed tempus urna et pharetra pharetra.", Latitude = 53.354300F, Longitude = -2.871080F, EventStartTime = "23:00" },
                new Event { Image = "maskparty.jpg", Address = "24 Goodlass Road", Location = "Business First", EventName = "Mask Gala", Details="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Mi bibendum neque egestas congue quisque egestas diam in arcu. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing. Pretium viverra suspendisse potenti nullam ac tortor vitae purus. Fames ac turpis egestas sed tempus urna et pharetra pharetra.", Latitude = 53.354300F, Longitude = -2.871080F, EventStartTime = "19:30" },
                new Event { Image = "rockconcert", Address = "M&S Bank Arena", Location = "M&S Bank Arena", EventName = "Eagle Manager Concert", Details="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Mi bibendum neque egestas congue quisque egestas diam in arcu. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing. Pretium viverra suspendisse potenti nullam ac tortor vitae purus. Fames ac turpis egestas sed tempus urna et pharetra pharetra.", Latitude = 53.396007F, Longitude = -2.99118F, EventStartTime = "TBA" },
                new Event { Image = "training.jpg", Address = "Liverpool University", Location = "Tuition Centre", EventName = "Eagle Manager Training", Details="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Mi bibendum neque egestas congue quisque egestas diam in arcu. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing. Pretium viverra suspendisse potenti nullam ac tortor vitae purus. Fames ac turpis egestas sed tempus urna et pharetra pharetra.", Latitude = 53.447369F, Longitude = -2.986930F, EventStartTime = "13:00" },
            };
        }

        private async void EventSelected(object sender, EventArgs e)
        {
            var theEvent = (sender as View).BindingContext as Event;
            await this.Navigation.PushAsync(new DetailsPage(theEvent));
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "NormalState");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#f4f4f4");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var textControl = child.FindByName<Label>("EventTypeName");
            if (textControl != null)
                textControl.TextColor = Color.FromHex(hexColor);
        }
    }

    public class EventType
    {
        public string TypeName { get; set; }
    }

    public class Event
    {
        public string Id => Guid.NewGuid().ToString("N");

        public string EventName { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public string Details { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string EventStartTime { get; set; }

    }
}
