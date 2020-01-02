using System;
using System.Windows.Forms;

namespace CRCodile.App {
    /// <summary>
    /// RAM Type containing label
    /// </summary>
    public partial class TypeLabel : UserControl {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent control</param>
        public TypeLabel(Control parent) {
            InitializeComponent();
            parent.Controls.Add(this);
        }

        /// <summary>
        /// Change type
        /// </summary>
        public void OnDumpLoaded(object sender, EventArgs e) {
            if (e is TypeEventArgs args) {
                this._value.Text = args?.Type.Name;
            }
        }
    }
}