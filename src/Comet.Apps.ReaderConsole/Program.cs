using Comet.Data.Redis;
using Comet.Data.Sqlite;

namespace Comet.Apps.ReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-HQ0GDK3\\SQLEXPRESS; Initial Catalog=CometRSMTestDB; Integrated Security=True;";
            CometRSMSqlLiteContext context = new CometRSMSqlLiteContext(connectionString);
            var myRedis = new MyRedis("localhost");
            myRedis.AddList("Key1", "Testing1");
            myRedis.AddList("Key1", "Testing2");
            myRedis.AddList("Key1", "Testing3");
            myRedis.AddList("Key1", "Testing4");
            string ListItem = myRedis.PopListItems("Key1");
            Console.WriteLine("Value cached in redis server is: " + ListItem);

            //Console.ReadLine();
        }
    }
}
