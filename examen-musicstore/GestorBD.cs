using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace examen_musicstore
{
    internal class GestorBD
    {
        //apartado 3.1
        private MySqlConnection conexion;
        public GestorBD()
        {
            MySqlConnectionStringBuilder builder = new
            MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "Hachyko2614";
            builder.Database = "";
            MySqlConnection init = new MySqlConnection(builder.ToString());
            init.Open();
            new MySqlCommand(
            "CREATE DATABASE IF NOT EXISTS musicstore;" +
            "USE musicstore;" +
            "CREATE TABLE IF NOT EXISTS album (" +
            "id INT AUTO_INCREMENT PRIMARY KEY," +
            "titulo VARCHAR(100), artista VARCHAR(100)," +
            "anyo INT, disponible BOOLEAN);", init).ExecuteNonQuery();
            init.Close();

            builder.Database = "musicstore";
            conexion = new MySqlConnection(builder.ToString());
        }

        //apartado 3.2
        public void Insertar(Album album)
        {
            conexion.Open();
            string query = "INSERT INTO album (titulo, artista, anyo, disponible) " +
                "VALUES (@titulo, @artista, @anyo, @disponible)";
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@titulo", album.Titulo);
            cmd.Parameters.AddWithValue("@artista", album.Artista);
            cmd.Parameters.AddWithValue("@anyo", album.Anyo);
            cmd.Parameters.AddWithValue("@disponible", album.Disponible);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Album agregado a la tabla.");
            conexion.Close();
        }

        //apartado 3.3
        public List<Album> obtenerTodos()
        {
            List<Album> albumes = new List<Album>();
            conexion.Open();
            String query = "SELECT * FROM album";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                albumes.Add(new Album(
                    res.GetString(1),
                    res.GetString(2),
                    res.GetInt32(3),
                    res.GetBoolean(4)
                ));
            }
            res.Close();
            conexion.Close();
            return albumes;
        }
    }
}
