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

        protected override void Draw()
        {
            if (Image != null) Engine.SpriteBatch.Draw(Image, Bounds, Tint);
        }
    }
}
