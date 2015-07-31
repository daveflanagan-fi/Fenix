using Fenix.GameObjects.UIObjects;
using Fenix.GameScreens;
using Fenix.Test.GameObjects;
using System;

namespace Fenix.Test.GameScreens
{
    public class LevelSelectScreen : GameScreen
    {
        ListView list;
        Panel pnl;

        public LevelSelectScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            pnl = new Panel();
            pnl.SetPosition(20, 20).SetSize(Width -  40, Height - 40);
            Add(pnl);

            list = new ListView();
            list.SetPosition(10, 10).SetSize(Width - 60, Height - 60);
            list.ScrollPosition = 20;

            for (int i = 1; i <= 100; i++)
                list.AddChild(new LevelListViewItem("Test " + i, 0));

            pnl.AddChild(list);
            Add(list);
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (Engine.Inputs.IsMenuCancel())
                ExitScreen();
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, coveredByOtherScreen);

            if (ScreenState == ScreenState.TransitionOff)
            {
                float transitionOffset = (float)Math.Pow(TransitionPosition, 2);
                pnl.SetPosition(20, 20 - (transitionOffset * (Height * 2)));
            }
            else
            {
                float transitionOffset = (float)Math.Pow(TransitionPosition, 4);
                pnl.SetPosition(20, 20 + (transitionOffset * Height));
            }
        }
    }
}
