using Core.Game;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pools;
using System.Collections.Generic;
using IDrawable = Core.Game.IDrawable;

namespace GrimVeil.GameManagement;

public abstract class GameState : State<GameState, GameManager>
{
    protected ObjectPool ObjectPool { get; }
    protected ContentManager Content { get; }

    protected GameState(GameManager stateMachine, ContentManager content)
        : base(stateMachine)
    {
        ObjectPool = new ObjectPool();
        Content = content;
    }

    public override void OnBegin()
    {
        OnLoadContent();
        OnInitialize();
    }

    protected virtual void OnLoadContent() { }
    protected virtual void OnInitialize() { }

    public virtual void Update(GameTime gameTime)
    {
        foreach (KeyValuePair<object, IUpdatable> drawable in ObjectPool.Updateables)
            drawable.Value.Update(gameTime);
    }

    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (!ObjectPool.IsEmpty)
        {
            foreach (KeyValuePair<object, IDrawable> drawable in ObjectPool.Drawables)
                drawable.Value.Draw(spriteBatch, gameTime);
            return;
        }

        spriteBatch.DrawString(ContentPool.Fonts["Default"], "State:", new Vector2(3, 3), Color.White);
        spriteBatch.DrawString(ContentPool.Fonts["Default"], $"{GetType()}", new Vector2(100, 3), Color.White);

        spriteBatch.DrawString(ContentPool.Fonts["Default"], "Gametime:", new Vector2(3, 23), Color.White);
        spriteBatch.DrawString(ContentPool.Fonts["Default"], $"{gameTime.TotalGameTime.TotalSeconds:N1} sec, {gameTime.ElapsedGameTime.Milliseconds} ms", new Vector2(100, 23), Color.White);
    }

    protected void AddObject(object key, object @object) => ObjectPool.AddObject(key, @object);
    protected void RemoveObject(object key) => ObjectPool.RemoveObject(key);
}