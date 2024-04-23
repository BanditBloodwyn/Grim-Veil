using GV.SceneManagement.Scenes;

namespace GV.SceneManagement;

public class SceneFactory
{
    // used via reflection
    // ReSharper disable once UnusedMember.Global
    public static Scene BuildByType<T>()
        where T : Scene
    {
        Type type = typeof(T);

        Scene? scene = (Scene?)Activator.CreateInstance(type);

        if (scene == null)
            throw new Exception($"Failed to create Scene of type {type}");

        scene.LoadResources();
        scene.Build();
        return scene;
    }
}