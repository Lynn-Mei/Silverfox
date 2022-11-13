using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox
{
    public class Executor
    {
        public Dictionary<string,Action> commands = new Dictionary<string,Action>();
        public Executor() 
        { 
            
        }

        public void registerAction(string name, Action action) 
        { 
            this.commands.Add(name, action);
        }

        public bool execute(string name) 
        {
            bool sucess = false;
            if (commands.ContainsKey(name))
            {
                commands[name].Invoke();
                sucess = true;
            }
            return sucess;
        }

    }
}
