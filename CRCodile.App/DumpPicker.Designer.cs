using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CRCodile.App {
    /// <summary>
    /// Button control for conversion launching
    /// </summary>
    partial class DumpPicker {

        /// <summary>
        /// Non-UI components
        /// </summary>
        private IContainer _components = new Container();

        // LAYOUTS
        
        /// <summary>
        /// Main control layout
        /// </summary>
        private TableLayoutPanel _mainLayout = new TableLayoutPanel() {
            RowCount = 2, ColumnCount = 1, AutoSize = true, Dock = DockStyle.Fill
        };
        
        /// <summary>
        /// Layout for label and file path
        /// </summary>
        private TableLayoutPanel _controlsLayout = new TableLayoutPanel() {
            RowCount = 1, ColumnCount = 2, AutoSize = true, Dock = DockStyle.Fill
        };

        // CONTROLS
        
        /// <summary>
        /// Picker button
        /// </summary>
        private Button _pickerButton = new Button() {
            Text = "Pick a binary", Dock = DockStyle.Fill
        };
        
        /// <summary>
        /// UI label
        /// </summary>
        private Label _pathLabel = new Label() {
            Text = "File: ", Dock = DockStyle.Fill
        };
        
        /// <summary>
        /// Text box with selected file path
        /// </summary>
        private TextBox _pathBox = new TextBox() {
            ReadOnly = true, Dock = DockStyle.Fill
        };
        
        // COMPONENTS
        
        /// <summary>
        /// Incoming file selecteion dialog
        /// </summary>
        private OpenFileDialog _pickerDialog = new OpenFileDialog() {
            Title = "Select binary dump"
        };

      
        /// <inheritdoc cref="ContainerControl"/>
        protected override void Dispose(bool disposing) {
            if (disposing && (_components != null)) {
                _components.Dispose();
            }

            if (disposing) {
                foreach (Control control in this._controlsLayout.Controls) {
                    control.Dispose();
                }

                foreach (Control control in this._mainLayout.Controls) {
                    control.Dispose();
                }
                this._mainLayout.Dispose();
            }

            base.Dispose(disposing);
        }
        
        /// <summary>
        /// Main initialization
        /// </summary>
        private void InitializeComponent() {
            this._components.Add(this._pickerDialog);
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            
            this._pickerButton.Click += this.OnClick;
            this._mainLayout.Controls.Add(_pickerButton);

            this._controlsLayout.Controls.Add(this._pathLabel);
            this._controlsLayout.Controls.Add(this._pathBox);
            
            this._mainLayout.Controls.Add(_controlsLayout);
            this.Controls.Add(_mainLayout);
        }
    }
}