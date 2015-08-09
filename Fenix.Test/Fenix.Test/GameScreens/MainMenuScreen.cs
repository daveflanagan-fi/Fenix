using Fenix.GameScreens;
using Fenix.Test.GameScreens.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.Test.GameScreens
{
    public class MainMenuScreen : GameScreen
    {
        public Header Header { get; set; }

        public MainMenuScreen()
        {
            Header = new Header();
            Header.Height = 100;
            Header.Text = "Test";
        }

        public override void Draw()
        {
            Header.Draw();
        }
    }
}
