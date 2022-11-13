using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public abstract class IView
    {
        public List<GameItem> gameItems = new List<GameItem>();
        public void Draw() 
        {
            foreach (GameItem item in gameItems) 
            {
                item.Draw();
            }
        }
        public void Update()
        {
            foreach (GameItem item in this.gameItems)
            {
                item.Update();
            }
        }

        public void addGameItem(GameItem item) 
        {
            this.gameItems.Add(item);
        }
    }
}
