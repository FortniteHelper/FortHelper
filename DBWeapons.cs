using System.Data.SQLite;
using System.Data;

namespace FortHelper
{
    class DBWeapons
    {
        static public DataSet GetWeapon()
        {
            string sConnectionString = "Data Source=Weapon.db";
            DataSet dsWeapon = new DataSet("Weapon");

            using (SQLiteConnection con = new SQLiteConnection(sConnectionString))
            {
                con.Open();
                string sQuerry = "SELECT * FROM ranged ORDER BY name";
                using (SQLiteCommand command = new SQLiteCommand(sQuerry, con))
                {
                    command.CommandType = CommandType.Text;

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                    adapter.SelectCommand = command;

                    // Fill the DataSet.
                    adapter.Fill(dsWeapon);
                }
            }

            return dsWeapon;
        }

        static public DataSet GetPerksWebsite()
        {
            string sConnectionString = "Data Source=PerksW.db";
            DataSet dsPerks = new DataSet("Weapon");

            using (SQLiteConnection con = new SQLiteConnection(sConnectionString))
            {
                con.Open();
                string sQuerry = "SELECT * FROM perks ORDER BY perkname";
                using (SQLiteCommand command = new SQLiteCommand(sQuerry, con))
                {
                    command.CommandType = CommandType.Text;

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                    adapter.SelectCommand = command;

                    // Fill the DataSet.
                    adapter.Fill(dsPerks);
                }
            }

            return dsPerks;
        }

    }
}
