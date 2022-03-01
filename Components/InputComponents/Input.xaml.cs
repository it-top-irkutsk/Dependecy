using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Components.Annotations;

namespace Components.InputComponents
{
    public partial class Input : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty LabelProperty;
        public static readonly DependencyProperty InputProperty;

        public string LabelContent
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        public string InputText
        {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }
        
        public Input()
        {
            DataContext = this;
            InitializeComponent();
        }

        static Input()
        {
            LabelProperty = DependencyProperty.Register(
                nameof(LabelContent), 
                typeof(string), 
                typeof(Input),
                new FrameworkPropertyMetadata(string.Empty, 
                    FrameworkPropertyMetadataOptions.Inherits)
                );
            InputProperty = DependencyProperty.Register(
                nameof(InputText),
                typeof(string),
                typeof(Input),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | 
                    FrameworkPropertyMetadataOptions.Inherits,
                    new PropertyChangedCallback(OnFirstPropertyChanged))
                );
        }
        
        private static void OnFirstPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var c = sender as Input;
            c?.OnPropertyChanged(nameof(InputProperty));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}