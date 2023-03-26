using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // コンソール出力を TextBlock に表示する
            Console.SetOut(new ControlWriter(outputTextBlock));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var interceptKeyboard = new InterceptKeyboard();
            interceptKeyboard.KeyDownEvent += InterceptKeyboard_KeyDownEvent;
            interceptKeyboard.KeyUpEvent += InterceptKeyboard_KeyUpEvent;
            interceptKeyboard.Hook();

            //interceptKeyboard.UnHook();
        }

        private static void InterceptKeyboard_KeyUpEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
        }

        private static void InterceptKeyboard_KeyDownEvent(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            Console.WriteLine("Keydown KeyCode {0}", e.KeyCode);
        }
    }
}
