using Fenix.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fenix.Test.GameScreens
{
    public class BackgroundScreen : GameScreen
    {
        Texture2D background;

        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            background = Engine.Contents.Load<Texture2D>("Content/Textures/Background");
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, false);
        }

        public override void Draw()
        {
            Engine.SpriteBatch.Draw(background, new Rectangle(0, 0, Engine.Settings.Get<int>("Graphics.Virtual.Width"), Engine.Settings.Get<int>("Graphics.Virtual.Height")), Color.White * TransitionAlpha);
        }
    }
}
