using Silverfox.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.Viewmakers
{
    public class SaveSelectionMaker : IViewMaker
    {
        public IView Create()
        {
            return new SaveSelectionView();
        }
    }
}
