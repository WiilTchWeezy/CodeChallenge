using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Commands
        public DelegateCommand KeywordChallengeCommand { get; set; }
        #endregion

        private INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            KeywordChallengeCommand = new DelegateCommand(NavigateToKeywordChallenge);
            _navigationService = navigationService;
        }

        #region CommandsMethods
        private void NavigateToKeywordChallenge()
        {
            _navigationService.NavigateAsync("KeywordChallengePage");
        }
        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
