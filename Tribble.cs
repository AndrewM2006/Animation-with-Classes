using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Animation_with_Classes
{
    class Tribble
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed;
        private Song _song;
        private Color _color;
        Random generator = new Random();
        public Tribble(Texture2D texture, Song sound)
        {
            _texture = texture;
            _rectangle = new Rectangle(generator.Next(20, 400), generator.Next(20, 400), generator.Next(50, 100), generator.Next(50, 100));
            while(_speed.X == 0 && _speed.Y == 0)
            {
                _speed = new Vector2(generator.Next(-4, 4), generator.Next(-4, 4));
            }
            _song = sound;
            _color = new Color(Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)));
        }

        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed, Song song)
        {
            _texture = texture;
            _rectangle = rectangle;
            _speed = speed;
            _song = song;
        }

        public Tribble(Texture2D texture, Rectangle rectangle, Vector2 speed, Song song, Color color)
        {
            _color = color;
            _texture = texture;
            _rectangle = rectangle;
            _speed = speed;
            _song = song;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Color Color
        {
            get { return _color; }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texture, _rectangle, _color);
        }

        public void Move(GraphicsDeviceManager graphics)
        {
            _rectangle.Offset(_speed);
            if (_speed.Y!=0 && (_rectangle.Right > graphics.PreferredBackBufferWidth || _rectangle.Left < 0))
            {
                _speed.X *= -1;
                MediaPlayer.Play(_song);
                _color = new Color(Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)));
            }
            if (_speed.X != 0 && (_rectangle.Bottom > graphics.PreferredBackBufferHeight || _rectangle.Top < 0))
            {
                _speed.Y *= -1;
                MediaPlayer.Play(_song);
                _color = new Color(Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)), Convert.ToByte(generator.Next(255)));
            }
            if (_rectangle.Left > graphics.PreferredBackBufferWidth && _speed.Y == 0)
            {
                _rectangle = new Rectangle(1 - _rectangle.Width, _rectangle.Top, _rectangle.Width, _rectangle.Height);
                MediaPlayer.Play(_song);
            }
            if (_rectangle.Right < 0 && _speed.Y == 0)
            {
                _rectangle = new Rectangle(graphics.PreferredBackBufferWidth, _rectangle.Top, _rectangle.Width, _rectangle.Height);
                MediaPlayer.Play(_song);
            }
            if (_rectangle.Top > graphics.PreferredBackBufferHeight && _speed.X == 0)
            {
                _rectangle = new Rectangle(_rectangle.Left, 1 - _rectangle.Height, _rectangle.Width, _rectangle.Height);
                MediaPlayer.Play(_song);
            }
            if (_rectangle.Bottom < 0 && _speed.X == 0)
            {
                _rectangle = new Rectangle(_rectangle.Left, graphics.PreferredBackBufferHeight, _rectangle.Width, _rectangle.Height);
                MediaPlayer.Play(_song);
            }
        }
    }
}
