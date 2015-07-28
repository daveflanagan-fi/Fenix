using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Linq;

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
            Sprites = new Dictionary<string, Rectangle>();
            XDocument doc = XDocument.Load(file);
            Texture = Engine.Contents.Load<Texture2D>(doc.Root.Attribute("imagePath").Value);

            foreach (XElement node in doc.Root.Elements("SubTexture"))
            {
                if (string.IsNullOrEmpty(node.Attribute("x").Value)) continue;
                Sprites.Add(node.Attribute("name").Value, new Rectangle(
                        int.Parse(node.Attribute("x").Value),
                        int.Parse(node.Attribute("y").Value),
                        int.Parse(node.Attribute("width").Value),
                        int.Parse(node.Attribute("height").Value)
                    ));
            }
        }
    }
}
