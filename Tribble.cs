using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Animation_with_Classes
{
    class Tribble
    {
        private Texture2D _texture;
        private Microsoft.Xna.Framework.Rectangle _rectangle;
        private Microsoft.Xna.Framework.Vector2 _speed;

        public Tribble(Texture2D texture, Microsoft.Xna.Framework.Rectangle rect, Microsoft.Xna.Framework.Vector2 speed)
        {
            _texture = texture;
            _rectangle = rect;
            _speed = speed;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Microsoft.Xna.Framework.Rectangle Bounds
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public Microsoft.Xna.Framework.Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public void Move(GraphicsDeviceManager graphics)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Right > graphics.PreferredBackBufferWidth || _rectangle.Left < 0)
            {
                _speed.X *= -1;
            }
            if (_rectangle.Bottom > graphics.PreferredBackBufferHeight || _rectangle.Top < 0)
            {
                _speed.Y *= -1;
            }
        }
    }
}
