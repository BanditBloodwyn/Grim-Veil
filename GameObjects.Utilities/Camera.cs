using Core.Extentions;
using Core.Patterns.Creators.Singletons;
using Framework.Game;
using Managers.InputManagement;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Text;

namespace GameObjects.Utilities
{
    public class Camera : Singleton<Camera>, IUpdatable
    {
        private bool _isPanning;

        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Zoom { get; set; } = 1.0f;
        public float Rotation { get; set; } = 0.0f;

        public float PanningSpeed { get; set; } = -0.02f;


        public Matrix GetTransformation()
        {
            return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }

        public void Move(Vector2 amount)
        {
            Debug.WriteLine($"Move camera: {amount}");
            Position += amount;
        }

        public void AdjustZoom(float amount)
        {
            Zoom += amount;

            if (Zoom < 0.1f)
                Zoom = 0.1f;
        }

        public void Update(GameTime gameTime)
        {
            _isPanning = InputManager.IsMiddleMouseButtonHeld();

            if (_isPanning)
                Move(GetPanning(gameTime));

            AdjustZoom(GetZooming());
        }

        private Vector2 GetPanning(GameTime gameTime)
        {
            float totalMilliseconds = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            return InputManager.MouseDelta() * totalMilliseconds * PanningSpeed;
        }

        private float GetZooming()
        {
            return 0;
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
