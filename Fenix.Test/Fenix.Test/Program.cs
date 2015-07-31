using Fenix.Test.GameScreens;

namespace Fenix.Test
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            Engine.Run(new BackgroundScreen(), new MainMenuScreen());
        }
    }
#endif
}

