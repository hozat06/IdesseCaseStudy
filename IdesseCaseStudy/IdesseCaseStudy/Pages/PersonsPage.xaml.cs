
using IdesseCaseStudy.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdesseCaseStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonsPage : ContentPage
    {
        private readonly CardViewModel cardViewModel;
        public PersonsPage()
        {
            InitializeComponent();
            cardViewModel = new CardViewModel();
            this.BindingContext = cardViewModel;
        }

        private void ListPersons_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.LastVisibleItemIndex % 9 == 0)
            {
                cardViewModel.LoadList();
            }
        }
    }
}