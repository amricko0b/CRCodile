using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CRCodile.Lib;

namespace CRCodile.App {
    /// <summary>
    /// IO abstraction for dump management
    /// </summary>
    public partial class DumpManager : Component {
        /// <summary>
        /// Dump to process
        /// </summary>
        private RamDump _dump = null;

        /// <summary>
        /// Fires when incoming file read and processed
        /// </summary>
        public event EventHandler DumpLoaded;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Components container</param>
        public DumpManager(IContainer container) {
            container.Add(this);
        }

        /// <summary>
        /// Notify incoming file read
        /// </summary>
        public void OnIncomingFileSelected(object sender, EventArgs e) {
            if (e is PathEventArgs) {
                try {
                    var path = e.ToString();
                    this._dump = RamDump.FromFile(path);
                    DumpLoaded?.Invoke(this, new TypeEventArgs(this._dump.Type));
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Write conversion result
        /// </summary>
        public void OnOutputFileSelected(object sender, EventArgs e) {
            if (e is PathEventArgs) {
                try {
                    IRamTypeSwitcher switcher = RamTypeSwitcherFactory.CreateForSource(this._dump.Type);
                    var switched = switcher.SwitchType(this._dump);
                    File.WriteAllBytes(e.ToString(), switched.Bytes);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Successfully converted!", "Success", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }
    }
}