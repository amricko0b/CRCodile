using System;
using System.Windows.Forms;

namespace CRCodile.App {
    /// <summary>
    /// Incoming dump selection component
    /// </summary>
    public partial class DumpPicker : UserControl {
        /// <summary>
        /// Fires when incoming binary was selected
        /// </summary>
        public event EventHandler IncomingFileSelected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent control</param>
        public DumpPicker(Control parent) {
            InitializeComponent();
            parent.Controls.Add(this);
        }

        /// <summary>
        /// Notify others that incoming file selected
        /// </summary>
        private void OnClick(object sender, EventArgs e) {
            if (_pickerDialog.ShowDialog() == DialogResult.OK) {
                var path = _pickerDialog.FileName;
                this._pathBox.Text = path;
                IncomingFileSelected?.Invoke(this, new PathEventArgs(path));
            }
        }
    }
}