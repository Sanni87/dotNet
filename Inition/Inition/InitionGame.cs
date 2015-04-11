using Inition.Model;
using Inition.Model.Colecciones;
using Inition.Model.Elementos;
using Inition.Model.Factory;
using Inition.Model.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Inition
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class InitionGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ListaFormas formas;
        ListaColisionables colisionables;
        List<RectanguloControlable> controlables;

        public InitionGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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


            formas = new ListaFormas();
            colisionables = new ListaColisionables();
            controlables = new List<RectanguloControlable>();


            IColisionable rectangulo;

            //Prueba para meter muchos cuadraditos colisionables
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 25; i++)
                {
                    rectangulo = RectanguloFactory.CrearRectanguloAutomatico(graphics, 20, 20, Color.BurlyWood, 1 + i * 21, j * 21);

                    formas.Add(rectangulo);
                    colisionables.Add(rectangulo);
                }
            }

            //rectangulo = RectanguloFactory.CrearRectanguloAutomatico(graphics, 20, 20, Color.Brown, 390, 290);

            //formas.Add(rectangulo);
            //colisionables.Add(rectangulo);

            var rectanguloControlable = RectanguloFactory.CrearRectanguloMovible(graphics, 20, 100, Color.Blue, 5, 250);
            rectanguloControlable.Controlado = true;

            formas.Add(rectanguloControlable);
            colisionables.Add(rectanguloControlable);
            controlables.Add(rectanguloControlable);

            rectanguloControlable = RectanguloFactory.CrearRectanguloMovible(graphics, 20, 100, Color.Blue, 775, 250);

            formas.Add(rectanguloControlable);
            colisionables.Add(rectanguloControlable);
            controlables.Add(rectanguloControlable);

            //paredes
            rectangulo = RectanguloFactory.CrearPared(graphics, 1, 600, Color.Black, -1, -1);

            formas.Add(rectangulo);
            colisionables.Add(rectangulo);

            rectangulo = RectanguloFactory.CrearPared(graphics, 1, 600, Color.Black, 800, 0);

            formas.Add(rectangulo);
            colisionables.Add(rectangulo);

            rectangulo = RectanguloFactory.CrearPared(graphics, 798, 1, Color.Black, 2, -1);

            formas.Add(rectangulo);
            colisionables.Add(rectangulo);

            rectangulo = RectanguloFactory.CrearPared(graphics, 798, 1, Color.Black, 2, 600);

            formas.Add(rectangulo);
            colisionables.Add(rectangulo);

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
            PadInput.Input.Update();

            if (PadInput.Input.Salir) Exit();

            formas.Update();
            colisionables.ComprobarColisiones();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            this.formas.Draw(ref spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
