using System;
using System.Collections.Generic;
using DbConnection;

namespace crud_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Read("SELECT * FROM Users");
            Console.WriteLine("First Name?");
            string fN = Console.ReadLine();
            Console.WriteLine("Last Name?");
            string lN = Console.ReadLine();
            Console.WriteLine("Fav Number?");
            string fNum = Console.ReadLine();
            Create(fN, lN, fNum);

            void Read(string query){
                var results = DbConnector.Query(query);
                foreach(var records in results){
                    foreach(var record in records){
                        Console.WriteLine(record.Key + ": " + record.Value);
                    }
                }
                Console.WriteLine("==================================");
            }

            void Create(string fName, string lName, string fNumber){
                var query = "INSERT INTO Users(FirstName, LastName, FavoriteNumber) VALUES('"+fName+"', '"+lName+"', '"+fNumber+"')";
                var results = DbConnector.Query(query);
                Read("SELECT * FROM Users");
            }
        }
    }
}
