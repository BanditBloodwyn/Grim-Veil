namespace Debugging
{
    public abstract class DebuggableSingleton<T> : IDebugInfoProvider
        where T : class
    {
        private static readonly Lazy<T> _instance = new(CreateInstanceOfT);

        public static T Instance => _instance.Value;

        public bool IsDebugActive
        {
            get => true;
            set { }
        }
     
        protected DebuggableSingleton()
        {
            DebugConsole.AddObject(this);
        }
     
        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T
                   ?? throw new ArgumentNullException($"Cannot create instance of type {typeof(T).Name}");
        }

        public abstract string GetDebugInfo();
    }
}
