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
        MouseState oldMouse = Mouse.GetState();
        Color[] color = new Color[2] { Color.Black, Color.Purple };
        string[] endingCredits = new string[6] { "Congratulations you escaped!", "Created by:", "Dani Alvarez",
            "Duncan Hadley", "Nathan Johnson", "Ezinne Megwa" };

        SpriteFont EndingScreenFont;
        SpriteFont EndingScreenCredits;
        SpriteFont avatarFont;
        SpriteFont ActionOptionsFont; // Choices you have; blue boxes on CYOA Level Map
        SpriteFont ResponseFont; // Effect of your action; pink boxes on CYOA Level Map
        SpriteFont playAgainFont;

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

        Rectangle angryPatientRect;
        Texture2D angryPatientText;

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

        Rectangle losingScreenRect;
        Texture2D losingScreenText;

        Rectangle HelpScreenRect;
        Texture2D HelpScreenText;

        /*
        * Other graphics
        */

        Rectangle startButtonRect;
        Texture2D startButtonText;

        Rectangle startButtonRect2;
        Texture2D startButtonText2;

        Rectangle playAgainArrowRect;
        Texture2D playAgainArrowText;

        Rectangle questionMarkRect;
        Texture2D questionMarkText;

        Rectangle playAgainArrow2Rect;
        Texture2D playAgainArrow2Text;

        Texture2D GameScreenText;

        String choicePath;

        /*
         * This is for the levels
         */

        Rectangle CBRect1; //CB = Choice Box
        Rectangle CBRect2; //CB = Choice Box
        Rectangle CBRect3; //CB = Choice Box
        Rectangle CBRect4; //CB = Choice Box
        Rectangle CBRect5; //CB = Choice Box
        Rectangle CBRect6; //CB = Choice Box
        Rectangle CBRect7; //CB = Choice Box
        Rectangle CBRect8; //CB = Choice Box
        Rectangle CBRect9; //CB = Choice Box
        Rectangle CBRect10; //CB = Choice Box
        Rectangle CBRect11; //CB = Choice Box

        Texture2D ChoiceBoxText;
        Rectangle EffectBoxRect;
        Texture2D EffectBoxText;

        int x, y, w, h;//Cb positons
        string Choice1;//choice text
        string Choice2;
        string Choice3;

        string prompt;//effect text


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
            losingScreenRect = new Rectangle(0, 0, screenWidth, screenHeight);
            HelpScreenRect = new Rectangle(0, 0, screenWidth, screenHeight);

            /*
            *These are for the other graphics
            */

            startButtonRect = new Rectangle(380, 390, 50, 50);
            startButtonRect2 = new Rectangle(675, 400, 50, 50);
            playAgainArrowRect = new Rectangle(650, 400, 100, 50);
            questionMarkRect = new Rectangle(750, 90, 50, 50);
            playAgainArrow2Rect = new Rectangle(50, 400, 100, 50);

            /*
             * This is for the levels
             */

            EffectBoxRect = new Rectangle(10, 0, 780, 75);

            x = 10;
            y = 400;
            w = 200;
            h = 70;

            CBRect1 = new Rectangle(x, y, w, h);
            CBRect2 = new Rectangle(x + 580, y, w, h);
            CBRect3 = new Rectangle(x, y, w, h);
            CBRect4 = new Rectangle(x + 580, y, w, h);
            CBRect5 = new Rectangle(x, y, w, h);
            CBRect6 = new Rectangle(x + 300, y, w, h);
            CBRect7 = new Rectangle(x + 580, y, w, h);
            CBRect8 = new Rectangle(x, y, w, h);
            CBRect9 = new Rectangle(x + 580, y, w, h);
            CBRect10 = new Rectangle(x, y, w, h);
            CBRect11 = new Rectangle(x + 580, y, w, h);

            choicePath = "";

            prompt = "You are getting ready to leave when the asylum breaks out into chaos!";
            Choice1 = "Run out into\n the storm!";
            Choice2 = "Hide in your \nroom!";
            Choice3 = "";

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
            ActionOptionsFont = Content.Load<SpriteFont>("SpriteFont4");
            ResponseFont = Content.Load<SpriteFont>("SpriteFont4");
            playAgainFont = Content.Load<SpriteFont>("SpriteFont5");

            /*
            *These are the textures for the avatars
            */

            BoyBeforeText = Content.Load<Texture2D>("BoyPatient");
            boyAfterText = Content.Load<Texture2D>("BoyAfterPatient");
            girlBeforeText = Content.Load<Texture2D>("GirlPatient");
            girlAfterText = Content.Load<Texture2D>("GirlAfterPatient");
            nurseGroupText = Content.Load<Texture2D>("group of nurses");
            nurseText = Content.Load<Texture2D>("nurse1");
            angryPatientText = Content.Load<Texture2D>("patient1");

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
            losingScreenText = Content.Load<Texture2D>("Losing Screen");
            HelpScreenText = Content.Load<Texture2D>("Help Screen");

            /*
             * 
            *These are for the other graphics
            */

            startButtonText = Content.Load<Texture2D>("start button");
            startButtonText2 = Content.Load<Texture2D>("start button");
            playAgainArrowText = Content.Load<Texture2D>("green arrow");
            questionMarkText = Content.Load<Texture2D>("question mark");
            playAgainArrow2Text = Content.Load<Texture2D>("green arrow2");
            EffectBoxText = Content.Load<Texture2D>("EffectBox");
            ChoiceBoxText = Content.Load<Texture2D>("ChoiceBox");

            /*
             * Logic that controls the screeen changes
             * 
             */

            GameScreenText = Content.Load<Texture2D>("MHRoom");

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
                if (screentype == Screen.Start && startButtonRect.Contains(mouse.X, mouse.Y))
                {
                    screentype = Screen.Describe;
                }
                else if (screentype == Screen.Describe && startButtonRect2.Contains(mouse.X, mouse.Y))
                {
                    screentype = Screen.AvatarSelect;
                }
                else if (screentype == Screen.AvatarSelect)
                {
                    if (mouse.LeftButton == ButtonState.Pressed
                        && oldMouse.LeftButton == ButtonState.Released)
                    {
                        if (girlBeforeRect.Contains(mouse.X, mouse.Y) || boyBeforeRect.Contains(mouse.X, mouse.Y))
                        {
                            screentype = Screen.Game;
                        }
                        // Decides which Gameover Screen you get
                        if (girlBeforeRect.Contains(mouse.X, mouse.Y))
                        {
                            VictoryScreenRect = girlWinGameoverBackgroundRect;
                            VictoryScreenText = girlWinGameoverBackgroundText;
                        }
                        if (boyBeforeRect.Contains(mouse.X, mouse.Y))
                        {
                            VictoryScreenRect = boyWinGameoverBackgroundRect;
                            VictoryScreenText = boyWinGameoverBackgroundText;
                        }
                    }
                }

                /*
                 *This is the code that changes the game from screen to screen Let me explain what I did. 
                 * 
                 * The prompt is the effect box and the choice 1 and 2 and a possible 3, are the texts for the choices
                 * 
                 * The positions of the the blue rectangle boxes, AKA CBRect is fixed for the enitre game. 
                 * Meaning they won't change from screen to screen, they have to stay where they are.
                 * Same for the Pink Effect box.
                 * 
                 * To change the back ground screen I created a new Texture2D called GameScreen. 
                 * What this will do is, for each mouse click on the Choice box, it will change the background,
                 * so in the code down below, clicking on the "Run into storm choice" or CBRect1,
                 * changes the screen Texture2D to the hallway.
                 * the prompt and the Choice text should also change with each click as shown below.
                 * 
                 * Any quiestions, Text me and I'll try to explain.
                 * 
                 * */
                if (screentype == Screen.Game)
                {
                    if (choicePath.Length == 0)
                    {
                        if (CBRect1.Contains(mouse.X, mouse.Y))//run into the storm
                        {
                            GameScreenText = Content.Load<Texture2D>("MHH");
                            prompt = "You collide into a rampaging patient. They glare at you with wild eyes";
                            Choice1 = "\'Excuse Me.\'";
                            Choice2 = "\'Fight Me!\'";
                            choicePath = choicePath + 1;
                        }
                        if (CBRect2.Contains(mouse.X, mouse.Y))//hide in your room
                        {
                            prompt = "You remain in your room when the door slams open and a bunch of nurses with\ntranquilizer guns come in.";
                            Choice1 = "Hide under your \nbed";
                            Choice2 = "Scream and\nKick them out";
                            Choice3 = " \'What's Up?\' ";
                            choicePath = choicePath + 2;
                        }
                    }
                    else if (choicePath.Length == 1)
                    {
                        if (CBRect3.Contains(mouse.X, mouse.Y) && choicePath == "1") //Excuse me
                        {
                            prompt = "Its alright sugar bun! They smile and kiss you unexpectedly. You leave, \nwhere are you going?";
                            Choice1 = "Medical Ward";
                            Choice2 = "Administration \nOffice";
                            Choice3 = "";
                            choicePath = choicePath + 1;
                        }
                        if (CBRect4.Contains(mouse.X, mouse.Y) && choicePath == "1") //Fight me
                        {
                            prompt = "They bite your arm and scratch your face. Bleeding, you manage to throw \nthem off you. Your move to attack!";
                            Choice1 = "K.O. with One \nPunch";
                            Choice2 = "Kick in the jaw";
                            Choice3 = "";
                            choicePath = choicePath + 2;
                        }
                    }
                    else if (choicePath.Length == 2)
                    {
                        if (CBRect8.Contains(mouse.X, mouse.Y)) //Medical Ward
                        {
                            prompt = "You make your way to the medical ward safely, grab your normal clothes, and \nexit. On your way out, you run into one of the nurses. What do you do?";
                            Choice1 = "Force your way out";
                            Choice2 = "Calmly explain what you are doing";
                            Choice3 = "";

                        }

                        if (CBRect9.Contains(mouse.X, mouse.Y)) //Fight me
                        {
                            prompt = "You acquire your release forms and head for the door. As you leave a small \nchild asks you to take them with you.";
                            Choice1 = "You know you cant so you say a quick sorry and run to the medical ward.";
                            Choice2 = "";
                            Choice3 = "";

                        }
                        if (CBRect10.Contains(mouse.X, mouse.Y)) //Fight me
                        {
                            prompt = "They fall and you make a run to the...";
                            Choice1 = "Administrations \nOffice";
                            Choice2 = "Hospital Ward";
                            Choice3 = "";

                        }
                        if (CBRect11.Contains(mouse.X, mouse.Y)) //Fight me
                        {
                            prompt = "They fall and you make a run to the...";
                            Choice1 = "Administrations \nOffice";
                            Choice2 = "Hospital Ward";
                            Choice3 = "";
                        }
                        if (CBRect10.Contains(mouse.X, mouse.Y))
                        {
                            GameScreenText = adminOfficeBackgroundText;
                            prompt = "You acquire your release forms and head for the door. As you leave a small \nchild asks you to take them with you.";
                            Choice1 = "You know you can’t so you say a quick “sorry” and run to the medical ward.";
                            Choice2 = "You take them along";
                        }
                        if (CBRect11.Contains(mouse.X, mouse.Y)) 
                        {
                            prompt = "You make your way to the medical ward safely, grab your normal clothes, and \nexit. On your way out, you run into one of the nurses. What do you do?";
                            Choice1 = "Surrender";
                            Choice2 = "Force your way out";
                            Choice3 = "Calmly explain what you are doing";
                        }
                    }

                    if (questionMarkRect.Contains(mouse.X, mouse.Y))
                    {
                        screentype = Screen.Help;
                    }
                }
                else if (screentype == Screen.Losing)
                {
                    if (playAgainArrowRect.Contains(mouse.X, mouse.Y))
                    {
                        screentype = Screen.Start;
                    }
                }
                else if (screentype == Screen.Help)
                {
                    if (playAgainArrowRect.Contains(mouse.X, mouse.Y))
                    {
                        screentype = Screen.Game;
                    }
                }
                else if (screentype == Screen.Gameover)
                {
                    if (playAgainArrow2Rect.Contains(mouse.X, mouse.Y))
                    {
                        screentype = Screen.Start;
                    }
                }
            }

            if (Key.IsKeyDown(Keys.G) && screentype == Screen.Game)
            {
                screentype = Screen.Gameover;
            }
            else if (Key.IsKeyDown(Keys.L) && screentype == Screen.Game)
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

            /*
             * Help Screen = Black
             * Losing Screen = Purple
            */
            Vector2 textLocation1 = new Vector2(225, 50);
            Vector2 textLocation2 = new Vector2(585, 50);
            Vector2 textLocation3 = new Vector2(20, 0);
            Vector2 textLocation4 = new Vector2(60, 325);

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
                spriteBatch.Draw(HelpScreenText, HelpScreenRect, Color.White);
                spriteBatch.Draw(playAgainArrowText, playAgainArrowRect, Color.White);
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

                spriteBatch.Draw(playAgainArrow2Text, playAgainArrow2Rect, Color.White);
                spriteBatch.DrawString(playAgainFont, "Play \nAgain", textLocation4, Color.Green);
            }
            else if (screentype == Screen.Game)
            {
                spriteBatch.Draw(GameScreenText, roomBackgroundRect, Color.White);
                spriteBatch.Draw(EffectBoxText, EffectBoxRect, Color.White);
                spriteBatch.DrawString(ResponseFont, prompt, textLocation3, Color.White);

                spriteBatch.Draw(ChoiceBoxText, CBRect1, Color.White);
                spriteBatch.DrawString(ActionOptionsFont, Choice1, new Vector2(20, 405), Color.White);

                spriteBatch.Draw(ChoiceBoxText, CBRect2, Color.White);
                spriteBatch.DrawString(ActionOptionsFont, Choice2, new Vector2(600, 405), Color.White);

                //if (Choice3 != "")
                //{
                //   spriteBatch.Draw(ChoiceBoxText, CBRect3, Color.White);
                //    spriteBatch.DrawString(ActionOptionsFont, Choice3, new Vector2(605, 330), Color.White);
                //}

                spriteBatch.Draw(questionMarkText, questionMarkRect, Color.White);
            }
            else if (screentype == Screen.Losing)
            {
                spriteBatch.Draw(losingScreenText, losingScreenRect, Color.White);
                spriteBatch.Draw(playAgainArrowText, playAgainArrowRect, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
