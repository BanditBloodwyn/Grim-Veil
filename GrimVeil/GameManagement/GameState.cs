using Core.Patterns.Behaviours.FiniteStateMachines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;

namespace GrimVeil.GameManagement;

public abstract class GameState : State<GameState>
{
    protected ObjectPool ObjectPool { get; }

    protected GameState(StateMachine<GameState> stateMachine)
        : base(stateMachine)
    {
        ObjectPool = new ObjectPool();
    }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}