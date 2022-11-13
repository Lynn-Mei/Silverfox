using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silverfox
{
    public abstract class GameItem
    {
        private Coordinates coordinates;
        private Coordinates surface;
        public abstract string Type { get; }
        public Coordinates Coordinates { get { return this.coordinates; } }
        public Coordinates Surface { get { return this.surface; } }
        protected GameItem(Coordinates c, int height, int width) 
        {
            this.coordinates = c;
            this.surface = new Coordinates(width, height);
        }

        public abstract void Draw();
        public abstract void Update();

    }
}
