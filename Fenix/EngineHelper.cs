using Microsoft.Xna.Framework;

namespace Fenix
{
    internal class EngineHelper : DrawableGameComponent
    {
        public EngineHelper()
            : base(Engine.Game)
        { }

        public override void Initialize()
        {
            base.Initialize();
            Engine.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Engine.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            Engine.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Engine.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Engine.Draw(gameTime);
        }
    }
}
