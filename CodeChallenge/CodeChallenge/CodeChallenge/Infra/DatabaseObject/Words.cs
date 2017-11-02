using Realms;

namespace CodeChallenge.Infra.DatabaseObject
{
    public class Words : RealmObject
    {
        [PrimaryKey]
        public string Word { get; set; }
        public KeywordGame KeywordGame { get; set; }
    }
}
