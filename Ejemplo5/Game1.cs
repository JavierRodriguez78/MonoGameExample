using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ejemplo5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D nave;
        Texture2D fondo;
        Texture2D laser;
        Vector2 posicion;
        Vector2 posicionlaser;
        Boolean laseractivo;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            posicion.X = 420;
            posicion.Y = 390;
            posicionlaser.X = posicion.X + 150;
            posicionlaser.Y = posicion.Y;
            laseractivo = false;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            nave = Content.Load<Texture2D>("sprite1");
            fondo = Content.Load<Texture2D>("espacio");
            laser = Content.Load<Texture2D>("laser");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (posicion.X < (graphics.GraphicsDevice.Viewport.Width - nave.Width))
                {
                    Console.WriteLine(posicion.X + " ->" + graphics.GraphicsDevice.Viewport.Width);
                    Console.WriteLine("Tamaño de la nave ->" + nave.Width);
                    posicion.X++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (posicion.X > 0)
                {
                    posicion.X--;
                }
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                laseractivo = true;
            }

            if (laseractivo== true)
            {
                posicionlaser.Y--;
                if (posicionlaser.Y == 0)
                {
                    laseractivo = false;
                }

            }
            else
            {
                posicionlaser.Y = posicion.Y;
                posicionlaser.X = posicion.X + (nave.Width/2)-28;

            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(fondo, new Rectangle(0, 0, graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height), Color.LightCyan);
            spriteBatch.Draw(nave, posicion);
            if (laseractivo == true)
            {
                spriteBatch.Draw(laser, posicionlaser);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
