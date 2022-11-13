using Metier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.GameItems.GUIElements
{
    public class Text : GUIElement
    {
        private string text;
        private SpriteFont font;
        private Texture2D background;
        private Color textColor;
        public override string Type { get { return "text"; } }
        public Text(string name, Coordinates c, string text, int height, int width) : base(name, c, height, width)
        {
            this.text = text;
            //set to default font
            font = Game1Manager.Instance.Game.Content.Load<SpriteFont>("defaultFont");
            //set to default background
            background = new Texture2D(Game1Manager.Instance.Game.GraphicsDevice, 1, 1);
            textColor = Color.Black;
        }

        public override void Draw()
        {
            //SpriteBatchManager.Instance.SpriteBatch.Draw(background, new Rectangle(this.Coordinates.X, this.Coordinates.Y, width, height), Color.White);
            SpriteBatchManager.Instance.SpriteBatch.DrawString(font, text, new Vector2(Coordinates.X, Coordinates.Y), textColor);
        }

        public override void Update()
        {
            //no update code
        }
        public void setFont(string font)
        {
            this.font = Game1Manager.Instance.Game.Content.Load<SpriteFont>(font);
        }
        public void setBackground(Texture2D background)
        {
            this.background = background;
        }

        public override void gotMouseClick(Executor exe)
        {
            //
        }

        public override void gotKeyboardInput(Executor exe)
        {
            //
        }
    }
}
