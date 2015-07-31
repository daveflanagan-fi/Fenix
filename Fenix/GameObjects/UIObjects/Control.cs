using Fenix.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fenix.GameObjects.UIObjects
{
    public abstract class Control : GameObject
    {
        public Vector2 Size { get; private set; }
        public bool NeedsRedraw { get; set; }
        public RenderTarget2D Buffer { get; private set; }
        public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); } }
        public Rectangle VirtualBounds { get { return new Rectangle(0, 0, (int)Size.X, (int)Size.Y); } }

        public Control()
        {
            NeedsRedraw = true;
        }

        public Control SetSize(int width, int height)
        {
            if (width == Size.X && height == Size.Y) return this;
            Size = new Vector2(width, height);
            Buffer = new RenderTarget2D(Engine.GraphicsDevice, width, height);
            NeedsRedraw = true;
            return this;
        }

        public Control SetPosition(float x, float y)
        {
            if (x == Position.X && y == Position.Y) return this;
            Position = new Vector2(x, y);
            NeedsRedraw = true;
            return this;
        }

        protected virtual void Redraw() { }

        protected override void PreDraw()
        {
            if (NeedsRedraw)
            {
                NeedsRedraw = false;
                Engine.GraphicsDevice.SetRenderTarget(Buffer);
                Engine.GraphicsDevice.Clear(Color.Transparent);
                Redraw();
                Engine.GraphicsDevice.SetRenderTarget(null);
            }
        }

        protected override void Draw()
        {
            Engine.SpriteBatch.Begin();
            Engine.SpriteBatch.Draw(Buffer, Bounds, Color.White);
            Engine.SpriteBatch.End();
        }
    }
}
