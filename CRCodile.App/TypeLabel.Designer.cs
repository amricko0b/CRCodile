using System.ComponentModel;
using System.Windows.Forms;

namespace CRCodile.App {
    
    partial class TypeLabel {
        // LAYOUT
        
        /// <summary>
        /// Control layout
        /// </summary>
        private TableLayoutPanel _layoutPanel = new TableLayoutPanel() {
            RowCount = 1, ColumnCount = 2, AutoSize = true, Dock = DockStyle.Fill
        };

        // CONTROLS
        
        /// <summary>
        /// Just label
        /// </summary>
        private Label _title = new Label() {
            Text = "Detected: "
        };

        /// <summary>
        /// RAM value
        /// </summary>
        private Label _value = new Label() {
            Text = "Nothing"
        }; 

        /// <inheritdoc cref="ContainerControl"/>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                foreach (Control control in this._layoutPanel.Controls) {
                    control.Dispose();
                }
                this._layoutPanel.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Main initialization
        /// </summary>
        private void InitializeComponent() {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;

            this._layoutPanel.Controls.Add(_title);
            this._layoutPanel.Controls.Add(_value);
            this.Controls.Add(this._layoutPanel);
        }
    }
}