using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeChallenge.ViewModels
{
    public class KeywordChallengePageViewModel : BindableBase, INavigationAware
    {
        #region Commands
        public DelegateCommand<TextChangedEventArgs> TextChangedCommand { get; set; }
        #endregion

        #region BindableProperties

        private string _textTyped;
        public string TextTyped
        {
            get { return _textTyped; }
            set { SetProperty(ref _textTyped, value); }
        }

        private DateTime _timer;
        public DateTime Timer
        {
            get { return _timer; }
            set { SetProperty(ref _timer, value); }
        }

        private string _scoreText;
        public string ScoreText
        {
            get { return _scoreText; }
            set { SetProperty(ref _scoreText, value); }
        }

        #endregion

        public List<string> Keywords { get; set; }
        public ObservableCollection<string> KeywordsFinded { get; set; }
        public int AllKeywords { get; set; }
        public KeywordChallengePageViewModel()
        {
            Keywords = new List<string>();
            KeywordsFinded = new ObservableCollection<string>();
            TextChangedCommand = new DelegateCommand<TextChangedEventArgs>(TextChanged);
            FillKeywords();
            AllKeywords = Keywords.Count;
            ScoreText = String.Format("{0} of {1}", KeywordsFinded.Count, AllKeywords);
        }
        #region CommandsMethods
        private void TextChanged(TextChangedEventArgs e)
        {
            string keyword = Keywords.Where(x => x.Equals(e.NewTextValue)).FirstOrDefault();
            if (String.IsNullOrEmpty(keyword) == false)
            {
                Keywords.Remove(keyword);
                KeywordsFinded.Add(keyword);
                ScoreText = String.Format("{0} of {1}", KeywordsFinded.Count, AllKeywords);
                TextTyped = "";
            }
        }
        #endregion
        private void FillKeywords()
        {
            Keywords.Add("abstract");
            Keywords.Add("break");
            Keywords.Add("char");
            Keywords.Add("continue");
            Keywords.Add("do");
            Keywords.Add("event");
            Keywords.Add("finally");
            Keywords.Add("foreach");
            Keywords.Add("in");
            Keywords.Add("internal");
            Keywords.Add("namespace");
            Keywords.Add("operator");
            Keywords.Add("params");
            Keywords.Add("readonly");
            Keywords.Add("sealed");
            Keywords.Add("static");
            Keywords.Add("this");
            Keywords.Add("typeof");
            Keywords.Add("unsafe");
            Keywords.Add("virtual");
            Keywords.Add("as");
            Keywords.Add("byte");
            Keywords.Add("checked");
            Keywords.Add("decimal");
            Keywords.Add("double");
            Keywords.Add("explicit");
            Keywords.Add("fixed");
            Keywords.Add("goto");
            Keywords.Add("in");
            Keywords.Add("is");
            Keywords.Add("base");
            Keywords.Add("case");
            Keywords.Add("class");
            Keywords.Add("default");
            Keywords.Add("else");
            Keywords.Add("extern");
            Keywords.Add("float");
            Keywords.Add("if");
            Keywords.Add("int");
            Keywords.Add("lock");
            Keywords.Add("bool");
            Keywords.Add("catch");
            Keywords.Add("const");
            Keywords.Add("delegate");
            Keywords.Add("enum");
            Keywords.Add("false");
            Keywords.Add("for");
            Keywords.Add("implicit");
            Keywords.Add("interface");
            Keywords.Add("long");
            Keywords.Add("new");
            Keywords.Add("out");
            Keywords.Add("private");
            Keywords.Add("ref");
            Keywords.Add("short");
            Keywords.Add("string");
            Keywords.Add("throw");
            Keywords.Add("uint");
            Keywords.Add("void");
            Keywords.Add("null");
            Keywords.Add("out");
            Keywords.Add("protected");
            Keywords.Add("return");
            Keywords.Add("sizeof");
            Keywords.Add("struct");
            Keywords.Add("true");
            Keywords.Add("ulong");
            Keywords.Add("using");
            Keywords.Add("volatile");
            Keywords.Add("object");
            Keywords.Add("override");
            Keywords.Add("public");
            Keywords.Add("sbyte");
            Keywords.Add("stacklloc");
            Keywords.Add("switch");
            Keywords.Add("try");
            Keywords.Add("unchecked");
            Keywords.Add("while");
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
