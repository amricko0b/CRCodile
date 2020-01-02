using System;
using System.Windows.Forms;

namespace CRCodile.App {
    internal class App {
        [STAThread]
        public static void Main(string[] args) {
            Application.Run(new MainForm());
        }
    }
}