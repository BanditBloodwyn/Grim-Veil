using Core.Patterns.Behaviours.EventBus;
using Core.Patterns.Behaviours.FiniteStateMachines;
using Framework.GameEvents;
using Globals.Enums;
using Microsoft.Xna.Framework;

namespace Managers.StateManagement;

public abstract class GameState : State<GameState, GameManager>
{
    protected virtual SceneNames? AssociatedSceneName { get; }

    protected GameState(GameManager stateMachine)
        : base(stateMachine)
    { }

    public override void OnBegin()
    {
        if (AssociatedSceneName != null)
            EventBus<ChangeActiveSceneEvent>.Raise(new ChangeActiveSceneEvent(AssociatedSceneName.Value));

        Initialize();
    }

    protected virtual void Initialize() { }

    public virtual void Update(GameTime gameTime) { }
}