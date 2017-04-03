using System;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

/* Main homepage of the app, first tab
   Shows the feed of most recent/upcoming events
 */

namespace UEApp
{
    public partial class HomePage_Events : ContentPage
    {
        public HomePage_Events()
        {
            InitializeComponent();

            list.ItemsSource = UEApp.EventsDataModel.All;

            var Goto_SettingsPage = new Command(() => Navigation.PushModalAsync(new NavigationPage(new SettingsPage()) { Title = "Settings" }));
            this.ToolbarItems.Add(new ToolbarItem { Icon = "ic_settings_white_36dp.png", Command = Goto_SettingsPage });

            var Goto_SearchPage = new Command(() => Navigation.PushModalAsync(new SearchPage()));
            this.ToolbarItems.Add(new ToolbarItem { Icon = "ic_search_white_36dp.png", Command = Goto_SearchPage });
        }

        // Custom function for displaying different background colors on alternating cells
        private bool isRowEven;
        private void Alt_Cell_Colors(object sender, EventArgs e)
        {
            if (this.isRowEven)
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("F5F5F5");
                }
            }
            this.isRowEven = !this.isRowEven;
        }

        protected override void OnAppearing()
        {
            // Clears last page from memory after home button has been pressed
            Navigation.PopModalAsync();
        }

        // Using this temporarily to look at the eventview page
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            Navigation.PushModalAsync(new NavigationPage(new EventView()) { Title = "Event" });
            ((ListView)sender).SelectedItem = null;
        }

        /* This can be used to set specific areas of a cell as clicked
        public void OnCellClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var t = b.CommandParameter;
            ((ContentPage)((ListView)((StackLayout)b.ParentView).ParentView).ParentView).DisplayAlert("Clicked", t + " button was clicked", "OK");
            Debug.WriteLine("clicked" + t);
        }*/

        void Handle_FabClicked(object sender, System.EventArgs e)
        {
            Navigation.PushPopupAsync(new EventCreation());
        }
    }
}