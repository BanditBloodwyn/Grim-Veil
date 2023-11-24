using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace GrimVeil.GameManagement.States;

public class InGameState : GameState
{
    public override string StateLogString => "In Game";
   
    public InGameState(GameManager stateMachine, ContentManager content) 
        : base(stateMachine, content)
    { }

    public override void Update(GameTime gameTime)
    {
        if (Input.IsKeyPressed(Keys.Escape))
            stateMachine.OnExitGame();

        if (Input.IsKeyPressed(Keys.Space))
            Debug.WriteLine("Space");
    }
}