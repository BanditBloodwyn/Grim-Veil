namespace GV.Debugging;

public interface IDebugInfoProvider
{
    public bool IsDebugActive { get; protected set; }
    
    public string GetDebugInfo();
}