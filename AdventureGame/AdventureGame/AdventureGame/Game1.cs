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
        Start, Describe, AvatarSelect, Game, Help, Gameover, Losing
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
        Color[] color = new Color[3] { Color.Black, Color.Green, Color.Purple };
        string[] endingCredits = new string[6] { "Congratulations you escaped!", "Created by:", "Dani Alvarez",
            "Duncan Hadley", "Nathan Johnson", "Ezinne Megwa" };

        SpriteFont EndingScreenFont;
        SpriteFont EndingScreenCredits;
        SpriteFont avatarFont;

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

        Rectangle startingScreenBackgroundRect;
        Texture2D startingScreenBackgroundText;

        Rectangle descriptionScreenBackgroundRect;
        Texture2D descriptionScreenBackgroundText;

        Rectangle AvatarSelectScreenRect;
        Texture2D AvatarSelectText;

        Rectangle VictoryScreenRect;
        Texture2D VictoryScreenText;
        
        /*
        * Other graphics
        */

        Rectangle startButtonRect;
        Texture2D startButtonText;

        Rectangle startButtonRect2;
        Texture2D startButtonText2;


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
            roomBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            medicalWardBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            adminOfficeBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            hallwayBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            startingScreenBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            descriptionScreenBackgroundRect = new Rectangle(0, 0, screenWidth, screenHeight);
            AvatarSelectScreenRect = new Rectangle(0, 0, screenWidth, screenHeight);

            /*
            *These are for the other graphics
            */

            startButtonRect = new Rectangle(380, 390, 50, 50);
            startButtonRect2 = new Rectangle(675, 400, 50, 50);

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
            avatarFont = Content.Load<SpriteFont>("SpriteFont3");

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
            hallwayBackgroundText = Content.Load<Texture2D>("MHH");
            medicalWardBackgroundText = Content.Load<Texture2D>("MHMW");
            adminOfficeBackgroundText = Content.Load<Texture2D>("MHAO");
            roomBackgroundText = Content.Load<Texture2D>("MHRoom");
            startingScreenBackgroundText = Content.Load<Texture2D>("outside of asylum");
            descriptionScreenBackgroundText = Content.Load<Texture2D>("Description Screen");
            AvatarSelectText = Content.Load<Texture2D>("Avatar Select Screen");

            /*
            *These are for the other graphics
            */

            startButtonText = Content.Load<Texture2D>("start button");
            startButtonText2 = Content.Load<Texture2D>("start button");

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
             * mouse click from start screen changes to Game screen
             * 'H' button = Help Screen and works for both the Start Screen and Game Screen
             * 'B' button changes you back to the screen you were previously on before you used the Help Screen
             * So for example if you were on the Start Screen and you pressed 'H' you would go to the Help Screen
             * Then to get back you would click 'B' and that would take you back to the Start Screen
             * If you do go to the Help Screen from the Game Screen the 'B' button would take you back to the Game Screen
             * 'G' button from the Game Screen takes you to the Gameover Screen
             * 'S' button from the Gameover Screen takes you to the Start Screen
             * 'L' button from the Game Screen takes you to the Losing Screen
            */
            
            //The Start to Game Screen will go from the Start to the first Game Screen the AvatarSelect

            if (mouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton == ButtonState.Released)
            {
                if (screentype == Screen.Start &&
                   (mouse.X > startButtonRect.X && mouse.X < (startButtonRect.X + startButtonRect.Width)) &&
                   (mouse.Y > startButtonRect.Y && mouse.Y < (startButtonRect.Y + startButtonRect.Height)))
                {
                    screentype = Screen.Describe;
                }

                if (screentype == Screen.Describe &&
                   (mouse.X > startButtonRect2.X && mouse.X < (startButtonRect2.X + startButtonRect2.Width)) &&
                   (mouse.Y > startButtonRect2.Y && mouse.Y < (startButtonRect2.Y + startButtonRect2.Height)))
                {
                    screentype = Screen.AvatarSelect;
                }

                if (screentype == Screen.AvatarSelect)
                {
                    if (mouse.LeftButton == ButtonState.Pressed
                        && oldMouse.LeftButton == ButtonState.Released)
                    {
                        if ((mouse.X > girlBeforeRect.X && mouse.X < girlBeforeRect.X + girlBeforeRect.Width) &&
                        (mouse.Y > girlBeforeRect.Y && mouse.Y < girlBeforeRect.Y + girlBeforeRect.Height) || (mouse.X > boyBeforeRect.X && mouse.X < boyBeforeRect.X + boyBeforeRect.Width) &&
                        (mouse.Y > boyBeforeRect.Y && mouse.Y < boyBeforeRect.Y + boyBeforeRect.Height))
                        {
                            screentype = Screen.Game;
                        }
                        if ((mouse.X > girlBeforeRect.X && mouse.X < girlBeforeRect.X + girlBeforeRect.Width) &&
                       (mouse.Y > girlBeforeRect.Y && mouse.Y < girlBeforeRect.Y + girlBeforeRect.Height))
                        {
                            VictoryScreenRect = girlWinGameoverBackgroundRect;
                            VictoryScreenText = girlWinGameoverBackgroundText;
                        }
                        if ((mouse.X > boyBeforeRect.X && mouse.X < boyBeforeRect.X + boyBeforeRect.Width) &&
                       (mouse.Y > boyBeforeRect.Y && mouse.Y < boyBeforeRect.Y + boyBeforeRect.Height))
                        {
                            VictoryScreenRect = boyWinGameoverBackgroundRect;
                            VictoryScreenText = boyWinGameoverBackgroundText;
                        }
                    }
                }
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
            
             // TODO: Add your drawing code here
            /*
             * Help Screen = Black
             * Game Screen = Green
             * Losing Screen = Purple
            */
            Vector2 textLocation1 = new Vector2(200, 50);
            Vector2 textLocation2 = new Vector2(550, 50);

            spriteBatch.Begin();
            if (screentype == Screen.Start)
            {
                spriteBatch.Draw(startingScreenBackgroundText, startingScreenBackgroundRect, Color.White);
                spriteBatch.Draw(startButtonText, startButtonRect, Color.White);
            }
            else if (screentype == Screen.Describe)
            {
                spriteBatch.Draw(descriptionScreenBackgroundText, descriptionScreenBackgroundRect, Color.White);
                spriteBatch.Draw(startButtonText2, startButtonRect2, Color.White);
            }
            else if (screentype == Screen.Help)
            {
                GraphicsDevice.Clear(color[0]);
            }
            else if (screentype == Screen.AvatarSelect)
            {
                spriteBatch.Draw(AvatarSelectText, AvatarSelectScreenRect, Color.White);
                spriteBatch.Draw(girlBeforeText, girlBeforeRect = new Rectangle(550, 85, 100, 375), Color.White);
                spriteBatch.Draw(BoyBeforeText, boyBeforeRect = new Rectangle(200, 85, 100, 375), Color.White);
                spriteBatch.DrawString(avatarFont, "Boy", textLocation1, Color.White);
                spriteBatch.DrawString(avatarFont, "Girl", textLocation2, Color.White);
            }
            else if (screentype == Screen.Gameover)
            {
                spriteBatch.Draw(VictoryScreenText, VictoryScreenRect, Color.White);
                spriteBatch.DrawString(EndingScreenFont, endingCredits[0], new Vector2(125, 100), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[1], new Vector2(350, 220), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[2], new Vector2(335, 240), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[3], new Vector2(330, 260), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[4], new Vector2(327, 280), Color.Red);
                spriteBatch.DrawString(EndingScreenCredits, endingCredits[5], new Vector2(340, 300), Color.Red);
            }
            else if (screentype == Screen.Game)
            {
                GraphicsDevice.Clear(color[1]);
            }
            else if (screentype == Screen.Losing)
            {
                GraphicsDevice.Clear(color[2]);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
