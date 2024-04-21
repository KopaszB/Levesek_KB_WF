using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Levesek_KB_WF
{
    internal class Adatbazis
    {
        

        public List<Leves> Leveslista()
        {
            List<Leves> llista = new List<Leves>();

            MySqlConnection connection;
            MySqlCommand command;

            connection = new MySqlConnection("server=localhost;userid=root;password=;database=etelek");
            connection.Open();

            command = new MySqlCommand("SELECT * FROM `levesek`;",connection);
            
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    Leves a = new Leves
                    {
                        Megnevezes = dr.GetString(0),
                        Kaloria = dr.GetInt32(1),
                        Feherje = dr.GetDouble(2),
                        Zsir = dr.GetDouble(3),
                        Szenhidrat = dr.GetDouble(4),
                        Hamu = dr.GetDouble(5),
                        Rost = dr.GetDouble(6)
                    };
                    llista.Add(a);
                }
            }
            connection.Close();
            return llista;
        }

        internal int ujlevesHozzaad(Leves ujleves)
        {
            MySqlConnection connection;
            MySqlCommand command;
            
            connection = new MySqlConnection("server=localhost;userid=root;password=;database=etelek");
            connection.Open();

            command = new MySqlCommand("INSERT INTO `levesek`(`megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES (@megnevezes, @kaloria, @feherje, @zsir, @szenhidrat, @hamu, @rost);", connection);
            command.Parameters.AddWithValue("@megnevezes", ujleves.Megnevezes);
            command.Parameters.AddWithValue("@kaloria", ujleves.Kaloria);
            command.Parameters.AddWithValue("@feherje", ujleves.Feherje);
            command.Parameters.AddWithValue("@zsir", ujleves.Zsir);
            command.Parameters.AddWithValue("@szenhidrat", ujleves.Szenhidrat);
            command.Parameters.AddWithValue("@hamu", ujleves.Hamu);
            command.Parameters.AddWithValue("@rost", ujleves.Rost);

            int ujsor = command.ExecuteNonQuery();

            connection.Close();

            return ujsor;
        }
    }
}
