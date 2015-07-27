using Fenix.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fenix.GameScreens
{
    public enum ScreenState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }

    public abstract class GameScreen
    {
        bool otherScreenHasFocus;
        private List<GameObject> objectsToUpdate = new List<GameObject>();

        public bool IsPopup { get; set; }
        public TimeSpan TransitionOnTime { get; protected set; }
        public TimeSpan TransitionOffTime { get; protected set; }
        public float TransitionPosition { get; protected set; }
        public ScreenState ScreenState { get; protected set; }
        public bool IsExiting { get; internal set; }
        public PlayerIndex? ControllingPlayer { get; internal set; }
        public List<GameObject> Objects { get; private set; }

        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }
        public bool IsActive
        {
            get { return !otherScreenHasFocus && (ScreenState == ScreenState.TransitionOn || ScreenState == ScreenState.Active); }
        }

        public GameScreen()
        {
            TransitionPosition = 1;
            Objects = new List<GameObject>();
        }
        
        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        
        public virtual void Update(bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            this.otherScreenHasFocus = otherScreenHasFocus;

            if (IsExiting)
            {
                ScreenState = ScreenState.TransitionOff;
                if (!UpdateTransition(TransitionOffTime, 1))
                    Engine.Screens.Remove(this);
            }
            else if (coveredByOtherScreen)
            {
                if (UpdateTransition(TransitionOffTime, 1))
                    ScreenState = ScreenState.TransitionOff;
                else
                    ScreenState = ScreenState.Hidden;
            }
            else
            {
                if (UpdateTransition(TransitionOnTime, -1))
                    ScreenState = ScreenState.TransitionOn;
                else
                    ScreenState = ScreenState.Active;
            }

            objectsToUpdate.Clear();
            foreach (GameObject obj in Objects)
                objectsToUpdate.Add(obj);
            
            while (objectsToUpdate.Count > 0)
            {
                GameObject obj = objectsToUpdate[objectsToUpdate.Count - 1];
                objectsToUpdate.RemoveAt(objectsToUpdate.Count - 1);
                obj.DoUpdate();
            }
        }
        
        bool UpdateTransition(TimeSpan time, int direction)
        {
            float transitionDelta;

            if (time == TimeSpan.Zero)
                transitionDelta = 1;
            else
                transitionDelta = (float)(Engine.GameTime.ElapsedGameTime.TotalMilliseconds / time.TotalMilliseconds);
            
            TransitionPosition += transitionDelta * direction;

            if ((direction < 0 && TransitionPosition <= 0) || (direction > 0 && TransitionPosition >= 1))
            {
                TransitionPosition = MathHelper.Clamp(TransitionPosition, 0, 1);
                return false;
            }
            
            return true;
        }
        
        public virtual void HandleInput() { }
        public virtual void Draw()
        {
            foreach (GameObject obj in Objects)
                obj.DoDraw();
        }
        
        public void ExitScreen()
        {
            if (TransitionOffTime == TimeSpan.Zero)
                Engine.Screens.Remove(this);
            else
                IsExiting = true;
        }

        public void Add(GameObject obj)
        {
            Objects.Add(obj);
        }

        public void Remove(GameObject obj)
        {
            Objects.Remove(obj);
            objectsToUpdate.Remove(obj);
        }
    }
}
