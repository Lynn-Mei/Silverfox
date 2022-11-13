using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Silverfox.Views;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace Silverfox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IView view;

        public IView View { get { return this.view; } set { this.view = value; } }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Game1Manager.Instance.Game = this;
            this.Window.Title = "Silverfox";
            view = ViewManager.Instance.getView("Startup Screen");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Content.Load<SpriteFont>("defaultFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            InputManager.Instance.OldMouseState = InputManager.Instance.MouseState;
            InputManager.Instance.MouseState = Mouse.GetState();
            InputManager.Instance.KeyboardState = Keyboard.GetState();
            

            this.view.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            SpriteBatchManager.Instance.SpriteBatch.Begin();
            // TODO: Add your drawing code here
            view.Draw();
            SpriteBatchManager.Instance.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}