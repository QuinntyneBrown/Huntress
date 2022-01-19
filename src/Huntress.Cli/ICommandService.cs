namespace Huntress.Cli
{
    public interface ICommandService
    {
        void Start(string command, string workingDirectory = null, bool waitForExit = true);
    }
}
