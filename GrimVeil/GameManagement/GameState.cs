using Core.Patterns.Behaviours.FiniteStateMachines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GrimVeil.GameManagement;

public abstract class GameState : State<GameState>
{
    protected GameState(StateMachine<GameState> stateMachine)
        : base(stateMachine)
    { }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}