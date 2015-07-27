using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fenix.Managers
{
    public class ContentManager : Microsoft.Xna.Framework.Content.ContentManager
    {
        public ContentManager()
            : base(Engine.Services)
        { }
    }
}
