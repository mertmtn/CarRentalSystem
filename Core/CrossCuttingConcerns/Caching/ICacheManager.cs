namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        object Get(string key);
        T Get<T>(string key);

        //Bunu cacheden mi veri tabanından mı getirilsin?Cachede var mı kontrolü
        bool IsAdd(string key);
        void Remove(string key);
        //Regex pattern parametre alacak
        void RemoveByPattern(string pattern);
    }
}
