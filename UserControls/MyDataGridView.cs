using System.Windows.Forms;

namespace BitCraft.UserControls
{
    public partial class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
        }
    }
}
