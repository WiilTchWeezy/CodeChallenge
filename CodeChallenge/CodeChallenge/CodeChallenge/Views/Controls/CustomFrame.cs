using System.Windows.Input;
using Xamarin.Forms;

namespace CodeChallenge.Views.Controls
{
    public class CustomFrame : Frame
    {

        public ICommand TapCommand
        {
            get { return (Command)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public static readonly BindableProperty TapCommandProperty =
            BindableProperty.Create(nameof(TapCommand), typeof(Command), typeof(CustomFrame), default(Command), BindingMode.OneWay);

        public CustomFrame()
        {
                var gestureRecognizer = new TapGestureRecognizer();
                gestureRecognizer.Tapped += (s, e) =>
                {
                    TapCommand.Execute(null);
                };
                this.GestureRecognizers.Add(gestureRecognizer);
         
        }

    }
}
