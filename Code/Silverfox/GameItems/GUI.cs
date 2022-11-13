using Metier;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverfox.GameItems;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Silverfox
{
    public abstract class GUI : GameItem
    {
        private string focusedElement = null;
        private Texture2D background;

        public Dictionary<string,GUIElement> elements = new Dictionary<string, GUIElement>();
        public Executor executor = new Executor();

        public Executor Executor { get { return executor; } set { this.executor = value; } }
        protected GUI(Coordinates c, int height, int width) : base(c, height, width)
        {
            background = new Texture2D(Game1Manager.Instance.Game.GraphicsDevice, 1, 1);
            background.SetData(new[] { Color.White });
        }

        public override void Draw()
        {
            SpriteBatchManager.Instance.SpriteBatch.Draw(background, new Rectangle(this.Coordinates.X, this.Coordinates.Y, this.Surface.X, this.Surface.Y), Color.White);
            foreach (GUIElement element in elements.Values) 
            { 
                element.Draw();
            }
        }

        public override void Update()
        {
            if (Game1Manager.Instance.Game.IsActive) 
            {
                detectClick();
                detectKeyboardInput();
            }
            foreach (GUIElement element in elements.Values) 
            { 
                element.Update();
            }
        }

        public void addElement(GUIElement element)
        {
            this.elements.Add(element.Name, element);
        }

        public void detectClick() 
        {
            MouseState mouseState = InputManager.Instance.MouseState;
            if (mouseState != null) 
            {
                if (mouseState.LeftButton == ButtonState.Pressed) 
                {
                    foreach (GUIElement element in this.elements.Values) 
                    {
                        if (mouseState.X >= element.Coordinates.X && mouseState.Y >= element.Coordinates.Y)
                            if (mouseState.X <= element.Coordinates.X + element.Surface.X && mouseState.Y <= element.Coordinates.Y + element.Surface.Y) 
                            {
                                focusedElement = element.Name;
                                element.gotMouseClick(this.executor);
                            }
                    }
                }
            }
        }

        public void detectKeyboardInput() 
        {
            int nbKeypressed = InputManager.Instance.KeyboardState.GetPressedKeys().Length;
            if (nbKeypressed > 0 && focusedElement != null) 
            {
                getElementByName(focusedElement).gotKeyboardInput(executor);
            }
        }

        public Coordinates getRelativeCoordinates(int x, int y) 
        {
            Coordinates relativeCoordinates = new Coordinates(x, y);
            relativeCoordinates.X += this.Coordinates.X;
            relativeCoordinates.Y += this.Coordinates.Y;
            return relativeCoordinates;
        }

        public GUIElement getElementByName(string name) 
        { 
            GUIElement result = null;
            foreach (GUIElement element in this.elements.Values) 
            {
                if (element.Name == name)
                    result = element;
            }
            return result;
        }

        public void setBackgroundColor(Color c)
        {
            background.SetData(new[] { c });
        }

        public void setBackground(Texture2D background)
        {
            this.background = background;
        }
    }
}
