using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.GameObjects.UIObjects
{
    public abstract class Control : GameObject
    {
        public Vector2 Size { get; set; }
        public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); } }
    }
}
