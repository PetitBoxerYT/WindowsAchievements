using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Achievements.Service
{
    public class AchievementManager
    {
        private List<Achievement> achievements;
        private NamedPipeSender pipe;

        public void Start()
        {
            achievements = LoadAchievements();
            pipe = new NamedPipeSender("WindowsAchievementsPipe");

            // watchers
            new ProcessWatcher("notepad.exe", OnEvent);
            new KeyboardWatcher(Keys.C, ctrlRequired: true, OnEvent);
        }

        public void Stop() { }

        private void OnEvent(string eventId)
        {
            foreach (var a in achievements)
            {
                if (a.Event == eventId)
                {
                    a.Current++;
                    if (a.Current >= a.Target)
                    {
                        pipe.Send($"UNLOCK:{a.Id}");
                    }
                }
            }

            SaveAchievements();
        }

        private List<Achievement> LoadAchievements()
        {
            return JsonSerializer.Deserialize<List<Achievement>>(
                File.ReadAllText("Achievements.json"));
        }

        private void SaveAchievements()
        {
            File.WriteAllText("Achievements.json",
                JsonSerializer.Serialize(achievements));
        }
    }
}
