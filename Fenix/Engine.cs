using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix
{
    public static class Engine
    {
        public static Game Game { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static GameTime GameTime { get; private set; }
        public static Color ClearColor { get; private set; }

        public static GraphicsDevice GraphicsDevice {  get { return Game.GraphicsDevice; } }
        public static GameServiceContainer Services {  get { return Game.Services; } }

        public static GraphicsDeviceManager GraphicsManager { get; private set; }

        public static void Run()
        {
            Game = new Game();
            Game.Components.Add(new EngineHelper());
            GraphicsManager = new GraphicsDeviceManager(Game);
            Game.Run();
        }

        internal static void Initialize()
        {

        }

        internal static void LoadContent()
        {
            ClearColor = Color.CornflowerBlue;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        internal static void UnloadContent()
        {

        }

        internal static void Update(GameTime gameTime)
        {
            GameTime = gameTime;
        }

        internal static void Draw(GameTime gameTime)
        {
            GameTime = gameTime;
            GraphicsDevice.Clear(ClearColor);
        }
    }
}
