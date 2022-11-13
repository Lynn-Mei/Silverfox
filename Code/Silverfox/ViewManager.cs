using Silverfox.Viewmakers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public sealed class ViewManager
    {
        private static ViewManager instance;
        private Dictionary<string,IViewMaker> views = new Dictionary<string,IViewMaker>();
        private ViewManager() 
        {
            registerView("Startup Screen", new StartupScreenMaker());
            registerView("Save Creation", new CharacterCreationMaker());
            registerView("Save Selection", new SaveSelectionMaker());
            //registerView("Options", new OptionsMaker());
            registerView("Game", new GameMaker());
        }
        public static ViewManager Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new ViewManager();
                }
                return instance; 
            }
        }

        public void registerView(string view, IViewMaker viewMaker) 
        { 
            this.views.Add(view, viewMaker);
        }

        public IView getView(string name) 
        {
            return views[name].Create();
        }

    }
}
