using System.Diagnostics;
using Managers.InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Managers.StateManagement.Program.States;

public class InGameState : GameState
{

    public override string StateLogString => "In Game";

    public InGameState(GameManager stateMachine, ContentManager content)
        : base(stateMachine, content)
    { }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.IsKeyPressed(Keys.Escape))
            stateMachine.OnExitGame();

        if (InputManager.IsKeyPressed(Keys.Space))
            Debug.WriteLine("Space");
    }
}