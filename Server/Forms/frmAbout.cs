using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            rtxtContent.Text = Properties.Resources.TermsOfUse;
        }   
    }
}
