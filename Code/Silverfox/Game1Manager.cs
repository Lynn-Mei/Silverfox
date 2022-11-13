using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public sealed class Game1Manager
    {
        private static Game1Manager instance = null;
        private Game1 game;
        public Game1 Game { get{ return this.game; } set { this.game = value; } }
        private Game1Manager() { }
        public static Game1Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game1Manager();
                }
                return instance;
            }
        }

    }
}
