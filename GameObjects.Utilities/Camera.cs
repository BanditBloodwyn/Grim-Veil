using Core.Extentions;
using Core.Patterns.Creators.Singletons;
using Framework.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Framework.InputManagement;

namespace GameObjects.Utilities
{
    public class Camera : Singleton<Camera>, IUpdatable
    {
        private bool _isPanning;

        public Point Position { get; set; } = Point.Zero;

        public float Zoom { get; set; } = 1.0f;
        public float Rotation { get; set; } = 0.0f;

        public float PanningSpeed { get; set; } = 0.1f;
        public float ZoomingSpeed { get; set; } = 0.0002f;

        public Matrix GetTransformation(GraphicsDevice graphics)
        {
            int viewportWidth = graphics.Viewport.Width;
            int viewportHeight = graphics.Viewport.Height;
            Matrix transform = Matrix.CreateRotationZ(Rotation);

            // Apply scaling centered in the middle of the screen
            transform *= Matrix.CreateTranslation(-viewportWidth / 2f, -viewportHeight / 2f, 0);
            transform *= Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            transform *= Matrix.CreateTranslation(viewportWidth / 2f, viewportHeight / 2f, 0);

            return transform;
        }

        public void Update(GameTime gameTime)
        {
            _isPanning = InputManager.IsMiddleMouseButtonHeld();

            if (_isPanning)
                Move(GetPanning(gameTime));

            AdjustZoom(GetZooming());
        }

        private void Move(Point amount)
        {
            Position += amount;
        }

        private void AdjustZoom(float amount)
        {
            Zoom += amount;

            if (Zoom < 0.1f)
                Zoom = 0.1f;
        }

        private Point GetPanning(GameTime gameTime)
        {
            Point mouseDelta = InputManager.MouseDelta();
            if (mouseDelta == Point.Zero)
                return mouseDelta;

            float totalMilliseconds = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Vector2 panningPoint = mouseDelta.ToVector2() * totalMilliseconds * PanningSpeed;

            return new Point((int)panningPoint.X, (int)panningPoint.Y);
        }

        private float GetZooming()
        {
            if (InputManager.IsControlHeld())
                return 0;
                
            return InputManager.MouseWheelDelta() * ZoomingSpeed;
        }

        public string GetDebugInfo()
        {
            StringBuilder sb = new();

            sb.AppendLine("Camera Info:");

            sb.AppendSpaceTab().Append("Position:").AppendSpaceTab().Append(Position);
            sb.AppendLine();
            sb.AppendSpaceTab().Append("Zoom:").AppendSpaceTab().Append(Zoom);
            sb.AppendLine();
            sb.AppendSpaceTab().Append("Rotation: ").AppendSpaceTab().Append(Rotation);
            sb.AppendLine();
            sb.AppendSpaceTab().Append("_isPanning: ").AppendSpaceTab().Append(_isPanning);

            return sb.ToString();
        }
    }
}
