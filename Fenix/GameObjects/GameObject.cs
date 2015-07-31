using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fenix.GameObjects
{
    public abstract class GameObject
    {
        private static Dictionary<Type, int> _typeCounts = new Dictionary<Type, int>();

        protected Vector2 _position;

        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public float Depth { get; set; }
        public bool Independent { get; set; }

        public Vector2 Position
        {
            get { return Parent != null && !Independent ? Parent.Position + _position : _position; }
            set { _position = Parent != null && !Independent ? Parent.Position - value : value; }
        }

        public List<GameObject> Children { get; private set; }
        public GameObject Parent { get; set; }

        public GameObject()
        {
            Type t = this.GetType();
            if (!_typeCounts.ContainsKey(t))
                _typeCounts.Add(t, 0);
            _typeCounts[t]++;

            this.Independent = false;
            this.Name = string.Format("{0}{1}", t.Name, _typeCounts[t]);
            this.Enabled = true;
            this.Visible = true;
            this.Children = new List<GameObject>();
            this._position = Vector2.Zero;
        }

        public virtual void AddChild(GameObject child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public virtual void RemoveChild(GameObject child)
        {
            Children.Remove(child);
            child.Parent = null;
        }

        public void DoUpdate()
        {
            if (Enabled)
                Update();
        }

        public void DoInput()
        {
            if (Enabled)
                HandleInput();
        }

        public void DoPreDraw()
        {
            if (Visible)
                PreDraw();
        }

        public void DoDraw()
        {
            if (Visible)
                Draw();
        }

        protected virtual void Update() { }
        protected virtual void HandleInput() { }
        protected virtual void PreDraw() { }
        protected virtual void Draw() { }
    }
}
