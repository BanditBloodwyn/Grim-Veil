using Managers.InputManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Managers.StateManagement.Program.States;

public class InGameState : GameState
{
    public override string StateLogString => "In Game";
    protected override string AssociatedSceneName => "inGameScene";

    public InGameState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.IsKeyPressed(Keys.Escape))
            stateMachine.OnExitGame();

        if (InputManager.IsKeyPressed(Keys.Space))
            Debug.WriteLine("Space");
    }
}