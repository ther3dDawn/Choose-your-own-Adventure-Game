using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Adventure_Project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    enum Screen
    {
        Start, Game, Help, Gameover
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screentype = Screen.Start;
        MouseState oldMouse = Mouse.GetState();
        Color[] color = new Color[4] { Color.Red, Color.White, Color.Black, Color.Green};

        SpriteFont EndingScreenFont;

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
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            EndingScreenFont = Content.Load<SpriteFont>("SpriteFont1");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            MouseState mouse = Mouse.GetState();
            KeyboardState Key = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            if (mouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton == ButtonState.Released
                && screentype == Screen.Start)
            {
                screentype = Screen.Gameover;
            }

            if (Key.IsKeyDown(Keys.H) && screentype == Screen.Game)
            {
                screentype = Screen.Help;
            }

            if (Key.IsKeyDown(Keys.T) || Key.IsKeyDown(Keys.T) && screentype == Screen.Help)
            {
                screentype = Screen.Game;
            }

            if (Key.IsKeyDown(Keys.G) && screentype == Screen.Game)
            {
                screentype = Screen.Gameover;
            }

            if (Key.IsKeyDown(Keys.S) && screentype == Screen.Gameover)
            {
                screentype = Screen.Start;
            }

            oldMouse = mouse;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (screentype == Screen.Start)
            {
                GraphicsDevice.Clear(color[1]);
            }
            else if (screentype == Screen.Help)
            {
                GraphicsDevice.Clear(color[2]);
            }
            else if (screentype == Screen.Gameover)
            {
                GraphicsDevice.Clear(color[0]);
                spriteBatch.DrawString(EndingScreenFont, "Congratulations you escaped!", new Vector2(250, 200), Color.White);
                spriteBatch.DrawString(EndingScreenFont, "Created by:", new Vector2(350, 220), Color.White);
                spriteBatch.DrawString(EndingScreenFont, "Dani Alvarez", new Vector2(335, 240), Color.White);
                spriteBatch.DrawString(EndingScreenFont, "Duncan Hadley", new Vector2(330, 260), Color.White);
                spriteBatch.DrawString(EndingScreenFont, "Nathan Johnson", new Vector2(327, 280), Color.White);
                spriteBatch.DrawString(EndingScreenFont, "Ezinne Megwa", new Vector2(340, 300), Color.White);
            }
            else if (screentype == Screen.Game)
            {
                GraphicsDevice.Clear(color[3]);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
