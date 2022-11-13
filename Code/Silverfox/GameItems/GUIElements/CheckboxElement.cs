using Metier;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.GameItems.GUIElements
{
    public class CheckboxElement
    {
        private int id;
        private bool isChecked = false;
        private Texture2D texture;
        public int ID { get { return this.id; } }
        public bool IsChecked { get { return this.isChecked; } set { this.isChecked = value; } }
        public Texture2D Texture { get { return this.texture; } }
        
        public CheckboxElement(int id, Texture2D texture) 
        {
            this.id = id;
            if (id == 0) 
            {
                this.isChecked = true;
            }
            this.texture = texture;
        }
    }
}
