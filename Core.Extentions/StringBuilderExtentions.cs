using System.Text;

namespace GV.TypeExtentions;

public static class StringBuilderExtentions
{
    public static StringBuilder AppendSpaceTab(this StringBuilder sb)
    {
        return sb.Append("       ");
    }
}