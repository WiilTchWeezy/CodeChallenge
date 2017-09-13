using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CodeChallenge.ViewModels
{
    public class KeywordChallengePageViewModel : BindableBase, INavigationAware
    {
        #region Commands
        public DelegateCommand<TextChangedEventArgs> TextChangedCommand { get; set; }
        #endregion

        #region BindableProperties
        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }
        #endregion

        public List<string> Keywords { get; set; }
        public ObservableCollection<string> KeywordsFinded { get; set; }
        public KeywordChallengePageViewModel()
        {
            Keywords = new List<string>();
            KeywordsFinded = new ObservableCollection<string>();
            TextChangedCommand = new DelegateCommand<TextChangedEventArgs>(TextChanged);
            FillKeywords();
        }
        #region CommandsMethods
        private void TextChanged (TextChangedEventArgs e)
        {
            string keyword = Keywords.Where(x => x.Equals(e.NewTextValue)).FirstOrDefault();
            if (String.IsNullOrEmpty(keyword) == false)
            {
                Keywords.Remove(keyword);
                KeywordsFinded.Add(keyword);
                Score++;
            }
        }
        #endregion
        private void FillKeywords()
        {
            Keywords.Add("public");
            Keywords.Add("private");
            Keywords.Add("protected");
            Keywords.Add("void");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
