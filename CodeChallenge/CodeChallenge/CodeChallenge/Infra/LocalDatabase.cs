using Realms;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Infra
{
    public class LocalDatabase
    {

        private static Realm _realmDatabase;
        public static Realm RealmDatabase
        {
            get
            {
                if (_realmDatabase == null)
                {
                    _realmDatabase = Realm.GetInstance();
                    return _realmDatabase;
                }
                else
                {
                    return _realmDatabase;
                }
            }
        }

        public static void Delete<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Remove(obj);
            });
        }

        public static void Edit<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Add(obj, true);
            });
        }

        public static List<T> Get<T>() where T : RealmObject, new()
        {
            return RealmDatabase.All<T>().ToList();
        }

        public static void Save<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Add(obj);
            });
        }
    }
}
