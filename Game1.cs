using System;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace clicker;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D spelertexture;
    private Vector2 spelercoordinaten;

    private int muisx;
    private int muisy;

    private Random randomcoordinaten;

    Rectangle spelerhitbox;

    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        //Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "game.exe";
        _graphics.PreferredBackBufferHeight = 640;
        _graphics.PreferredBackBufferWidth = 640;
    }

    protected override void Initialize()
    {   
        spelercoordinaten = new Vector2(175, 82);

        base.Initialize();

        
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // laad de texture in door de Stream te paken van GraphicsDevice en dan gebruikt de FromStream methode de OpenStream Methode
        // om de sprite0 png te openen als stream en dan te laden van de bin/Debug/net8.0/textures directory(dir)
        spelertexture = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("textures/sprite0.png"));
        //Convert.ToInt32() omdat de X en Y coordinaten van de speler niet een int(hetzelfde als int32) is maar een float dus van flot naar int(int32)
        spelerhitbox = new Rectangle(Convert.ToInt32(spelercoordinaten.X),Convert.ToInt32(spelercoordinaten.Y),spelertexture.Width,spelertexture.Height);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }


        MouseState muiscoordinaten = Mouse.GetState();
        int muisx = muiscoordinaten.X;
        int muisy = muiscoordinaten.Y;
        randomcoordinaten = new Random();


        //bewings code
        //if (Keyboard.GetState().IsKeyDown(Keys.Left))
        //{
            //spelercoordinaten.X-=5;
        //}
        //else if (Keyboard.GetState().IsKeyDown(Keys.Right))
        //{
            //spelercoordinaten.X+=5;
        //}
        //else if (Keyboard.GetState().IsKeyDown(Keys.Space))
        //{
            //spelercoordinaten.Y-=5;
        //}

        


        //if (Keyboard.GetState().IsKeyDown(Keys.A))
        //{
            //spelercoordinaten.X-=5;
        //}
        //else if (Keyboard.GetState().IsKeyDown(Keys.D))
        //{
            //spelercoordinaten.X+=5;
        //}
        

        
        if (Keyboard.GetState().IsKeyDown(Keys.NumPad0))
        {
            IsMouseVisible = false;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
        {
            IsMouseVisible = true;
        }

        
        
        if (spelerhitbox.Contains(muisx,muisy))
        {   
            // Thread.Sleep(1000)
            // wacht 1000 milliseconden 
            // 1000 milliseconden = 1 seconde
            // dus als 1 seconde 1000 milliseconden zijn is een minuut 60 . 1000 = 60000 milliseconden
            
            spelercoordinaten.X = randomcoordinaten.Next(0,300);
            spelercoordinaten.Y = randomcoordinaten.Next(40,334);
            Thread.Sleep(1000);

        }
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Aquamarine);

        _spriteBatch.Begin();
        _spriteBatch.Draw(spelertexture,spelercoordinaten, Color.White);
        _spriteBatch.End();

        

        base.Draw(gameTime);
    }
}
