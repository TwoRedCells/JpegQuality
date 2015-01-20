using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RedCell.Apps.Graphics
{
    /// <summary>
    /// Class JpegQuality.
    /// </summary>
    public partial class JpegQuality : Form
    {
        private const int DefaultQuality = 60;
        private const string RegistryRoot = @"HKEY_CURRENT_USER\Software\Red Cell Innovation Inc.\JpegQuality";

        /// <summary>
        /// Initializes a new instance of the <see cref="JpegQuality"/> class.
        /// </summary>
        public JpegQuality()
        {
            try
            {
                InitializeComponent();

                if (Registry.GetValue(RegistryRoot, "Quality", DefaultQuality) == null)
                    Quality = DefaultQuality;

                QualityBox.Text = Quality.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Activated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            try
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    var list = new List<string>(args);
                    list.RemoveAt(0); // First argument is path to exe.
                    ProcessImages(list);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public int Quality
        {
            get { return (int) Registry.GetValue(RegistryRoot, "Quality", DefaultQuality); }
            set { Registry.SetValue(RegistryRoot, "Quality", value); }
        }

        /// <summary>
        /// Handles the DragDrop event of the DropLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void DropLabel_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = new List<string>(e.Data.GetData("FileDrop") as string[] ?? new string[0]);
                bool valid = true;
                foreach (string file in files)
                    if (!Regex.IsMatch(file, @"\.jpe?g$", RegexOptions.IgnoreCase))
                        valid = false;

                if (valid)
                    ProcessImages(files);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the DragOver event of the DropLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void DropLabel_DragOver(object sender, DragEventArgs e)
        {
            var files = new List<string>(e.Data.GetData("FileDrop") as string[] ?? new string[0]);
            bool valid = true;
            foreach (string file in files)
                if (!Regex.IsMatch(file, @"\.jpe?g$", RegexOptions.IgnoreCase))
                    valid = false;

            e.Effect = valid ? DragDropEffects.Copy : DragDropEffects.None;
        }

        /// <summary>
        /// Handles the Validated event of the QualityBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void QualityBox_Validated(object sender, EventArgs e)
        {
            Quality = int.Parse((sender as ToolStripComboBox).SelectedText);
        }

        /// <summary>
        /// Processes the images.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <exception cref="System.IO.FileNotFoundException">File does not exist.</exception>
        private void ProcessImages(IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                var info = new FileInfo(file);
                if (!info.Exists) 
                    throw new FileNotFoundException("File does not exist.", info.FullName);

                var directory = info.Directory;
                var path = info.DirectoryName + @"\" + info.Name.Replace(info.Extension, "") + "-" + Quality + info.Extension;
                ProcessImage(info.FullName, path);
            }
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private void ProcessImage(string source, string destination)
        {
            using (var original = Bitmap.FromFile(source))
            {
                var encoder =  ImageCodecInfo.GetImageEncoders().Single(e => e.MimeType == "image/jpeg");
                var options = new EncoderParameters(1);
                options.Param[0] = new EncoderParameter(Encoder.Quality, Quality);
                original.Save(destination, encoder, options);
            }
        }
    }
}
