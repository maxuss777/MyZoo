﻿using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;
using MyZoo.Common.Animal.Interfaces.Data_Access_Layer_Interfaces;
using MyZoo.Common.ZooItems.Species;



namespace MyZoo.DataAccess.Core
{
    public class AnimalsRepository : Repository, IAnimalsRepository
    {
        public void Insert(IAnimals animal)
        {
            const string sql =
                "INSERT INTO Animals(specie, kind) Values(@specie, @kind)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@specie", animal.Specie);
                    command.Parameters.AddWithValue("@kind", animal.Kind);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<IAnimals> GetAllAnimal()
        {
            const string sql = "SELECT * FROM Animals";

            var animalsList = new List<IAnimals>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch (reader["specie"].ToString())
                            {
                                case "mammal":
                                    animalsList.Add(new Mammals(reader["specie"].ToString(), reader["kind"].ToString()));
                                    break;
                                case "bird":
                                    animalsList.Add(new Birds(reader["specie"].ToString(), reader["kind"].ToString()));
                                    break;
                                case "reptile":
                                    animalsList.Add(new Reptiles(reader["specie"].ToString(), reader["kind"].ToString()));
                                    break;
                            }
                        }
                    }
                }
            }

            return animalsList;
        }

        public IAnimals GetLastCreatedAnimal()
        {
            const string sql = "SELECT TOP 1 * FROM Animals ORDER BY id DESC";

            IAnimals animal = null;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            switch (reader["specie"].ToString())
                            {
                                case "mammal":
                                    animal = new Mammals(reader["specie"].ToString(), reader["kind"].ToString());
                                    break;
                                case "bird":
                                    animal = new Birds(reader["specie"].ToString(), reader["kind"].ToString());
                                    break;
                                case "reptile":
                                    animal = new Reptiles(reader["specie"].ToString(), reader["kind"].ToString());
                                    break;
                            }
                        }
                    }
                }
            }

            return animal;
        }
    }
}