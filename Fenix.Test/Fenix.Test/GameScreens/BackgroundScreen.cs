using Fenix.GameObjects.UIObjects;
using Fenix.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fenix.Test.GameScreens
{
    public class BackgroundScreen : GameScreen
    {
        PictureBox pb;

        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            pb = new PictureBox();
            pb.Image = Engine.Contents.Load<Texture2D>("Content/Textures/Background");
            pb.SetSize(Width, Height);
            Add(pb);
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, false);
            pb.SetTint(Color.White * TransitionAlpha);
        }
    }
}
