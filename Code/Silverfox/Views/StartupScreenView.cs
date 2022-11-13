using Microsoft.Xna.Framework;
using Silverfox.GameItems.GUIElements;
using Silverfox.GameItems.GUIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = Silverfox.GameItems.GUIElements.Button;

namespace Silverfox.Views
{
    public class StartupScreenView : IView
    {
        public StartupScreenView() 
        {
            int WinWidth = Game1Manager.Instance.Game.Window.ClientBounds.Width;
            int WinHeight = Game1Manager.Instance.Game.Window.ClientBounds.Height;
            this.addGameItem(new MainMenu("Main Menu",new Metier.Coordinates(0,0),WinHeight, WinWidth));
        }
    }
}
