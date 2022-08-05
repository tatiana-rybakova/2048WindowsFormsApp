
using Newtonsoft.Json;

namespace _2048ClassLibrary
{
    public class UserRepository
    {
        public static string Path = "results.json";
        public static string PathForBest = "bestresult.json";
        public static void SaveResults(User user)
        {
            var users = GetAll();
            users.Add(user);
            Save(users);

        }
        public static List<User> GetAll()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }

            var allResults = FileProvider.Get(Path);
            var results = JsonConvert.DeserializeObject<List<User>>(allResults);
            return results;
        }

        public static void Save(List<User> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }

        public static User GetBest()
        {
            if (!FileProvider.Exists(Path))
            {
                return new User("");
            }            
            var bestResult = JsonConvert.DeserializeObject<User>(FileProvider.Get(PathForBest));
            return bestResult;
        }

        public static void SaveBestResult(User user)
        {
            var bestUser = GetBest();
            if(bestUser.Name == "")
            {
                bestUser.Score = 0;
            }
            if (user.Score > bestUser.Score)
            {
                SaveBest(user);
            }
        }

        public static void SaveBest(User user)
        {
            var jsonData = JsonConvert.SerializeObject(user, Formatting.Indented);
            FileProvider.Replace(PathForBest, jsonData);
        }
    }
}
