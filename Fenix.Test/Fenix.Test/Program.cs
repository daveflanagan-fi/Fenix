namespace Fenix.Test
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            Engine.Run();
        }
    }
#endif
}

