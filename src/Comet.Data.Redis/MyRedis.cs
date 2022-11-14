using StackExchange.Redis;

namespace Comet.Data.Redis
{
    public class MyRedis
    {
        private ConnectionMultiplexer _conn;
        private IDatabase _database;
        public MyRedis(string server)
        {
            _conn = ConnectionMultiplexer.Connect(server);
            _database = _conn.GetDatabase();
        }
        public void AddString(string key, string value)
        {
            //set value in redis server  
            _database.StringSet(key, value);
        }
        public string GetString(string key)
        {
            //get value from redis server  
            var value = _database.StringGet(key);
            Console.WriteLine("Value cached in redis server is: " + value);
            Console.ReadLine();
            return value;
        }
        public void AddList(string key, string value)
        {
            //set value in redis server  
            _database.ListLeftPush(key, value);
        }
        public string PopListItems(string key)
        {
            return _database.ListLeftPop(key).ToString();
        }

    }
}