using Silverfox.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.Viewmakers
{
    public class GameMaker : IViewMaker
    {
        public IView Create()
        {
            return new GameView();
        }
    }
}
