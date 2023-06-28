using DataAccess.Contracts.Caching;
using Newtonsoft.Json;
using StackExchange.Redis;

public class RedisCacheProvider : ICacheProvider
{
    private readonly ConnectionMultiplexer _redisConnection;

    public RedisCacheProvider(string redisConnectionString)
    {
        _redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
    }

    public T Get<T>(string key)
    {
        var db = _redisConnection.GetDatabase();
        var serializedValue = db.StringGet(key);
        return Deserialize<T>(serializedValue);
    }

    public void Set<T>(string key, T value, TimeSpan expirationTime)
    {
        var db = _redisConnection.GetDatabase();
        var serializedValue = Serialize(value);
        db.StringSet(key, serializedValue, expirationTime);
    }

    public void Remove(string key)
    {
        var db = _redisConnection.GetDatabase();
        db.KeyDelete(key);
    }

    private string Serialize<T>(T value)
    {
        // Implement your serialization logic here
        // For example, you can use JSON serialization
        return JsonConvert.SerializeObject(value);
    }

    private T Deserialize<T>(string serializedValue)
    {
        // Implement your deserialization logic here
        // For example, you can use JSON deserialization
        return JsonConvert.DeserializeObject<T>(serializedValue);
    }
}