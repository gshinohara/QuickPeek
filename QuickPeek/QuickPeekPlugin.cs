using Rhino.PlugIns;
using Rhino.UI;

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
            Panels.RegisterPanel(this, typeof(QuickPeekView), "QuickPeek", Properties.Resources.QuickPeek);
            return base.OnLoad(ref errorMessage);
        }
    }
}