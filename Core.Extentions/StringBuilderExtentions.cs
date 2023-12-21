using System.Text;

namespace Core.Extentions
{
    public static class StringBuilderExtentions
    {
        public static StringBuilder AppendSpaceTab(this StringBuilder sb)
        {
            return sb.Append("       ");
        }
    }
}
