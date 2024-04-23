using GV.EventBus;
using GV.FiniteStateMachines;
using GV.GameEvents;
using GV.SceneManagement.Data;
using GV.StateManagement.Data;
using Microsoft.Xna.Framework;

namespace GV.StateManagement;

public abstract class GameState(GameManager stateMachine) : State<GameState, GameManager>(stateMachine)
{
    protected abstract StateNames StateName { get; }
    protected virtual SceneNames? AssociatedSceneName { get; }

    public override void OnBegin()
    {
        if (AssociatedSceneName != null)
            EventBus<ChangeActiveSceneEvent>.Raise(new ChangeActiveSceneEvent(AssociatedSceneName.Value));

        Initialize();
    }

    protected virtual void Initialize() { }

    public virtual void Update(GameTime gameTime) { }
}