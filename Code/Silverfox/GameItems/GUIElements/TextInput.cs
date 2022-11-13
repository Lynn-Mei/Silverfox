using Metier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Silverfox.GameItems.GUIElements
{
    public class TextInput : GUIElement
    {
        private string content="";
        private int maxLenght=45;
        private int minLenght=0;
        private Texture2D background;
        private SpriteFont font;
        public override string Type { get { return "textinput"; } }
        public TextInput(string name, Coordinates c, int height, int width) : base(name, c, height, width)
        {
            font = Game1Manager.Instance.Game.Content.Load<SpriteFont>("defaultFont");
            background = new Texture2D(Game1Manager.Instance.Game.GraphicsDevice, 1, 1);
            background.SetData(new[] { Color.DeepSkyBlue });
        }
        public override void Draw()
        {
            SpriteBatchManager.Instance.SpriteBatch.Draw(background, new Rectangle(this.Coordinates.X, this.Coordinates.Y, this.Surface.X, this.Surface.Y), Color.White);
            SpriteBatchManager.Instance.SpriteBatch.DrawString(font, getDrawnText(), new Vector2(Coordinates.X, Coordinates.Y), Color.Black);
        }

        public override void gotMouseClick(Executor exe)
        {
            //
        }
        public override void gotKeyboardInput(Executor exe) 
        {
            KeyboardState keyboardState = InputManager.Instance.KeyboardState;
            int p = keyboardState.GetPressedKeyCount();
            Keys[] keys = keyboardState.GetPressedKeys();
            foreach (Keys k in keys) 
            {
                if(this.content.Length<this.maxLenght)
                    updateText(k);
            }

        }
        private void updateText(Keys key)
        {
            if (!InputManager.Instance.KeysBool[(int)key])
            {
                if (key == Keys.Back)
                {
                    string s = this.content;
                    s = s.Remove(s.Length - 1);
                    this.content = s;
                }
                else if ((int)key >= 65 && (int)key <= 90)
                {
                    this.content += key.ToString();
                }
                else if (key == Keys.Space)
                {
                    this.content += ' ';
                }
                else
                {

                }
            }
        }
        private string getDrawnText()
        {
            string formatedText = "";
            //nb char max =  
            int pos = 0;
            if (this.content.Length > 15 * (this.Surface.Y / 20))
            {
                pos += this.content.Length - (15 * (this.Surface.Y / 20));
            }
            for (int j = 0; j < (this.Surface.Y / 20); j++)
            {
                for (int i = 0; i < 15; i++)
                {
                    if ((15 * j) + i < this.content.Length)
                        formatedText += this.content[pos + (15 * j) + i];
                }
                formatedText += '\n';
            }
            return formatedText;
        }
        public override void Update()
        {
            //
        }

        //Background related stuff
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
