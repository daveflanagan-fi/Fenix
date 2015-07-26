using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.GameObjects.UIObjects
{
    public class ListView : Control
    {
        public int ItemHeight { get; set; }
        public int ScrollPosition { get { return ScrollBar.ScrollPosition; } }

        public ScrollBar ScrollBar { get; private set; }

        protected virtual void DrawItem()
        {

        }
    }
}
