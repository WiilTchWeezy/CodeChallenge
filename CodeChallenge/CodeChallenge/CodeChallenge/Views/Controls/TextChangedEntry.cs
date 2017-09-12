using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeChallenge.Views.Controls
{

    public class TextChangedEntry : Entry , IDisposable
    {
        public ICommand TextChangedCommand
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(Command), typeof(TextChangedEntry), defaultBindingMode: BindingMode.OneWay, defaultValue: default(Command));

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
