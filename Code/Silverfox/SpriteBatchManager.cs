using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public sealed class SpriteBatchManager
    {
        private static SpriteBatchManager instance;
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch { get { return this.spriteBatch; } }
        public static SpriteBatchManager Instance 
        { 
            get 
            {
                if (instance == null) 
                { 
                    instance = new SpriteBatchManager();
                }
                return instance;
            }
        }
        private SpriteBatchManager() 
        {
            this.spriteBatch = new SpriteBatch(Game1Manager.Instance.Game.GraphicsDevice);
        }

    }
}
