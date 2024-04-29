using cat.itb.M6UF3EA1.Helpers;
using cat.itb.M6UF3EA1.Models;
using cat.itb.M6UF3EA4.model;
using MongoDB.Bson;
using MongoDB.Driver;
using UF3_test.connections;

namespace cat.itb.M6UF3EA4.cruds
{
    public static class EA4CRUD
    {
        public static void ACT1InsertFiles()
        {
            string db = ConfigurationHelper.GetDB();
            string collection = ConfigurationHelper.GetCollection();
            IMongoCollection<BsonDocument> crudRestaurant = MongoConnection.GetDatabase(db).GetCollection<BsonDocument>(collection);
            foreach (string element in File.ReadAllText("FitxersJSON/restaurants.json").Split('\n'))
            {
                crudRestaurant.InsertOne(BsonDocument.Parse(element));
            }

        }
        public static string ACT2AShowRestaurant()
        {
            string db = ConfigurationHelper.GetDB();
            string collection = ConfigurationHelper.GetCollection();
            IMongoCollection<Restaurant> crud = MongoConnection.GetDatabase(db).GetCollection<Restaurant>(collection);

            List<Count<string>> resultQuery = crud.Aggregate().Group(
                element => element.cuisine,
                element => new Count<string>
                {
                    id = element.Key,
                    count = element.Sum(element => 1)
                }
            ).SortByDescending(element => element.count).ToList();
            string resultText = string.Empty;
            foreach (Count<string> restaurant in resultQuery)
            {
                resultText += restaurant.ToString() + Environment.NewLine;
            }
            return resultText;
        }
        public static string ACT2BShowRestaurant()
        {
            string db = ConfigurationHelper.GetDB();
            string collection = ConfigurationHelper.GetCollection();
            IMongoCollection<Restaurant> crud = MongoConnection.GetDatabase(db).GetCollection<Restaurant>(collection);

            List<Count<string>> resultQuery = crud.Aggregate().Group(
                element => element.restaurant_id,
                element => new Count<string>
                {
                    id = element.Key,
                    count = element.Sum(element => element.grades.Count())
                }
            ).ToList();
            string resultText = string.Empty;
            foreach (Count<string> restaurant in resultQuery)
            {
                resultText += restaurant.ToString() + Environment.NewLine;
            }
            return resultText;
        }
        public static string ACT2CShowRestaurant()
        {
            string db = ConfigurationHelper.GetDB();
            string collection = ConfigurationHelper.GetCollection();
            IMongoCollection<Restaurant> crud = MongoConnection.GetDatabase(db).GetCollection<Restaurant>(collection);

            List<Count<string>> resultQuery = crud.Aggregate().Group(
                element => element.restaurant_id,
                element => new Count<string>
                {
                    id = element.Key,
                    count = element.Max(element => element.grades.Max(element => element.score))
                }
            ).ToList();
            string resultText = string.Empty;
            foreach (Count<string> restaurant in resultQuery)
            {
                resultText += restaurant.ToString() + Environment.NewLine;
            }
            return resultText;
        }
        public static string ACT2DShowTypeForEachBorough()
        {
            string db = ConfigurationHelper.GetDB();
            string collection = ConfigurationHelper.GetCollection();
            IMongoCollection<Restaurant> crud = MongoConnection.GetDatabase(db).GetCollection<Restaurant>(collection);

            var resultQuery = crud.Aggregate().Group(
                element => new
                {
                    element.borough,
                    cusine = element.cuisine
                },
                element => new
                {
                    id = element.Key,
                    count = element.Sum(element => 1)
                }
            ).ToList();
            string resultText = string.Empty;
            foreach (var restaurant in resultQuery)
            {
                resultText += restaurant.ToString() + Environment.NewLine;
            }
            return resultText;
        }
    }


}
