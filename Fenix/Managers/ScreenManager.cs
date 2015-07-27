using Fenix.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fenix.Managers
{
    public class ScreenManager
    {
        List<GameScreen> screens = new List<GameScreen>();
        List<GameScreen> screensToUpdate = new List<GameScreen>();
        bool isInitialized;
                
        internal void LoadContent()
        {
            isInitialized = true;
            foreach (GameScreen screen in screens)
                screen.LoadContent();
        }

        internal void UnloadContent()
        {
            foreach (GameScreen screen in screens)
                screen.UnloadContent();
        }

        internal void Update()
        {
            screensToUpdate.Clear();

            foreach (GameScreen screen in screens)
                screensToUpdate.Add(screen);

            bool otherScreenHasFocus = !Engine.Game.IsActive;
            bool coveredByOtherScreen = false;
            
            while (screensToUpdate.Count > 0)
            {
                GameScreen screen = screensToUpdate[screensToUpdate.Count - 1];
                screensToUpdate.RemoveAt(screensToUpdate.Count - 1);
                screen.Update(otherScreenHasFocus, coveredByOtherScreen);

                if (screen.ScreenState == ScreenState.TransitionOn || screen.ScreenState == ScreenState.Active)
                {
                    if (!otherScreenHasFocus)
                    {
                        screen.HandleInput();
                        otherScreenHasFocus = true;
                    }

                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }
        }

        internal void Draw()
        {
            foreach (GameScreen screen in screens)
            {
                if (screen.ScreenState == ScreenState.Hidden)
                    continue;
                screen.Draw();
            }
        }
        
        public void Add(GameScreen screen, PlayerIndex? controllingPlayer)
        {
            screen.ControllingPlayer = controllingPlayer;
            screen.IsExiting = false;
            
            if (isInitialized)
                screen.LoadContent();
            screens.Add(screen);
        }
        
        public void Remove(GameScreen screen)
        {
            if (isInitialized)
                screen.UnloadContent();

            screens.Remove(screen);
            screensToUpdate.Remove(screen);
        }
        
        public GameScreen[] GetScreens()
        {
            return screens.ToArray();
        }
        
        public void FadeToBlack(float alpha)
        {
            Viewport viewport = Engine.GraphicsDevice.Viewport;
            Engine.SpriteBatch.Draw(Engine.BlankTexture, Engine.Bounds, Color.Black * alpha);
        }
    }
}
