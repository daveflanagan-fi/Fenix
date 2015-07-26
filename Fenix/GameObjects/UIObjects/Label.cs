using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fenix.GameObjects.UIObjects
{
    public class Label : Control
    {
        protected string _inputText = "";
        protected string _formatText = "";

        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public SpriteFont Font { get; set; }
        public int Padding { get; set; }

        public string Text
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                formatText(value);
            }
        }

        public Label()
        {
            Font = Engine.DefaultFont;
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Padding = 0;
        }

        private void formatText(string value)
        {
            _formatText = "";
            if (value == "") return;

            string[] words = value.Split(' ');
            string line = "";

            foreach (string word in words)
            {
                string temp = line + word + " ";

                if (Font.MeasureString(temp).X > Size.X - (Padding * 2))
                {
                    _formatText += line + "\n";
                    temp = word + " ";
                }

                line = temp;
            }
        }

        protected override void Draw()
        {
            if (BackColor.A > 0) Engine.SpriteBatch.Draw(Engine.BlankTexture, Bounds, BackColor);
            Engine.SpriteBatch.DrawString(Font, _formatText, Position + new Vector2(Padding, Padding), ForeColor);
        }
    }
}
