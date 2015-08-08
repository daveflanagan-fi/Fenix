using Fenix.GameObjects.UIObjects;
using Fenix.GameScreens;

namespace Fenix.Test.GameScreens
{
    public class TestScreen : GameScreen
    {
        public TestScreen()
        {
            Panel pnl = new Panel();
            pnl.SetPosition(20, 20).SetSize(Width - 40, Height / 2);
            Add(pnl);
        }
    }
}
