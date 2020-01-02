using System;
using System.Windows.Forms;
using CRCodile.Lib;

namespace CRCodile.App {
    public partial class ConvertButton : Button {
        /// <summary>
        /// This fires when output file selected
        /// </summary>
        public event EventHandler OutputFileSelected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent</param>
        public ConvertButton(Control parent) {
            InitializeComponent();
            parent.Controls.Add(this);
        }

        /// <summary>
        /// Change button caption
        /// </summary>
        public void OnDumpLoaded(object sender, EventArgs e) {
            if (e is TypeEventArgs args) {
                this.Enabled = true;
                var type = args?.Type;
                var typeStr = type is DoubleDataRate3 ? "DDR3L" : "DDR3";
                this.Text = $"Convert to {typeStr}";
            }
        }

        /// <summary>
        /// Send output file path
        /// </summary>
        private void OnClick(object sender, EventArgs e) {
            if (this._outputDialog.ShowDialog() == DialogResult.OK) {
                var path = this._outputDialog.FileName;
                OutputFileSelected?.Invoke(this, new PathEventArgs(path));
            }
        }
    }
}