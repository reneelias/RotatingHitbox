using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatingHitbox
{
    class BouncingRectangle : Sprite
    {
        Rectangle bounceBounds;
        float rotationSpeed;
        Vector2 velocity;
        Vector2[] cornerPoints;

        public BouncingRectangle(Texture2D texture, Vector2 position, Color color, Vector2 scale, Rectangle bounceBounds, float rotationSpeed, Vector2 velocity)
            : base(texture, position, color)
        {
            this.bounceBounds = bounceBounds;
            this.rotationSpeed = rotationSpeed;
            this.velocity = velocity;
            Scale = scale;
            SetCenterOrigin();
            cornerPoints = new Vector2[4];
            cornerPoints[0] = new Vector2(-Width / 2f, -Height / 2f);
            cornerPoints[1] = new Vector2(-Width / 2f, Height / 2f);
            cornerPoints[2] = new Vector2(Width / 2f, Height / 2f);
            cornerPoints[3] = new Vector2(Width / 2f, -Height / 2f);
        }

        public void Update(GameTime gameTime)
        {
            Rotation += rotationSpeed;
            position += velocity;

           

            foreach(Vector2 point in GetRotatedCorners())
            {
                if (point.X < 0 || point.X > bounceBounds.Width)
                {
                    velocity.X *= -1;
                    rotationSpeed *= -1;
                }
                if (point.Y  < 0 || point.Y > bounceBounds.Height)
                {
                    velocity.Y *= -1;
                }
            }

            //if (position.X - Origin.X < 0 || position.X + Origin.X > bounceBounds.Width)
            //{
            //    velocity.X *= -1;
            //}
            //if (position.Y - Origin.Y < 0 || position.Y + Origin.Y > bounceBounds.Height)
            //{
            //    velocity.Y *= -1;
            //}
        }

        public Vector2[] GetRotatedCorners()
        {
            Matrix rotationMatrix = Matrix.CreateRotationZ(Rotation);

            Vector2[] rotatedCornerPoints = new Vector2[4];

            for (int i = 0; i < cornerPoints.Length; i++)
            {
                Vector2 rotatedCorner = Vector2.Transform(cornerPoints[i], rotationMatrix);
                Matrix translateBack = Matrix.CreateTranslation(new Vector3(position + rotatedCorner, 9));

                rotatedCornerPoints[i] = new Vector2();
                rotatedCornerPoints[i].X = translateBack.Translation.X;
                rotatedCornerPoints[i].Y = translateBack.Translation.Y;
            }

            return rotatedCornerPoints;
        }

        public void CollideWithRectangle(BouncingRectangle bouncingRect)
        {
            foreach(Vector2 point in GetRotatedCorners())
            {
                for(int i = 0; i )
            }
        }

    }
}
