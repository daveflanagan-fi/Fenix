using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.GameObjects
{
    public abstract class GameObject
    {
        private static Dictionary<Type, int> _typeCounts = new Dictionary<Type, int>();

        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public Vector2 Position { get; set; }

        public GameObject()
        {
            Type t = this.GetType();
            if (!_typeCounts.ContainsKey(t))
                _typeCounts.Add(t, 0);
            _typeCounts[t]++;

            this.Name = string.Format("{0}{1}", t.Name, _typeCounts[t]);
            this.Enabled = true;
            this.Visible = true;
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
