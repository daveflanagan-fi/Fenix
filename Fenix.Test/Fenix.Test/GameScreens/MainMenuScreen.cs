using Fenix.GameObjects.UIObjects;
using Fenix.GameScreens;
using Microsoft.Xna.Framework;
using System;

namespace Fenix.Test.GameScreens
{
    public class MainMenuScreen : GameScreen
    {
        Button btn;

        public MainMenuScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            btn = new Button();
            btn.Text = "Play";
            btn.SetPosition(20, 20).SetSize(Width - 40, 60);
            btn.OnClicked += Btn_OnClicked;
            Add(btn);
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (Engine.Inputs.IsMenuCancel())
                Engine.Game.Exit();
        }

        private void Btn_OnClicked(object sender, EventArgs e)
        {
            Engine.Screens.Add(new LevelSelectScreen());
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, coveredByOtherScreen);
            
            if (ScreenState == ScreenState.TransitionOn)
            {
                float transitionOffset = (float)Math.Pow(TransitionPosition, 4);
                btn.SetPosition(20, Height - 80 + (transitionOffset * 100));
            }
        }
    }
}
