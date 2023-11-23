using Core.Game;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System.Collections.Generic;
using IDrawable = Core.Game.IDrawable;

namespace GrimVeil.GameManagement;

public abstract class GameState : State<GameState>
{
    protected ObjectPool ObjectPool { get; }

    protected GameState(StateMachine<GameState> stateMachine)
        : base(stateMachine)
    {
        ObjectPool = new ObjectPool();
    }

    public override void OnBegin()
    {
        OnLoadContent();
        OnInitialize();
    }

    protected abstract void OnLoadContent();
    protected abstract void OnInitialize();

    public virtual void Update(GameTime gameTime)
    {
        foreach (KeyValuePair<object, IUpdatable> drawable in ObjectPool.Updateables)
            drawable.Value.Update(gameTime);
    }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        foreach (KeyValuePair<object, IDrawable> drawable in ObjectPool.Drawables)
            drawable.Value.Draw(spriteBatch, gameTime);
    }

    protected void AddObject(object key, object @object) => ObjectPool.AddObject(key, @object);
    protected void RemoveObject(object key) => ObjectPool.RemoveObject(key);
}