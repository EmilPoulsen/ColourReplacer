using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceColour
{
    public partial class dlgReplaceColour : Form
    {
        ImageHandler _imgHandler;
        //private int _numOfColours;
        //private int _numOfSigns;
        private bool _selectDeselect;
        private int _selCol;

        public dlgReplaceColour()
        {
            InitializeComponent();
            _imgHandler = new ImageHandler();
            InitializeOpenFileDialog();
            UpdateStatus(0);
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files. 
            //this.openFileDialog.Filter =
            //    "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
            //    "All files (*.*)|*.*";

            // Allow the user to select multiple images. 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select source bitmaps";
        }

        private void UpdateStatus(int filesSelected)
        {
            string singPlur = null;

            if (filesSelected == 1)
                singPlur = " file";
            else
                singPlur = " files";

            lblStatus.Text = filesSelected + singPlur + " selected";
        }

        private void RegisterColours()
        {

            _imgHandler.ClearSignColourList();

            _selCol = 0;

            if (cbxWhiteBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.WhiteBlack.Background,
                    SignColours.WhiteBlack.Text, SignColours.WhiteBlack.Name);
                _selCol++;
            }
            if (cbxRedWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.RedWhite.Background,
                    SignColours.RedWhite.Text, SignColours.RedWhite.Name);
                _selCol++;
            }
            if (cbxYellowBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.YellowBlack.Background,
                    SignColours.YellowBlack.Text, SignColours.YellowBlack.Name);
                _selCol++;
            }
            if (cbxGreenWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.GreenWhite.Background,
                    SignColours.GreenWhite.Text, SignColours.GreenWhite.Name);
                _selCol++;
            }
            if (cbxBlackWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.BlackWhite.Background,
                    SignColours.BlackWhite.Text, SignColours.BlackWhite.Name);
                _selCol++;
            }
            if (cbxBlueWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.BlueWhite.Background,
                    SignColours.BlueWhite.Text, SignColours.BlueWhite.Name);
                _selCol++;
            }
            if (cbxSilverBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.SilverBlack.Background,
                    SignColours.SilverBlack.Text, SignColours.SilverBlack.Name);
                _selCol++;
            }
            if (cbxGoldBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.GoldBlack.Background,
                    SignColours.GoldBlack.Text, SignColours.GoldBlack.Name);
                _selCol++;
            }
            if (cbxBrownWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.BrownWhite.Background,
                    SignColours.BrownWhite.Text, SignColours.BrownWhite.Name);
                _selCol++;
            }
            if (cbxOrangeWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.OrangeWhite.Background,
                    SignColours.OrangeWhite.Text, SignColours.OrangeWhite.Name);
                _selCol++;
            }
            if (cbxWhiteRed.Checked)
            {
                _imgHandler.CreateSign(SignColours.WhiteRed.Background,
                    SignColours.WhiteRed.Text, SignColours.WhiteRed.Name);
                _selCol++;
            }
            if (cbxYellowRed.Checked)
            {
                _imgHandler.CreateSign(SignColours.YellowRed.Background,
                    SignColours.YellowRed.Text, SignColours.YellowRed.Name);
                _selCol++;
            }
            if (cbxGreenBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.GreenBlack.Background,
                    SignColours.GreenBlack.Text, SignColours.GreenBlack.Name);
                _selCol++;
            }
            if (cbxBlueBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.BlueBlack.Background,
                    SignColours.BlueBlack.Text, SignColours.BlueBlack.Name);
                _selCol++;
            }
            if (cbxRedBlack.Checked)
            {
                _imgHandler.CreateSign(SignColours.RedBlack.Background,
                    SignColours.RedBlack.Text, SignColours.RedBlack.Name);
                _selCol++;
            }
            if (cbxGreyWhite.Checked)
            {
                _imgHandler.CreateSign(SignColours.GreyWhite.Background,
                    SignColours.GreyWhite.Text, SignColours.GreyWhite.Name);
                _selCol++;
            }
            if (cbxWhiteBlue.Checked)
            {
                _imgHandler.CreateSign(SignColours.WhiteBlue.Background,
                    SignColours.WhiteBlue.Text, SignColours.WhiteBlue.Name);
                _selCol++;
            }
        }




        private void btnRun_Click(object sender, EventArgs e)
        {

            RegisterColours();

            try
            {
                _imgHandler.Run();
                ShowStatus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ShowStatus()
        {
            string singPlur = null;

            int prod = _selCol * openFileDialog.FileNames.Length;

            if (prod == 1)
                singPlur = " image was ";
            else
                singPlur = " images were ";

            MessageBox.Show(prod + singPlur + "created", "Duplication completed");
        }


        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            //openFileDialog.ShowDialog();
            DialogResult dr = this.openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                UpdateStatus(openFileDialog.FileNames.Length);
                _imgHandler.ClearBitmapList();
                // Read the files 
                foreach (string file in openFileDialog.FileNames)
                {
                    _imgHandler.RegisterBitmapSource(file);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            bool localCheck = _selectDeselect;

            cbxBlackWhite.Checked = localCheck;
            cbxBlueWhite.Checked = localCheck;
            cbxBrownWhite.Checked = localCheck;
            cbxGoldBlack.Checked = localCheck;
            cbxGreenWhite.Checked = localCheck;
            cbxOrangeWhite.Checked = localCheck;
            cbxRedWhite.Checked = localCheck;
            cbxSilverBlack.Checked = localCheck;
            cbxWhiteBlack.Checked = localCheck;
            cbxWhiteRed.Checked = localCheck;
            cbxYellowBlack.Checked = localCheck;
            cbxYellowRed.Checked = localCheck;
            cbxGreenBlack.Checked = localCheck;
            cbxBlueBlack.Checked = localCheck;
            cbxRedBlack.Checked = localCheck;
            cbxGreyWhite.Checked = localCheck;
            cbxWhiteBlue.Checked = localCheck;

            _selectDeselect = !_selectDeselect;
        }
    }
}
