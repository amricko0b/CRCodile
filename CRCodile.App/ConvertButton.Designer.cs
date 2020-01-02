using System.ComponentModel;
using System.Windows.Forms;

namespace CRCodile.App {
    partial class ConvertButton {

        /// <summary>
        /// Non-UI components
        /// </summary>
        private IContainer _components = null;
        
        /// <summary>
        /// Output file selection dialog
        /// </summary>
        private SaveFileDialog _outputDialog = new SaveFileDialog() {
            Title =  "Save as", FileName = "converted.bin", DefaultExt = "bin", Filter = "Data Files (*.bin)|*.bin"
        };
        
        /// <inheritdoc cref="ButtonBase"/>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// Main Initialization
        /// </summary>
        private void InitializeComponent() {
            this._components = new Container();
            this._components.Add(this._outputDialog);
            
            this.AutoSize = true;
            this.Dock = DockStyle.Bottom;

            this.Enabled = false;
            this.Text = "Convert";
            this.Click += this.OnClick;
        }
    }
}