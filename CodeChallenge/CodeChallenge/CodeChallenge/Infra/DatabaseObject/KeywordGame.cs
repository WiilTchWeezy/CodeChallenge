using Realms;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Infra.DatabaseObject
{
    public class KeywordGame : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public IList<string> KeywordsFinded { get; set; }
        public IList<string> Keywords { get; set; }
    }
}
