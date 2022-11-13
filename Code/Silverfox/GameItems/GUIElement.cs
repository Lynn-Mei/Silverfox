using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.GameItems
{
    public abstract class GUIElement : GameItem
    {
        private string name = "";
        public string Name { get { return this.name; } }
        public GUIElement(string name, Coordinates c, int height, int width) : base( c, height, width)
        {
            this.name = name;
        }
        public abstract void gotMouseClick(Executor exe);
        public abstract void gotKeyboardInput(Executor exe);

    }
}
