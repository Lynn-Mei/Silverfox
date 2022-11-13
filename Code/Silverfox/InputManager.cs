using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Silverfox
{
    public sealed class InputManager
    {
        private static InputManager instance;
        private MouseState oldMouseState =  Mouse.GetState();
        private MouseState mouseState = Mouse.GetState();
        private KeyboardState keyboardState = Keyboard.GetState();
        private Dictionary<int, bool> keys = new Dictionary<int, bool>();

        public MouseState OldMouseState { get { return this.oldMouseState; } set { this.oldMouseState = value; } }
        public MouseState MouseState { get { return this.mouseState; } set { this.mouseState = value; } }
        public KeyboardState KeyboardState { get { return this.keyboardState; } 
            set 
            {
                InputManager.Instance.Update(this.keyboardState.GetPressedKeys());
                this.keyboardState = value; 
            } 
        }
        public Dictionary<int,bool> KeysBool { get { return keys; } set { this.keys = value; } }
        private InputManager() 
        {
            foreach (int k in Enum.GetValues(typeof(Keys))) 
            { 
                this.keys[k] = false;
            }
        }

        public static InputManager Instance
        {
            get 
            {
                if (instance == null) 
                { 
                    instance = new InputManager();
                }
                return instance;
            }
        }

        public void Update(Keys[] pressedKeys)
        {
            foreach (int i in Enum.GetValues(typeof(Keys)))
            {
                if (pressedKeys.Contains((Keys)i))
                {
                    InputManager.Instance.KeysBool[i] = true;
                }
                else { InputManager.Instance.KeysBool[i] = false; }
            }
        }

    }
}
