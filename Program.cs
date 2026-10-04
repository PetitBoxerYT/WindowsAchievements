using System.ServiceProcess;

namespace Achievements.Service
{
    internal static class Program
    {
        static void Main()
        {
            ServiceBase.Run(new AchievementService());
        }
    }
}
