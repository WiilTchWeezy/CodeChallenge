using Realms;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Infra
{
    public interface ILocalDatabase
    {
        void Save<T>(T obj) where T : RealmObject, new();
        void Edit<T>(T obj) where T : RealmObject, new();
        void Delete<T>(T obj) where T : RealmObject, new();
        List<T> Get<T>() where T : RealmObject, new();
    }
    public class LocalDatabase : ILocalDatabase
    {

        private Realm _realmDatabase;
        public Realm RealmDatabase
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

        public void Delete<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Remove(obj);
            });
        }

        public void Edit<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Add(obj, true);
            });
        }

        public List<T> Get<T>() where T : RealmObject, new()
        {
            return RealmDatabase.All<T>().ToList();
        }

        public void Save<T>(T obj) where T : RealmObject, new()
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Add(obj);
            });
        }
    }
}
