using Rhino.PlugIns;
using Rhino.UI;
using System.Drawing;

namespace QuickPeek
{
    public class QuickPeekPlugin : PlugIn
    {
        public QuickPeekPlugin()
        {
            Instance = this;
        }

        public static QuickPeekPlugin Instance { get; private set; }

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            Panels.RegisterPanel(this, typeof(QuickPeekView), "QuickPeek", SystemIcons.Shield);
            return base.OnLoad(ref errorMessage);
        }
    }
}