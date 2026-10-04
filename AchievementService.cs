using System.ServiceProcess;

namespace Achievements.Service
{
    public class AchievementService : ServiceBase
    {
        private AchievementManager manager;

        public AchievementService()
        {
            ServiceName = "WindowsAchievementsService";
        }

        protected override void OnStart(string[] args)
        {
            manager = new AchievementManager();
            manager.Start();
        }

        protected override void OnStop()
        {
            manager.Stop();
        }
    }
}
