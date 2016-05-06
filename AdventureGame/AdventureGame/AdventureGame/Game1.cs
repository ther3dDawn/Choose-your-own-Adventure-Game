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

namespace AdventureGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    enum Screen
    {
        Start, Game, Help, Gameover, Losing
    }
    
    //Possible way of handling story
    //Strings might also be useful to indicate decision forks.
    /*
    enum choicePath
    {
        
    }
    */
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screentype = Screen.Start;
        Screen oldscreentype;
        MouseState oldMouse = Mouse.GetState();
        Color[] color = new Color[5] { Color.Red, Color.White, Color.Black, Color.Green, Color.Purple };
        string[] endingCredits = new string[6] { "Congratulations you escaped!", "Created by:", "Dani Alvarez",
            "Duncan Hadley", "Nathan Johnson", "Ezinne Megwa" };

        SpriteFont EndingScreenFont;
        SpriteFont EndingScreenCredits;
        
        int screenWidth;
        int screenHeight;
        
        /*
        *These are the avatars
        */
        
        Rectangle boyBeforeRect;
        Texture2D BoyBeforeText;
        Rectangle boyAfterRect;
        Texture2D boyAfterText;

        Rectangle girlBeforeRect;
        Texture2D girlBeforeText;
        Rectangle girlAfterRect;
        Texture2D girlAfterText;
        
        Rectangle nurseGroupRect;
        Texture2D nurseGroupText;
        
        Rectangle nurseRect;
        Texture2D nurseText;
        
        Rectangle nurseMedWardRect;
        Texture2D nurseMedWardText;
        
        /*
        *These are the backgrounds
        */ 
        
        Rectangle hallwayBackgroundRect;
        Texture2D hallwayBackgroundText;
        
        Rectangle medicalWardBackgroundRect;
        Texture2D medicalWardBackgroundText;
        
        Rectangle roomBackgroundRect;
        Texture2D roomBackgroundText;
        
        Rectangle adminOfficeBackgroundRect;
        Texture2D adminOfficeBackgroundText;
        
        Rectangle boyWinGameoverBackgroundRect;
        Texture2D boyWinGameoverBackgroundText;
        
        Rectangle girlWinGameoverBackgroundRect;
        Texture2D girlWinGameoverBackgroundText;

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
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            girlWinGameoverBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            boyWinGameoverBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
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
            EndingScreenCredits = Content.Load<SpriteFont>("SpriteFont2");
            
            /*
            *These are the textures for the avatars
            */
            
            BoyBeforeText = Content.Load<Texture2D>("BoyPatient");
            boyAfterText = Content.Load<Texture2D>("BoyAfterPatient");
            girlBeforeText = Content.Load<Texture2D>("GirlPatient");
            girlAfterText = Content.Load<Texture2D>("GirlAfterPatient");
            nurseGroupText = Content.Load<Texture2D>("group of nurses");
            nurseText = Content.Load<Texture2D>("nurse1");
            
            /*
            *These are the textures for the backgrounds
            */
            
            girlWinGameoverBackgroundText = Content.Load<Texture2D>("MHGirlWin");
            boyWinGameoverBackgroundText = Content.Load<Texture2D>("MHGuyWin");

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
            
               /*
             * Be Sure to add comments to your code so we know what is going on. 
             * It is much faster and easier to read the comments you write explaining the code than
             * trying to decipher your code
             * So for this update that changes the colors, I am confused on when each colors changes to another and what buttons control what. 
             * Something that can be done to prevent this is to write an explaination:
             * 
             * 'H' button = Help Screen
             * 'B' button= Game Screen
             * ....and so on.
             * 
             */

            if (mouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton == ButtonState.Released
                && screentype == Screen.Start)
            {
                screentype = Screen.Game;
            }

            if (Key.IsKeyDown(Keys.H) && screentype == Screen.Game)
            {
                oldscreentype = Screen.Game;
                screentype = Screen.Help;
            }
            else if (Key.IsKeyDown(Keys.B) && screentype == Screen.Help && oldscreentype == Screen.Game)
            {
                screentype = Screen.Game;
            }

            if (Key.IsKeyDown(Keys.H) && screentype == Screen.Start)
            {
                screentype = Screen.Help;
            }
            else if (Key.IsKeyDown(Keys.B) && screentype == Screen.Help)
            {
                screentype = Screen.Start;
            }

            if (Key.IsKeyDown(Keys.G) && screentype == Screen.Game)
            {
                screentype = Screen.Gameover;
            }

            if (Key.IsKeyDown(Keys.S) && screentype == Screen.Gameover)
            {
                screentype = Screen.Start;
            }
            
            if (Key.IsKeyDown(Keys.L) && screentype == Screen.Game)
            {
                screentype = Screen.Losing;
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
                spriteBatch.Draw(girlWinGameoverBackgroundText, girlWinGameoverBackgroundRect, Color.White);
                spriteBatch.DrawString(EndingScreenFont, endingCredits[0], new Vector2(125, 100), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[1], new Vector2(350, 220), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[2], new Vector2(335, 240), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[3], new Vector2(330, 260), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[4], new Vector2(327, 280), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[5], new Vector2(340, 300), Color.Red);
            }
            else if (screentype == Screen.Game)
            {
                GraphicsDevice.Clear(color[3]);
            }
            else if (screentype == Screen.Losing)
            {
                GraphicsDevice.Clear(color[4]);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
