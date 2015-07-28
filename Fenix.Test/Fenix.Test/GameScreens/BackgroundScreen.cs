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
        Button btn;

        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            pb = new PictureBox();
            pb.Image = Engine.Contents.Load<Texture2D>("Content/Textures/Background");
            pb.Size = new Vector2(Engine.Settings.Get<int>("Graphics.Virtual.Width"), Engine.Settings.Get<int>("Graphics.Virtual.Height"));
            Add(pb);

            btn = new Button();
            btn.Text = "Test Button";
            btn.Position = new Vector2(20, 20);
            btn.Size = new Vector2(pb.Size.X - (btn.Position.X * 2), 60);
            Add(btn);
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, false);
            pb.Tint = Color.White * TransitionAlpha;
        }
    }
}
