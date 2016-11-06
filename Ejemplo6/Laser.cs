using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo6
{
    class Laser
    {
        private Game _game;
        private Texture2D _laser;
        private Vector2 _posicionlaser;
        private Boolean _activo;
        
        public Vector2 Posicionlaser
        {
            get
            {
                return _posicionlaser;
            }
            set
            {
                _posicionlaser = value;
            }
        }

        public Boolean Activo
        {
            get
            {
                return _activo;
            }
            set
            {
                _activo = value;
            }
        }


        public Laser (Game game, Vector2 posicion)
        {
            this._game = game;
            this._posicionlaser = posicion;
            this._activo = true;

        }


        public Game game
        {
            get { return _game; }
        }

        public ContentManager Content
        {
            get { return _game.Content; }
        }

        public virtual void LoadContent()
        {
            _laser = Content.Load<Texture2D>("laser");
        }


        public virtual void Update (GameTime gametime)
        {
            if(_posicionlaser.Y != 0)
            {
                Console.WriteLine(_posicionlaser);
                _posicionlaser.Y--;
            }
            else
            {
                this.Activo = false;
            }
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        { 
            if (_activo)
            spriteBatch.Draw(_laser, _posicionlaser, Color.White);
        }


    }
}
