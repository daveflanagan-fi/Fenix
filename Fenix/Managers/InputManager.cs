using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fenix.Managers
{
    public class InputManager
    {
        public KeyboardState CurrentKeyboard { get; private set; }
        public KeyboardState LastKeyboard { get; private set; }
        public MouseState CurrentMouse { get; private set; }
        public MouseState LastMouse { get; private set; }

        public Point CurrentMousePosition { get { return new Point(CurrentMouse.X, CurrentMouse.Y); } }
        public Point LastMousePosition { get { return new Point(LastMouse.X, LastMouse.Y); } }
        public Point MouseDelta { get { return new Point(LastMouse.X - CurrentMouse.X, LastMouse.Y - CurrentMouse.Y); } }

        internal void Update()
        {
            LastKeyboard = CurrentKeyboard;
            CurrentKeyboard = Keyboard.GetState();

            LastMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();
        }

        public bool IsLeftPress()
        {
            return CurrentMouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftClick()
        {
            return CurrentMouse.LeftButton == ButtonState.Released && LastMouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsRightPress()
        {
            return CurrentMouse.RightButton == ButtonState.Pressed;
        }

        public bool IsRightClick()
        {
            return CurrentMouse.RightButton == ButtonState.Released && LastMouse.RightButton == ButtonState.Pressed;
        }

        public bool IsKeyPress(Keys key)
        {
            return CurrentKeyboard.IsKeyDown(key);
        }

        public bool IsNewKeyPress(Keys key)
        {
            return CurrentKeyboard.IsKeyDown(key) && LastKeyboard.IsKeyUp(key);
        }

        public bool IsMenuSelect()
        {
            return IsNewKeyPress(Keys.Space) || IsNewKeyPress(Keys.Enter);
        }
        
        public bool IsMenuCancel()
        {
            return IsNewKeyPress(Keys.Escape);
        }
        
        public bool IsMenuUp()
        {
            return IsNewKeyPress(Keys.Up);
        }
        
        public bool IsMenuDown()
        {
            return IsNewKeyPress(Keys.Down);
        }
        
        public bool IsPauseGame()
        {
            return IsNewKeyPress(Keys.Escape);
        }
    }
}
