using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.Views
{
    public class GameView : IView
    {
        public GameView()
        {
            int WinWidth = Game1Manager.Instance.Game.Window.ClientBounds.Width;
            int WinHeight = Game1Manager.Instance.Game.Window.ClientBounds.Height;
            //this.addGameItem(new Background("Background", new Metier.Coordinates(0, 0), WinHeight, WinWidth));
        }
    }
}
