using Silverfox.GameItems.GUIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.Views
{
    public class CharacterCreationView : IView
    {
        public CharacterCreationView()
        {
            int WinWidth = Game1Manager.Instance.Game.Window.ClientBounds.Width;
            int WinHeight = Game1Manager.Instance.Game.Window.ClientBounds.Height;
            int formWidth = Convert.ToInt32(WinWidth * 0.58);
            int formHeight = Convert.ToInt32(WinHeight * 0.90);
            int formX = Convert.ToInt32((WinWidth -formWidth)/2);
            int formY = Convert.ToInt32((WinHeight - formHeight) / 2);
            this.addGameItem(new CharacterCreationForm("Character Creation", new Metier.Coordinates(formX, formY), formHeight, formWidth));
        }
    }
}
