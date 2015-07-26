using Microsoft.Xna.Framework;

namespace Fenix.GameObjects.UIObjects
{
    public abstract class Control : GameObject
    {
        public Vector2 Size { get; set; }
        public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); } }
    }
}
