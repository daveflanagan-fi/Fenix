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

        public delegate void ListViewItemSelectedHandler(ListViewItem item, int index);
        public event ListViewItemSelectedHandler OnItemSelected;

        private bool _moved = false;
        private float _velocity = 0;
        
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
                if (Engine.Inputs.MouseDelta.Y != 0)
                {
                    _moved = true;
                    ScrollPosition += Engine.Inputs.MouseDelta.Y;
                    _velocity = Engine.Inputs.MouseVelocity.Y;
                    NeedsRedraw = true;
                }
            }
            else
            {
                if (_velocity != 0)
                {
                    _velocity *= 0.9f;
                    ScrollPosition += _velocity * (float)Engine.GameTime.ElapsedGameTime.TotalSeconds * 10;
                    NeedsRedraw = true;
                }
                if (!Engine.Inputs.WasLeftPress())
                    _moved = false;
            }

            ScrollPosition = (int)MathHelper.Clamp(ScrollPosition, 0, ItemsHeight - Bounds.Height);
        }

        protected override void HandleInput()
        {
            if (Engine.Inputs.IsLeftClick() && !_moved)
            {
                if (OnItemSelected != null)
                {
                    Rectangle p = new Rectangle(Engine.Inputs.CurrentMousePosition.X, Engine.Inputs.CurrentMousePosition.Y, 1, 1);
                    p.X += VirtualBounds.X;
                    p.Y += VirtualBounds.Y;

                    int y = 0 - (int)ScrollPosition;
                    for (int i = 0; i < Children.Count; i++)
                    {
                        ListViewItem child = Children[i] as ListViewItem;
                        Rectangle r = new Rectangle(0, y, Bounds.Width, child.Height);
                        if (r.Intersects(p))
                        {
                            OnItemSelected(child, i);
                            break;
                        }
                        y += child.Height;
                    }
                }
            }
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
            ItemsHeight = y + (int)ScrollPosition;
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
