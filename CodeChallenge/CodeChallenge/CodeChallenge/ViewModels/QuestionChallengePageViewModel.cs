using CodeChallenge.DTOs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.ViewModels
{
    public class QuestionChallengePageViewModel : BindableBase
    {
        public List<Question> Questions { get; set; }
        public ObservableCollection<string> Alternatives { get; set; }
        private Question selectedQuestion;
        private IPageDialogService _dialogService;

        public QuestionChallengePageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            Alternatives = new ObservableCollection<string>();
            Questions = new List<Question>();
            FillQuestions();
            ChoseQuestion();
        }

        private string _questionText;
        public string QuestionText
        {
            get { return _questionText; }
            set { SetProperty(ref _questionText, value); }
        }

        private string _selectedAlternative;
        public string SelectedAlternative
        {
            get { return _selectedAlternative; }
            set
            {
                SetProperty(ref _selectedAlternative, value);
                if (value != null)
                {
                    if (selectedQuestion.CorrectAlternative == value)
                    {
                        ChoseQuestion();
                        _dialogService.DisplayAlertAsync("Code Challenge", "Correto", "Ok");
                    }
                }
            }

        }

        public void ChoseQuestion()
        {
            Random random = new Random();
            int i = random.Next(0, Questions.Count - 1);
            if (selectedQuestion == Questions[i])
            {
                if (i >= Questions.Count - 1)
                    i = i - 1;
                else
                    i = i + 1;
            }
            selectedQuestion = Questions[i];
            QuestionText = selectedQuestion.QuestionText;
            Alternatives.Clear();
            foreach (var item in selectedQuestion.Alternatives)
            {
                Alternatives.Add(item);
            }
            SelectedAlternative = "errado";
        }

        public void FillQuestions()
        {
            Questions.Add(new Question
            {
                QuestionText = "Qual palavra define uma classe como publica ?",
                Alternatives = new string[] { "private", "int", "public", "class" },
                CorrectAlternative = "public"
            });
            Questions.Add(new Question
            {
                QuestionText = "Qual palavra define uma classe como private ?",
                Alternatives = new string[] { "private", "int", "public", "class" },
                CorrectAlternative = "private"
            });
            Questions.Add(new Question
            {
                QuestionText = "Qual palavra define uma classe ou um método como estático?",
                Alternatives = new string[] { "private", "int", "static", "class" },
                CorrectAlternative = "static"
            });
        }
    }
}
