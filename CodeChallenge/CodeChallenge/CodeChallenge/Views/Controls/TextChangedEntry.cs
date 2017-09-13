using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeChallenge.Views.Controls
{

    public class TextChangedEntry : Entry , IDisposable
    {
        public ICommand TextChangedCommand
        {
            get { return (Command)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(Command), typeof(TextChangedEntry), defaultBindingMode: BindingMode.TwoWay, defaultValue: default(Command));

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
