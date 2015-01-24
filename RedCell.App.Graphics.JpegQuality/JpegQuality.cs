using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    Worker.RunWorkerAsync(list.ToArray());
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets/sets the quality.
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
                bool valid = !Worker.IsBusy;
                foreach (string file in files)
                    if (!Regex.IsMatch(file, @"\.jpe?g$", RegexOptions.IgnoreCase))
                        valid = false;

                if (valid)
                    Worker.RunWorkerAsync(files.ToArray());
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
            bool valid = !Worker.IsBusy;
            foreach (string file in files)
                if (!Regex.IsMatch(file, @"\.jpe?g$", RegexOptions.IgnoreCase))
                    valid = false;

            e.Effect = valid ? DragDropEffects.Copy : DragDropEffects.None;
        }

        /// <summary>
        /// Processes the images.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <exception cref="System.IO.FileNotFoundException">File does not exist.</exception>
        private void ProcessImages(string[] files)
        {
            int complete = 0;
            Worker.ReportProgress(complete, files.Length);

            foreach (string file in files)
            {
                if (Worker.CancellationPending)
                    return;

                var info = new FileInfo(file);
                if (!info.Exists) 
                    throw new FileNotFoundException("File does not exist.", info.FullName);

                var path = info.DirectoryName + @"\" + info.Name.Replace(info.Extension, "") + "-" + Quality + info.Extension;
                ProcessImage(info.FullName, path);
                Worker.ReportProgress(++complete, files.Length);
            }
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the QualityBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void QualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Quality = int.Parse((sender as ToolStripComboBox).Text);
        }

        /// <summary>
        /// Handles the DoWork event of the Worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void ProcessImagesAsync(object sender, DoWorkEventArgs e)
        {
            ProcessImages(e.Argument as string[]);
        }

        /// <summary>
        /// Handles the ProgressChanged event of the Worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int value = e.ProgressPercentage;
            int maximum = (int) e.UserState;
            Invoke(new Action<int, int>(UpdateProgressBar), value, maximum);
        }

        /// <summary>
        /// Updates the progress bar.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maximum">The maximum.</param>
        private void UpdateProgressBar(int value, int maximum)
        {
            ProgressBar.Value = value;
            ProgressBar.Maximum = maximum;
            ProgressBar.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Worker.CancelAsync();
        }
    }
}
