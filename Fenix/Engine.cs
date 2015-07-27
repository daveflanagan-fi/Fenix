using Fenix.GameScreens;
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
        public static RenderTarget2D Buffer { get; private set; }

        public static GraphicsDevice GraphicsDevice {  get { return Game.GraphicsDevice; } }
        public static GameServiceContainer Services {  get { return Game.Services; } }
        public static Rectangle Bounds {  get { return GraphicsDevice.Viewport.Bounds; } }

        public static ContentManager Contents { get; private set; }
        public static GraphicsDeviceManager Graphics { get; private set; }
        public static InputManager Inputs { get; private set; }
        public static ScreenManager Screens { get; private set; }
        public static SettingsManager Settings { get; private set; }

        public static void Run(params GameScreen[] screens)
        {
            Game = new Game();
            Game.Components.Add(new EngineHelper());

            Contents = new ContentManager();
            Graphics = new GraphicsDeviceManager(Game);
            Inputs = new InputManager();
            Screens = new ScreenManager();
            Settings = new SettingsManager();

            Graphics.PreferredBackBufferWidth = Settings.Get<int>("Graphics.Window.Width");
            Graphics.PreferredBackBufferHeight = Settings.Get<int>("Graphics.Window.Height");
            Graphics.IsFullScreen = Settings.Get<bool>("Graphics.Window.Fullscreen");

            foreach (GameScreen screen in screens)
                Screens.Add(screen, null);

            Game.Run();
        }

        internal static void Initialize()
        {

        }

        internal static void LoadContent()
        {
            ClearColor = Color.Black;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            UISheet = new SpriteSheet("Content/Textures/UI.xml");
            BlankTexture = new Texture2D(GraphicsDevice, 1, 1);
            BlankTexture.SetData(new Color[1] { Color.White });
            Buffer = new RenderTarget2D(GraphicsDevice, Settings.Get<int>("Graphics.Virtual.Width"), Settings.Get<int>("Graphics.Virtual.Height"));
            Screens.LoadContent();
        }

        internal static void UnloadContent()
        {
            Screens.UnloadContent();
        }

        internal static void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            Inputs.Update();
            Screens.Update();
        }

        internal static void Draw(GameTime gameTime)
        {
            GameTime = gameTime;
            GraphicsDevice.SetRenderTarget(Buffer);
            GraphicsDevice.Clear(ClearColor);
            SpriteBatch.Begin();
            Screens.Draw();
            SpriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            SpriteBatch.Begin();
            SpriteBatch.Draw(Buffer, Bounds, Color.White);
            SpriteBatch.End();
        }
    }
}
