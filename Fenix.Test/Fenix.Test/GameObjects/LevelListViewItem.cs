using Fenix.GameObjects.UIObjects;
using Microsoft.Xna.Framework;

namespace Fenix.Test.GameObjects
{
    public class LevelListViewItem : ListViewItem
    {
        public string Text { get; set; }
        public int Score { get; set; }

        public LevelListViewItem(string text, int score)
        {
            Padding = 10;
            Height = 60;
            Text = text;
            Score = score;
        }

        protected override void Draw()
        {
            ListView lv = Parent as ListView;
            Vector2 textSize = lv.Font.MeasureString(Text);
            Vector2 textPosition = Position + (new Vector2(Padding, (Height - textSize.Y) / 2));
            Engine.SpriteBatch.Draw(Engine.UISheet.Texture, new Rectangle((int)Position.X, (int)Position.Y, lv.Bounds.Width, Height), Engine.UISheet[Even ? "LevelSelectEven" : "LevelSelectOdd"], lv.BackColor);
            Engine.SpriteBatch.DrawString(lv.Font, Text, textPosition, lv.ForeColor);
        }
    }
}
