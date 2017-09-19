using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeChallenge.Views.Controls
{

    public class TextChangedEntry : Entry , IDisposable
    {
        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(TextChangedEntry), default(ICommand));

        public TextChangedEntry()
        {
            this.TextChanged += TextChangedEntry_TextChanged;
        }

        private void TextChangedEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextChangedCommand.Execute(e);
        }

        public void Dispose()
        {
            this.TextChanged -= TextChangedEntry_TextChanged;
        }
    }
}
