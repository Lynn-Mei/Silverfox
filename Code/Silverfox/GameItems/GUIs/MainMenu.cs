using Metier;
using Microsoft.Xna.Framework;
using Silverfox.GameItems.GUIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverfox.GameItems.GUIs
{
    public class MainMenu : GUI
    {
        public override string Type { get { return "mainmenu"; } }
        public MainMenu(string name, Coordinates c, int height, int width) : base(c, height, width)
        {
            //int WinWidth = Game1Manager.Instance.Game.Window.ClientBounds.Width;
            //int WinHeight = Game1Manager.Instance.Game.Window.ClientBounds.Height;

            //setting the title
            Text title = new Text("Title", getRelativeCoordinates((width / 2 - 80), 0), "Silverfox", 100, 100);
            title.setFont("TitleFont");
            this.addElement(title);

            //adding the buttons
            //new btn
            Button buttonNew = new Button("New", getRelativeCoordinates(100, (height / 2)), 50, 100, "toSaveCreation");
            buttonNew.setBackgroundColor(Color.Gold);
            buttonNew.Text = new Text("btnContent", buttonNew.Coordinates, "New", 100, 100);
            this.addElement(buttonNew);

            //load btn
            Button buttonLoad = new Button("Load", getRelativeCoordinates(300, (height / 2)), 50, 100, "toSaveSelection");
            buttonLoad.setBackgroundColor(Color.Gold);
            buttonLoad.Text = new Text("btnContent", buttonLoad.Coordinates, "Load", 100, 100);
            this.addElement(buttonLoad);

            //options btn
            Button buttonOptions = new Button("Options", getRelativeCoordinates(500, (height / 2)), 50, 100, "toOptions");
            buttonOptions.setBackgroundColor(Color.Gold);
            buttonOptions.Text = new Text("btnContent", buttonOptions.Coordinates, "Options", 100, 100);
            this.addElement(buttonOptions);

            //quit btn
            Button buttonQuit = new Button("Quit", getRelativeCoordinates(700, (height / 2)), 50, 100, "toQuit");
            buttonQuit.setBackgroundColor(Color.Gold);
            buttonQuit.Text = new Text("btnContent", buttonQuit.Coordinates, "Quit", 100, 100);
            this.addElement(buttonQuit);

            //setting executor
            this.Executor.registerAction("toSaveCreation", toSaveCreation);
            this.Executor.registerAction("toSaveSelection", toSaveSelection);
            this.Executor.registerAction("toOptions", toOptions);
            this.Executor.registerAction("toQuit", toQuit);
        }

        public void toSaveCreation() 
        {
            Game1Manager.Instance.Game.View = ViewManager.Instance.getView("Save Creation");
        }

        public void toSaveSelection() 
        {
            Game1Manager.Instance.Game.View = ViewManager.Instance.getView("SaveSelection");
        }
        public void toOptions()
        {
            //Game1Manager.Instance.Game.View = ViewManager.Instance.getView("Options");
        }
        public void toQuit()
        {
            Game1Manager.Instance.Game.Exit();
        }


    }
}
