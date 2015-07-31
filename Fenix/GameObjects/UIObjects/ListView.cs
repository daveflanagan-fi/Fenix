using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fenix.GameObjects.UIObjects
{
    public class ListView : Control
    {
        public float ScrollPosition { get { return ScrollBar.ScrollPosition; } set { ScrollBar.ScrollPosition = value; } }
        public ScrollBar ScrollBar { get; private set; }

        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public SpriteFont Font { get; set; }
        public int ItemsHeight { get; private set; }
        
        public ListView()
        {
            Font = Engine.DefaultFont;
            ForeColor = Color.White;
            BackColor = Color.White;
            ScrollBar = new ScrollBar();
        }

        protected override void Update()
        {
            base.Update();

            if (Engine.Inputs.IsLeftPress())
            {
                ScrollPosition += Engine.Inputs.MouseDelta.Y;
                NeedsRedraw = true;
            }

            ScrollPosition = (int)MathHelper.Clamp(ScrollPosition, 0, ItemsHeight - Bounds.Height);
        }

        public override void AddChild(GameObject child)
        {
            if (child is ListViewItem == false) return;
            base.AddChild(child);
            NeedsRedraw = true;
        }

        public override void RemoveChild(GameObject child)
        {
            if (child is ListViewItem == false) return;
            base.RemoveChild(child);
            NeedsRedraw = true;
        }

        protected override void Redraw()
        {
            Engine.SpriteBatch.Begin();
            int y = 0 - (int)ScrollPosition;
            for (int i = 0; i < Children.Count; i++)
            {
                ListViewItem child = Children[i] as ListViewItem;
                Rectangle r = new Rectangle(0, y, Bounds.Width, child.Height);
                if (VirtualBounds.Intersects(r))
                    DrawItem(i, new Point(0, y));
                y += child.Height;
            }
            ItemsHeight = y + 60;
            Engine.SpriteBatch.End();
        }

        protected virtual void DrawItem(int index, Point topLeft)
        {
            ListViewItem item = Children[index] as ListViewItem;
            item.Position = new Vector2(topLeft.X, topLeft.Y);
            item.Even = index % 2 == 0;
            item.DoDraw();
        }
    }
}
