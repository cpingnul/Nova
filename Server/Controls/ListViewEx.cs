using System.Windows.Forms;

namespace Nova.Controls
{
    public partial class ListViewEx : ListView
    {
        public ListViewEx()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }
    }
}
