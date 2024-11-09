using System.Windows.Forms;

namespace BitCraft.UserControls
{
    public class GraphicsPanel : Panel
    {
        public GraphicsPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
