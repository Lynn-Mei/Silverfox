using Metier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Silverfox.GameItems.GUIElements
{
    public class Checkbox : GUIElement
    {
        private List<CheckboxElement> elements = new List<CheckboxElement>();
        private int boxSize = 50;
        private int margin = 5;
        private Texture2D checkedTexture;
        public override string Type { get { return "checkbox"; } }
        public Checkbox(string name, Coordinates c, int height, int width) : base(name, c, height, width)
        {
            this.checkedTexture = Game1Manager.Instance.Game.Content.Load<Texture2D>("checked");
        }
        public Checkbox(string name, Coordinates c, int height, int width, int boxSize, int margin) : base(name, c, height, width)
        {
            this.boxSize=boxSize;
            this.margin = margin;
            this.checkedTexture = Game1Manager.Instance.Game.Content.Load<Texture2D>("checked");
        }

        public override void Draw()
        {
            int i = 0;
            int nbBoxPerRow = this.Surface.X / (boxSize + margin);
            int yCoo = this.Coordinates.Y;
            int xCoo = this.Coordinates.X;
            foreach (CheckboxElement el in elements) 
            {
                if (i%nbBoxPerRow == 0 && i!=0) 
                {
                    yCoo += boxSize + margin;
                    xCoo = this.Coordinates.X;
                }
                Rectangle position = new Rectangle(xCoo, yCoo, boxSize, boxSize);
                SpriteBatchManager.Instance.SpriteBatch.Draw(el.Texture, position, Color.White);
                if(el.IsChecked)
                    SpriteBatchManager.Instance.SpriteBatch.Draw(checkedTexture, position, Color.White);
                xCoo += (margin + boxSize);
                i++;
            }
        }

        public override void gotKeyboardInput(Executor exe)
        {
            //no keyboard events
        }

        public override void gotMouseClick(Executor exe)
        {
            //exe.execute("toMain");
            int nbBoxPerRow = this.Surface.X / (boxSize + margin);

            int cposX = InputManager.Instance.MouseState.Position.X;
            int cposY = InputManager.Instance.MouseState.Position.Y;

            int relX = cposX-this.Coordinates.X;
            int relY = cposY - this.Coordinates.Y;

            int line = relY / (boxSize + margin);
            int column = relX / (boxSize + margin);

            int id = (line*nbBoxPerRow) + column;
            this.checkElement(id);
        }

        public override void Update()
        {
            //this.Draw();
        }

        public int getCheckedElementId() 
        {
            int id = -1;
            foreach (CheckboxElement el in elements) 
            { 
                if(el.IsChecked)
                    id=el.ID;
            }
            return id;
        }

        private void checkElement(int id) 
        {
            foreach (CheckboxElement el in elements) 
            {
                el.IsChecked = false;
            }
            elements[id].IsChecked = true;
        }

        public void addElement(Texture2D texture) 
        {
            this.elements.Add(new CheckboxElement(elements.Count, texture));
        }

        public override string ToString()
        {
            return getCheckedElementId().ToString();
        }
    }

}
