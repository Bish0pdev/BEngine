using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using BCore;
using System;
using System.Linq;
namespace BEngine
{
    public class YourGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Camera mainCam;
        private List<Entity> activeEntitys = new List<Entity>();
        TextRenderer FPSCounter;
        public YourGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mainCam = new Camera(new Vector2(-Window.ClientBounds.Width / 2, -Window.ClientBounds.Height / 2));
            Texture2D square = SimpleTextures.CreateWireframeSquareTexture(GraphicsDevice, 100, Color.AntiqueWhite,5);
            Entity circle = new Entity();
            SpriteRenderer circlesprite = new SpriteRenderer(SimpleTextures.CreateWireframeCircleTexture(100, Color.White, 2, GraphicsDevice));
            circle.AddComponent(circlesprite);
            activeEntitys.Add(circle);

            Entity Floor = new Entity();
            Floor.AddComponent(new SpriteRenderer(square));
            Floor.MoveTo(new Vector2(0, 200));
            Floor.SetScale(new Vector2(Window.ClientBounds.X, 10f));
            activeEntitys.Add(Floor);
            FPSCounter = new TextRenderer(Content.Load<SpriteFont>("DefaultFont"));
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Move the camera based on keyboard input
            KeyboardState keyboardState = Keyboard.GetState();

            float cameraSpeed; // Adjust the speed as needed
            Vector2 cameraMovement = Vector2.Zero;
            if(keyboardState.IsKeyDown(Keys.LeftShift))
            {
                cameraSpeed = 5f;
            } else
            {
                cameraSpeed = 3f;
            }
            if (keyboardState.IsKeyDown(Keys.W))
                cameraMovement.Y -= cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.A))
                cameraMovement.X -= cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.S))
                cameraMovement.Y += cameraSpeed;
            if (keyboardState.IsKeyDown(Keys.D))
                cameraMovement.X += cameraSpeed;

            activeEntitys[0].Position += cameraMovement;

            for (int i = 0; i < activeEntitys.Count; i++)
            {
                activeEntitys[i].Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: mainCam.TransformMatrix);

            for (int i = 0; i < activeEntitys.Count; i++)
            {
                activeEntitys[i].Draw(_spriteBatch);
            }

            _spriteBatch.End();
            _spriteBatch.Begin();
            FPSCounter.SetText(string.Format("FPS: {0}", Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds)));
            FPSCounter.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}