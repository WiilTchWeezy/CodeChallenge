using Prism.Unity;
using CodeChallenge.Views;
using Xamarin.Forms;
using CodeChallenge.Infra;
using Microsoft.Practices.Unity;

namespace CodeChallenge
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<KeywordChallengePage>();
            Container.RegisterTypeForNavigation<QuestionChallengePage>();
        }
    }
}
