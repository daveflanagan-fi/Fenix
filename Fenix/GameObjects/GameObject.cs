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

        public Vector2 Position
        {
            get { return Parent != null ? Parent.Position + _position : _position; }
            set { _position = Parent != null ? Parent.Position - value : value; }
        }

        public List<GameObject> Children { get; private set; }
        public GameObject Parent { get; set; }

        public GameObject()
        {
            Type t = this.GetType();
            if (!_typeCounts.ContainsKey(t))
                _typeCounts.Add(t, 0);
            _typeCounts[t]++;

            this.Name = string.Format("{0}{1}", t.Name, _typeCounts[t]);
            this.Enabled = true;
            this.Visible = true;
            this.Children = new List<GameObject>();
            this._position = Vector2.Zero;
        }

        public void DoUpdate()
        {
            if (Enabled)
                Update();
        }

        public void DoDraw()
        {
            if (Visible)
                Draw();
        }

        protected virtual void Update() { }
        protected virtual void Draw() { }
    }
}
