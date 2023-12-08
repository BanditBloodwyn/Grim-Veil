using System.Text;

namespace Managers.SceneManagement;

public static class SceneMethods
{
    public static string GetDebugInfo(this Scene scene)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Scene Info:");

        sb.Append("Name:");
        sb.AppendLine();
        if (scene.Name != null) 
            sb.Append('\t').Append(scene.Name);

        return sb.ToString();
    }
}