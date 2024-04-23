using GV.FiniteStateMachines;
using Microsoft.Xna.Framework;

namespace GV.StateManagement;

public abstract class GameState(GameManager stateMachine) : State<GameState, GameManager>(stateMachine)
{
    public override void OnBegin()
    {
        Initialize();
    }

    protected virtual void Initialize() { }

    public virtual void Update(GameTime gameTime) { }
}