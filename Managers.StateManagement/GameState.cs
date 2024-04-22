using GV.EventBus;
using GV.FiniteStateMachines;
using GV.GameEvents;
using GV.Globals.Enums;
using Microsoft.Xna.Framework;

namespace GV.StateManagement;

public abstract class GameState : State<GameState, GameManager>
{
    protected abstract StateNames StateName { get; }
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