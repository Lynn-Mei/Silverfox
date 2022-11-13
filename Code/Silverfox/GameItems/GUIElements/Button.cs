using Metier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.GameItems.GUIElements
{
    public class Button:GUIElement
    {
        private Text text = null;
        private string command = "";
        private Texture2D background;
        public override string Type { get { return "button"; } }
        public Text Text { get { return this.text; } set { this.text = value; } }
        public Button(string name, Coordinates c, int height, int width, string command) : base(name, c, height, width)
        {
            background = new Texture2D(Game1Manager.Instance.Game.GraphicsDevice, 1, 1);
            background.SetData(new[] { Color.DeepSkyBlue });
            this.command = command;
        }

        public override void Draw()
        {
            SpriteBatchManager.Instance.SpriteBatch.Draw(background, new Rectangle(this.Coordinates.X, this.Coordinates.Y, this.Surface.X, this.Surface.Y), Color.White);
            if (this.text != null) 
            {
                this.text.Draw();
            }
        }

        public override void Update()
        {
            //
        }

        public void setBackgroundColor(Color c) 
        {
            background.SetData(new[] { c });
        }

        public void setBackground(Texture2D background) 
        {
            this.background = background;
        }

        public override void gotMouseClick(Executor exe)
        {
            exe.execute(this.command);
        }

        public override void gotKeyboardInput(Executor exe)
        {
            //
        }
    }
}
