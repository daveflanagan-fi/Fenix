using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fenix.GameObjects.UIObjects
{
    public class Button : Control
    {
        public event EventHandler OnClicked;

        public string Text { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public SpriteFont Font { get; set; }
        public bool IsMouseHovering { get; protected set; }

        public Button()
        {
            ForeColor = Color.White;
            BackColor = Color.White;
            Font = Engine.DefaultFont;
        }

        protected override void Update()
        {
            IsMouseHovering = Bounds.Contains(Engine.Inputs.CurrentMousePosition);

            if (OnClicked != null && Engine.Inputs.IsLeftClick() && IsMouseHovering)
                OnClicked(this, EventArgs.Empty);
        }

        protected override void Draw()
        {
            Rectangle topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner,
                topEdge, leftEdge, bottomEdge, rightEdge, inner;

            Rectangle b = Bounds;
            Vector2 textSize = Font.MeasureString(Text);
            Vector2 textPosition = new Vector2(Bounds.Center.X - (textSize.X / 2), Bounds.Center.Y - (textSize.Y / 2));

            if (IsMouseHovering)
            {
                topLeftCorner = Engine.UISheet["ButtonTopLeftCornerHover"];
                topRightCorner = Engine.UISheet["ButtonTopRightCornerHover"];
                bottomLeftCorner = Engine.UISheet["ButtonBottomLeftCornerHover"];
                bottomRightCorner = Engine.UISheet["ButtonBottomRightCornerHover"];
                topEdge = Engine.UISheet["ButtonTopEdgeHover"];
                leftEdge = Engine.UISheet["ButtonLeftEdgeHover"];
                bottomEdge = Engine.UISheet["ButtonBottomEdgeHover"];
                rightEdge = Engine.UISheet["ButtonRightEdgeHover"];
                inner = Engine.UISheet["ButtonInnerHover"];
                b.Y += 4;
                b.Height -= 4;
                textPosition.Y += 4;
            }
            else
            {
                topLeftCorner = Engine.UISheet["ButtonTopLeftCorner"];
                topRightCorner = Engine.UISheet["ButtonTopRightCorner"];
                bottomLeftCorner = Engine.UISheet["ButtonBottomLeftCorner"];
                bottomRightCorner = Engine.UISheet["ButtonBottomRightCorner"];
                topEdge = Engine.UISheet["ButtonTopEdge"];
                leftEdge = Engine.UISheet["ButtonLeftEdge"];
                bottomEdge = Engine.UISheet["ButtonBottomEdge"];
                rightEdge = Engine.UISheet["ButtonRightEdge"];
                inner = Engine.UISheet["ButtonInner"];
            }

            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left, b.Top, topLeftCorner.Width, topLeftCorner.Height), topLeftCorner, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Right - topRightCorner.Width, b.Y, topRightCorner.Width, topRightCorner.Height), topRightCorner, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left, b.Bottom - bottomLeftCorner.Height, bottomLeftCorner.Width, bottomLeftCorner.Height), bottomLeftCorner, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Right - bottomRightCorner.Width, b.Bottom - bottomRightCorner.Height, bottomRightCorner.Width, bottomRightCorner.Height), bottomRightCorner, BackColor);

            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left + topLeftCorner.Width, b.Top, b.Width - topLeftCorner.Width - topRightCorner.Width, topEdge.Height), topEdge, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left + bottomLeftCorner.Width, b.Bottom - bottomEdge.Height, b.Width - bottomLeftCorner.Width - bottomRightCorner.Width, bottomEdge.Height), bottomEdge, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left, b.Top + topLeftCorner.Height, leftEdge.Width, b.Height - topLeftCorner.Height - bottomLeftCorner.Height), leftEdge, BackColor);
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Right - rightEdge.Width, b.Top + topLeftCorner.Height, rightEdge.Width, b.Height - topRightCorner.Height - bottomRightCorner.Height), rightEdge, BackColor);

            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle(b.Left + topLeftCorner.Width, b.Top + topLeftCorner.Height, b.Width - topLeftCorner.Width - topRightCorner.Width, b.Height - topLeftCorner.Height - bottomLeftCorner.Height), inner, BackColor);

            Engine.SpriteBatch.DrawString(Font, Text, textPosition, ForeColor);
        }
    }
}
