using System;
using System.Collections.Generic;

#if ANDROID
using Android.App;
#endif

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

using Microsoft.Xna.Framework.GamerServices;
using CustomModelTypes;

namespace CustomModelSample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CustomModel model;

        Matrix world;
        Matrix view;
        Matrix projection;
		
        public Game1 ()  
		{
			graphics = new GraphicsDeviceManager (this);
			
			Content.RootDirectory = "Content";
			
			graphics.PreferMultiSampling = true;
#if ANDROID || IPHONE || PSS
			graphics.IsFullScreen = true;
#else
			graphics.IsFullScreen = false;
#endif
			
			graphics.PreferredBackBufferHeight = 480;
			graphics.PreferredBackBufferWidth = 320;

			graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight | DisplayOrientation.PortraitDown;			
		}
		
		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here

			base.Initialize ();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

            // TODO: use this.Content to load your game content here
            model = Content.Load<CustomModel>("tank");

            // Calculate camera view and projection matrices.
            view = Matrix.CreateLookAt(new Vector3(1000, 500, 0),
                                       new Vector3(0, 150, 0), Vector3.Up);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                             GraphicsDevice.Viewport.AspectRatio, 10, 10000);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				Exit();
			}
			
            // TODO: Add your update logic here
            HandleInput();

            // Update the world transform to make the model rotate.
            float time = (float)gameTime.TotalGameTime.TotalSeconds;

            world = Matrix.CreateRotationY(time * 0.1f);

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
            // TODO: Add your drawing code here

            model.Draw(world, view, projection);			
            
			base.Draw (gameTime);

			spriteBatch.End ();
            
			// Now let's try some scissoring
			//Disabled as this scissoring code is /wrong/
			/*spriteBatch.Begin ();

			spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle (50, 40, (int)clippingSize, (int)clippingSize);
			spriteBatch.GraphicsDevice.RasterizerState.ScissorTestEnable = true;

			spriteBatch.Draw (texture, new Rectangle (50, 40, 320, 40), Color.White);
			spriteBatch.DrawString (font, "Scissor Clipping Test", new Vector2 (50, 40), Color.Red);
			
			spriteBatch.End ();

			spriteBatch.GraphicsDevice.RasterizerState.ScissorTestEnable = false;*/
            

		}
		
		                #region Handle Input


        /// <summary>
        /// Handles input for quitting the game.
        /// </summary>
        private void HandleInput()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            // Check for exit.
            if (currentKeyboardState.IsKeyDown(Keys.Escape) ||
                currentGamePadState.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }
        }


        #endregion

	}
}
