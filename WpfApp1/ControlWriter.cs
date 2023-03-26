using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ControlWriter : System.IO.TextWriter
    {
        private readonly System.Windows.Controls.TextBlock _output;

        public ControlWriter(System.Windows.Controls.TextBlock output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            _output.Dispatcher.Invoke(() => _output.Text += value);
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}
