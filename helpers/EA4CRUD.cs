using System;
using System.Collections.Specialized;
using Amazon.Auth.AccessControlPolicy;
using cat.itb.M6UF3EA1.CRUD;
using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using UF3_test.connections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cat.itb.M6UF3EA4.helpers
{
    public static class EA4CRUD
    {
        public static void ACT1InsertFiles()
        {
            const string DB = "itb";
            CRUDMongoDB<Restaurant> crudRestaurant = new CRUDMongoDB<Restaurant>();
            crudRestaurant.ImportJSONElements(File.ReadAllText("FitxersJSON/restaurants.json").Split('\n'));

        }
        public static string ACT2AShowRestaurant()
        {

            CRUDMongoDB<Restaurant> crudRestaurant = new CRUDMongoDB<Restaurant>();
            var amountsCuissines = crudRestaurant.Select().GroupBy(element=>element.cuisine).Select(element => new
            {
                key = element.Key,
                count = element.Count()
            }).OrderByDescending(element=>element.count);
            string resultMsg = string.Empty;
            foreach(var amount in amountsCuissines)
            {
                resultMsg += $"{amount.key}: {amount.count}"+Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT2BShowRestaurant()
        {
            CRUDMongoDB<Restaurant> crudRestaurant = new CRUDMongoDB<Restaurant>();
            List<Restaurant> restaurants = crudRestaurant.Select();
            string resultMsg = string.Empty;
            foreach(Restaurant restaurant in restaurants)
            {
                resultMsg += $"{restaurant.name}: {restaurant.grades.Count()}"+Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT2CShowRestaurant()
        {
            CRUDMongoDB<Restaurant> crudRestaurant = new CRUDMongoDB<Restaurant>();
        }
    }
        
}
