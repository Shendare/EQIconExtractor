/*
 *  EQIconExtractor.cs - Application for extracting EverQuest spell icons and item icons to individual png images
 *  
 *  By Shendare (Jon D. Jackson)
 * 
 *  Portions of this code not covered by another author's or entity's copyright are released under
 *  the Creative Commons Zero (CC0) public domain license.
 *  
 *  To the extent possible under law, Shendare (Jon D. Jackson) has waived all copyright and
 *  related or neighboring rights to this EQIconExtractor application.
 *  This work is published from: The United States. 
 *  
 *  You may copy, modify, and distribute the work, even for commercial purposes, without asking permission.
 * 
 *  For more information, read the CC0 summary and full legal text here:
 *  
 *  https://creativecommons.org/publicdomain/zero/1.0/
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Paloma;
using DDS;

namespace EQIconExtractor
{
    public partial class Form1 : Form
    {
        private string _InputFolder;
        private string _OutputFolder;

        private int _SpellIcons;
        private int _ItemIcons;

        private int _TotalSpellIconCount;
        private int _TotalItemIconCount;

        private const int _SpellIconsPerFile = 36;
        private const int _ItemIconsPerFile = 36;

        private static Point _SpellIconStart = new Point(0, 0);
        private static Point _SpellIconSize = new Point(40, 40);
        private static Point _SpellIconPadding = new Point (0, 0);

        private static Point _ItemIconSize = new Point(40, 40);
        private static Point _ItemIconPadding = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textInputPath.Text = Properties.Settings.Default.InputFolder;
            textOutputPath.Text = Properties.Settings.Default.OutputFolder;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            buttonConvert.Enabled = false;
            buttonCancel.Enabled = true;

            _TotalItemIconCount = 0;
            _TotalSpellIconCount = 0;

            _InputFolder = textInputPath.Text;
            _OutputFolder = textOutputPath.Text;

            threadSpellIcons.RunWorkerAsync();
        }

        private void threadSpellIcons_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] _files;

            e.Result = DialogResult.Abort;

            try
            {
                _files = Directory.GetFiles(_InputFolder, "spells??.tga");
                string _outPath = _OutputFolder;

                if (!Directory.Exists(_outPath))
                {
                    Directory.CreateDirectory(_outPath);
                }

                _SpellIcons = _files.Length * _SpellIconsPerFile;

                int _count = 0;

                string _spellFileName;

                for (int _spellIconSheet = 0; _spellIconSheet < 100; _spellIconSheet++)
                {
                    if (File.Exists(_spellFileName = _InputFolder + @"\spells" + (_spellIconSheet + 1).ToString("00") + ".tga"))
                    {
                        int _x = _SpellIconStart.X;
                        int _y = _SpellIconStart.Y;
                        int _iconIndex = 0;

                        TargaImage _iconSheet = new TargaImage(_spellFileName);

                        while ((_y + _SpellIconSize.Y) < _iconSheet.Image.Height)
                        {
                            string _outFile = _outPath + @"\" + ((_spellIconSheet * _SpellIconsPerFile) + _iconIndex).ToString() + ".png";

                            Bitmap _icon = new Bitmap(_SpellIconSize.X, _SpellIconSize.Y, _iconSheet.Image.PixelFormat);
                            Graphics _blitter = Graphics.FromImage(_icon);
                            _blitter.DrawImage(_iconSheet.Image, 0, 0, new Rectangle(_x, _y, _SpellIconSize.X, _SpellIconSize.Y), GraphicsUnit.Pixel);
                            _blitter.Dispose();
                            _icon.Save(_outFile);
                            _icon.Dispose();

                            _iconIndex++;
                            _x += _SpellIconSize.X + _SpellIconPadding.X;

                            if ((_x + _SpellIconSize.X) >= _iconSheet.Image.Width)
                            {
                                _x = _SpellIconStart.X;
                                _y += _SpellIconSize.Y + _SpellIconPadding.Y;
                            }

                            _TotalSpellIconCount++;
                            threadSpellIcons.ReportProgress(_count++);

                            if (threadSpellIcons.CancellationPending)
                            {
                                e.Result = DialogResult.Cancel;

                                return;
                            }
                        }

                        _iconSheet.Dispose();
                    }
                }
            }
            catch
            {
                return;
            }

            e.Result = DialogResult.OK;

            return;
        }

        private void threadSpellIcons_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressSpellIcons.Maximum = _SpellIcons;
            progressSpellIcons.Value = e.ProgressPercentage;
        }

        private void threadSpellIcons_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressSpellIcons.Value = progressSpellIcons.Maximum;

            threadItemIcons.RunWorkerAsync();
        }


        private void threadItemIcons_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] _files;

            e.Result = DialogResult.Abort;

            try
            {
                _files = Directory.GetFiles(_InputFolder, "dragitem*.dds");
                string _outPath = _OutputFolder;

                if (!Directory.Exists(_outPath))
                {
                    Directory.CreateDirectory(_outPath);
                }

                _ItemIcons = _files.Length * _ItemIconsPerFile;

                int _count = 1;
                string _iconFileName;

                for (int _itemIconSheet = 0; _itemIconSheet < 500; _itemIconSheet++)
                {
                    if (File.Exists(_iconFileName = _InputFolder + @"\dragitem" + (_itemIconSheet + 1).ToString() + ".dds"))
                    {
                        int _iconIndex = 0;
                        int _x = 0;
                        int _y = 0;

                        byte[] _fileBytes = GetFileBytes(_iconFileName);

                        DDSImage _iconSheet = DDSImage.Load(_fileBytes);

                        while ((_x + _ItemIconSize.X) < _iconSheet.Images[0].Width)
                        {
                            string _outFile = _outPath + @"\" + ((_itemIconSheet * _ItemIconsPerFile) + _iconIndex + 500).ToString() + ".png";

                            Bitmap _icon = new Bitmap(_ItemIconSize.X, _ItemIconSize.Y, _iconSheet.Images[0].PixelFormat);
                            Graphics _blitter = Graphics.FromImage(_icon);
                            
                            _blitter.DrawImage(_iconSheet.Images[0], 0, 0, new Rectangle(_x, _y, _ItemIconSize.X, _ItemIconSize.Y), GraphicsUnit.Pixel);
                            _blitter.Dispose();
                            _icon.Save(_outFile);
                            _icon.Dispose();

                            _iconIndex++;
                            _y += _ItemIconSize.Y + _ItemIconPadding.Y;

                            if ((_y + _ItemIconSize.Y) >= _iconSheet.Images[0].Height)
                            {
                                _y = 0;
                                _x += _ItemIconSize.X + _ItemIconPadding.X;
                            }

                            _TotalItemIconCount++;
                            threadItemIcons.ReportProgress(_count++);

                            if (threadItemIcons.CancellationPending)
                            {
                                e.Result = DialogResult.Cancel;

                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }


            e.Result = DialogResult.OK;

            return;
        }

        private void threadItemIcons_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressItemIcons.Maximum = _ItemIcons;
            progressItemIcons.Value = e.ProgressPercentage;
        }

        private void threadItemIcons_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressItemIcons.Value = progressItemIcons.Maximum;
            
            buttonCancel.Enabled = false;
            buttonConvert.Enabled = true;

            MessageBox.Show("Spell Icons Extracted: " + _TotalSpellIconCount.ToString() + "\r\nItem Icons Extracted: " + _TotalItemIconCount.ToString());
        }

        protected byte[] GetFileBytes(string Filename)
        {
            FileStream _file = File.OpenRead(Filename);

            byte[] _bytes = new byte[(int)_file.Length];

            _file.Read(_bytes, 0, (int)_file.Length);

            _file.Close();

            return _bytes;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            threadSpellIcons.CancelAsync();
            threadItemIcons.CancelAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.InputFolder = textInputPath.Text;
            Properties.Settings.Default.OutputFolder = textOutputPath.Text;
            Properties.Settings.Default.Save();
        }

        private void buttonInputPath_Click(object sender, EventArgs e)
        {
            folderFinder.SelectedPath = textInputPath.Text;

            switch (folderFinder.ShowDialog())
            {
                case DialogResult.OK:
                    textInputPath.Text = folderFinder.SelectedPath;
                    break;
            }
        }

        private void buttonOutputPath_Click(object sender, EventArgs e)
        {
            folderFinder.SelectedPath = textOutputPath.Text;

            switch (folderFinder.ShowDialog())
            {
                case DialogResult.OK:
                    textOutputPath.Text = folderFinder.SelectedPath;
                    break;
            }
        }
    }
}
