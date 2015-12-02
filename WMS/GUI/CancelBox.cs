using System;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class CancelBox : Form
    {
        public CancelBox(ILang lang)
        {
            InitializeComponent();
            //Sets text based on language
            cancelLabel.Text = lang.CANCELBOXTEXT;
            yesButton.Text = lang.YES;
            noButton.Text = lang.NO;
            Text = lang.CANCEL;
        }
        
        private void CancelBoxLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void NoButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void YesButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
