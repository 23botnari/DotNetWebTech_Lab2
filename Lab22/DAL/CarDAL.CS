using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Lab22.Models;
namespace Lab22.DAL
{
    public class CarDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CarConnection"].ConnectionString;

        public DataTable GetAllCar()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars"; // Actualizează numele tabelului
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public Car GetCarById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                Car car = null;
                if (reader.Read())
                {
                    car = new Car();
                    car.Id = Convert.ToInt32(reader["id"]);
                    car.Nume = reader["nume"].ToString();
                    car.Culoare = reader["culoare"].ToString();
                    car.AnFabricare = Convert.ToInt32(reader["an_fabricare"]);
                }

                return car;
            }
        }


        public void AddCar(string nume, string culoare, int anFabricare)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Cars (nume, culoare, an_fabricare) VALUES (@nume, @culoare, @an_fabricare)"; // Actualizează numele tabelului
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@culoare", culoare);
                cmd.Parameters.AddWithValue("@an_fabricare", anFabricare);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCar(int id, string nume, string culoare, int anFabricare)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Cars SET nume=@nume, culoare=@culoare, an_fabricare=@an_fabricare WHERE id=@id"; // Actualizează numele tabelului
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nume", nume);
                cmd.Parameters.AddWithValue("@culoare", culoare);
                cmd.Parameters.AddWithValue("@an_fabricare", anFabricare);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Cars WHERE id=@id"; // Actualizează numele tabelului
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
