using Metier;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Silverfox.GameItems.GUIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Silverfox.GameItems.GUIs
{
    public class CharacterCreationForm : GUI
    {
        public override string Type { get { return "CharacterCreationForm"; } }
        public CharacterCreationForm(string name, Coordinates c, int height, int width) : base(c, height, width)
        {
            Coordinates coo = getRelativeCoordinates(0, 0);
            //this.addElement(new TextInput("name", getRelativeCoordinates(0, 0), 100, 100));

            //Arcane Clan
            coo = getRelativeCoordinates(10, Convert.ToInt32(this.Surface.Y / 2) - 130);
            Text text = new Text("Arcane Clan Title", coo, "Arcane Clan", 100, 50);
            this.addElement(text);

            coo = getRelativeCoordinates(10, Convert.ToInt32(this.Surface.Y / 2)-80);
            Checkbox arcaneBox = new Checkbox("Arcane Clan", coo, 55, 495);
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            //
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            //
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            arcaneBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            this.addElement(arcaneBox);



            //Combat Specialization
            coo = getRelativeCoordinates(Convert.ToInt32((this.Surface.X / 4)*2.35), Convert.ToInt32(this.Surface.Y / 3) * 2-50);
            text = new Text("Combat Spe. Title" , coo, "Combat Specialization",100,50);
            this.addElement(text);

            coo = getRelativeCoordinates(Convert.ToInt32(this.Surface.X / 4)*2, Convert.ToInt32(this.Surface.Y / 3)*2);
            Checkbox combatSpeBox = new Checkbox("Combat Specialization",coo,146,292,65,8);

            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            //second row
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            combatSpeBox.addElement(Game1Manager.Instance.Game.Content.Load<Texture2D>("circle"));
            this.addElement(combatSpeBox);

            this.setBackgroundColor(Color.WhiteSmoke);

            //btn
            Button buttonQuit = new Button("Validate", getRelativeCoordinates(0, 0), 50, 100, "Validate");
            buttonQuit.setBackgroundColor(Color.Gold);
            buttonQuit.Text = new Text("btnContent", buttonQuit.Coordinates, "Validate", 100, 100);
            this.addElement(buttonQuit);


            //setting executor
            this.Executor.registerAction("toMain", toMain);
            this.Executor.registerAction("Validate", Validate);
        }

        public void toMain() 
        {
            Game1Manager.Instance.Game.View = ViewManager.Instance.getView("Startup Screen");
        }

        public void Validate() 
        {
            if(this.elements["Combat Specialization"].ToString() == "2")
                Game1Manager.Instance.Game.View = ViewManager.Instance.getView("Startup Screen");
        }

    }
}
