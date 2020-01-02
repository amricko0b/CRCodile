using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CRCodile.App {
    partial class MainForm {
        
        /// <summary>
        /// Main Window size
        /// </summary>
        private static readonly Size WindowSize = new Size(300, 170);
        
        /// <summary>
        /// Non-UI components
        /// </summary>
        private IContainer _components = null;

        /// <summary>
        /// IO dump manager
        /// </summary>
        private DumpManager _dumpManager = null;

        /// <summary>
        /// Main application layout
        /// </summary>
        private TableLayoutPanel _layout = new TableLayoutPanel() {
            RowCount = 3, ColumnCount = 1, AutoSize = true, Dock = DockStyle.Fill, 
            BorderStyle = BorderStyle.FixedSingle, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };

        /// <inheritdoc cref="Form"/>
        protected override void Dispose(bool disposing) {
            if (disposing && (_components != null)) {
                _components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Main initialization
        /// </summary>
        private void InitializeComponent() {
            this._components = new System.ComponentModel.Container();
            this._dumpManager = new DumpManager(this._components);
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = WindowSize;
            this.MaximumSize = WindowSize;
            this.MinimumSize = WindowSize;
            
            this.Icon = new Icon(@"crocodile-32px.ico");

            this.Text = "CRCodile by amricko0b";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(this._layout);
            this.InitializeChildren();
        }

        /// <summary>
        /// Children initialization
        /// </summary>
        private void InitializeChildren() {
            var picker = new DumpPicker(this._layout);
            picker.IncomingFileSelected += _dumpManager.OnIncomingFileSelected;
            
            var typeLabel = new TypeLabel(this._layout);
            _dumpManager.DumpLoaded += typeLabel.OnDumpLoaded;
            
            var convertButton = new ConvertButton(this._layout);
            _dumpManager.DumpLoaded += convertButton.OnDumpLoaded;
            convertButton.OutputFileSelected += _dumpManager.OnOutputFileSelected;
        }
    }
}