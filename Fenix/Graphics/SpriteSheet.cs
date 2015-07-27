using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fenix.Graphics
{
    public class SpriteSheet
    {
        public Texture2D Texture { get; private set; }
        public Dictionary<string, Rectangle> Sprites { get; private set; }

        public Rectangle this[string name]
        {
            get { return Sprites.ContainsKey(name) ? Sprites[name] : Rectangle.Empty; }
        }

        public SpriteSheet(string file)
        {

        }
    }
}
