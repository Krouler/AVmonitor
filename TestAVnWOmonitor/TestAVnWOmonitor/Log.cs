using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestAVnWOmonitor
{
    class Log
    {
        private static TextBox _textbox { get; set; }

        public static void Handle(TextBox textbox, string txt)
        {
            if (_textbox == null)
            {
                _textbox = textbox;
            }
            _textbox.Text = DateTime.Now.ToString() + txt;
        }

        public static void Add(string text)
        {
            _textbox.Text += Environment.NewLine + DateTime.Now.ToString() + ": " + text;
            _textbox.ScrollToCaret();


        }
    }
}
