using System.Text;

namespace Managers.SceneManagement;

public static class SceneMethods
{
    public static string GetDebugInfo(this Scene scene)
    {
        StringBuilder sb = new();

        sb.AppendLine("Scene Info:");

        sb.Append("Name:");
        if (scene.Name != null) 
            sb.Append("   ").Append(scene.Name);

        return sb.ToString();
    }
}