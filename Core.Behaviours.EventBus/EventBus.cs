namespace Core.Patterns.Behaviours.EventBus;

public static class EventBus<T>
    where T : IEvent
{
    private static readonly HashSet<IEventBinding<T>> _bindings = new();

    public static void Register(EventBinding<T> binding) => _bindings.Add(binding);
    public static void Unregister(EventBinding<T> binding) => _bindings.Remove(binding);

    public static void Raise(T @event)
    {
        foreach (IEventBinding<T> binding in _bindings)
        {
            binding.OnEvent.Invoke(@event);
            binding.OnEventNoArgs.Invoke();
        }
    }
}