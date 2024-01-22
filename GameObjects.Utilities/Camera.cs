using Core.Extentions;
using Framework.Debugging;
using Framework.InputManagement;
using Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace GameObjects.Utilities
{
    public class Camera : DebuggableSingleton<Camera>
    {
        private bool _isPanning;

        public Point Position { get; set; } = Point.Zero;

        public float Zoom { get; set; } = 1.0f;
      
        public float Rotation { get; set; }

        public Matrix GetTransformation(GraphicsDevice graphics)
        {
            int viewportWidth = graphics.Viewport.Width;
            int viewportHeight = graphics.Viewport.Height;

            Matrix transform = Matrix.CreateTranslation(-viewportWidth / 2f, -viewportHeight / 2f, 0);
            transform *= Matrix.CreateRotationZ(Rotation);
            transform *= Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            transform *= Matrix.CreateTranslation(viewportWidth / 2f, viewportHeight / 2f, 0);
            transform *= Matrix.CreateTranslation(Position.X, Position.Y, 0);

            return transform;
        }

        public void Update(GameTime gameTime)
        {
            _isPanning = InputManager.IsMiddleMouseButtonHeld();

            if (_isPanning)
                Move(GetPanning(gameTime));

            AdjustZoom(GetZooming());

            if (Settings.CAMERA_ALLOWROTATING)
                AdjustRotation();
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

        private void AdjustRotation()
        {
            if (InputManager.IsKeyHeld(Keys.N))
                Rotation += 2 * MathF.PI / 3600;
            if (InputManager.IsKeyHeld(Keys.M))
                Rotation -= 2 * MathF.PI / 3600;
        }

        private static Point GetPanning(GameTime gameTime)
        {
            Point mouseDelta = InputManager.MouseDelta();
            if (mouseDelta == Point.Zero)
                return mouseDelta;

            float totalMilliseconds = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Vector2 panningPoint = mouseDelta.ToVector2() * totalMilliseconds * Settings.CAMERA_PANNINGSPEED;

            return new Point((int)panningPoint.X, (int)panningPoint.Y);
        }

        private static float GetZooming()
        {
            if (InputManager.IsControlHeld())
                return 0;

            return InputManager.MouseWheelDelta() * Settings.CAMERA_ZOOMINGSPEED;
        }

        public override string GetDebugInfo()
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
