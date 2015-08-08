using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.GameScreens
{
    public class LoadingScreen : GameScreen
    {
        public GameScreen[] ScreensToLoad { get; private set; }
        public bool OtherScreensAreGone { get; private set; }

        public LoadingScreen(GameScreen[] screensToLoad)
        {
            ScreensToLoad = screensToLoad;
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public static void Load(params GameScreen[] screensToLoad)
        {
            foreach (GameScreen screen in Engine.Screens.GetScreens())
                screen.ExitScreen();
            Engine.Screens.Add(new LoadingScreen(screensToLoad));
        }

        public override void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(otherScreenHasFocus, coveredByOtherScreen);
            
            if (OtherScreensAreGone)
            {
                Engine.Screens.Remove(this);
                foreach (GameScreen screen in ScreensToLoad)
                    if (screen != null) Engine.Screens.Add(screen);
                Engine.Game.ResetElapsedTime();
            }
        }

        public override void Draw()
        {
            if (ScreenState == ScreenState.Active && Engine.Screens.GetScreens().Length == 1)
                OtherScreensAreGone = true;
            
            SpriteBatch spriteBatch = Engine.SpriteBatch;
            SpriteFont font = Engine.DefaultFont;

            const string message = "Loading...";
            
            Viewport viewport = Engine.GraphicsDevice.Viewport;
            Vector2 viewportSize = new Vector2(viewport.Width, viewport.Height);
            Vector2 textSize = font.MeasureString(message);
            Vector2 textPosition = (viewportSize - textSize) / 2;

            Color color = Color.White * TransitionAlpha;
            
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, textPosition, color);
            spriteBatch.End();
        }
    }
}
