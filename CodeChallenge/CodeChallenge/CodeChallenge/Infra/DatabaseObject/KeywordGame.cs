using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Infra.DatabaseObject
{
    public class KeywordGame : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        [Backlink(nameof(Words.KeywordGame))]
        public IQueryable<Words> Keywords { get; }
    }
}
