using Fenix.Graphics;
using Fenix.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fenix
{
    public static class Engine
    {
        public static Game Game { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static GameTime GameTime { get; private set; }
        public static Color ClearColor { get; private set; }
        public static SpriteSheet UISheet { get; private set; }
        public static Texture2D BlankTexture { get; private set; }
        public static SpriteFont DefaultFont { get; private set; }

        public static GraphicsDevice GraphicsDevice {  get { return Game.GraphicsDevice; } }
        public static GameServiceContainer Services {  get { return Game.Services; } }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SettingsManager Settings { get; private set; }

        public static void Run()
        {
            Game = new Game();
            Game.Components.Add(new EngineHelper());

            Settings = new SettingsManager();
            Graphics = new GraphicsDeviceManager(Game);

            Graphics.PreferredBackBufferWidth = Settings.Get<int>("Graphics.Window.Width");
            Graphics.PreferredBackBufferHeight = Settings.Get<int>("Graphics.Window.Height");
            Graphics.IsFullScreen = Settings.Get<bool>("Graphics.Window.Fullscreen");

            Game.Run();
        }

        internal static void Initialize()
        {

        }

        internal static void LoadContent()
        {
            ClearColor = Color.CornflowerBlue;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            UISheet = new SpriteSheet("Content/Textures/UI.xml");
            BlankTexture = new Texture2D(GraphicsDevice, 1, 1);
            BlankTexture.SetData(new Color[1] { Color.White });
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
