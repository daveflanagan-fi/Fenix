using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fenix.GameObjects.UIObjects
{
    public class PictureBox : Control
    {
        public Texture2D Image { get; set; }
        public Color Tint { get; set; }

        public PictureBox()
        {
            Image = null;
            Tint = Color.White;
        }

        public PictureBox(Texture2D image)
        {
            Image = image;
            Tint = Color.White;
        }

        public PictureBox(Texture2D image, Color tint)
        {
            Image = image;
            Tint = tint;
        }

        public void SetTint(Color color)
        {
            if (Tint == color) return;
            Tint = color;
            NeedsRedraw = true;
        }

        protected override void Redraw()
        {
            if (Image != null)
            {
                Engine.SpriteBatch.Begin();
                Engine.SpriteBatch.Draw(Image, new Rectangle(0, 0, (int)Size.X, (int)Size.Y), Tint);
                Engine.SpriteBatch.End();
            }
        }
    }
}
