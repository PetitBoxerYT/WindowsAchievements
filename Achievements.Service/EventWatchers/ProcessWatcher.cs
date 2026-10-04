using System.Diagnostics;

public class ProcessWatcher
{
    public ProcessWatcher(string processName, Action<string> callback)
    {
        Task.Run(async () =>
        {
            while (true)
            {
                var found = Process.GetProcessesByName(processName).Length > 0;
                if (found)
                    callback($"process:{processName}");

                await Task.Delay(1000);
            }
        });
    }
}
