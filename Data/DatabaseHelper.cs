using System.IO;
using Microsoft.Data.Sqlite;

namespace PetCarePro.Data
{
    public static class DatabaseHelper
    {
        private const string ConnectionString =
            "Data Source=Database/petcarepro.db";

        public static void InitializeDatabase()
        {
            Directory.CreateDirectory("Database");

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Eigenaar (
                EigenaarID INTEGER PRIMARY KEY AUTOINCREMENT,
                Naam TEXT NOT NULL,
                Adres TEXT,
                Telefoon TEXT,
                Email TEXT
            );

            CREATE TABLE IF NOT EXISTS Dier (
                DierID INTEGER PRIMARY KEY AUTOINCREMENT,
                Naam TEXT NOT NULL,
                Soort TEXT,
                Ras TEXT,
                Leeftijd INTEGER,
                Chipnummer TEXT,
                EigenaarID INTEGER,
                FOREIGN KEY(EigenaarID) REFERENCES Eigenaar(EigenaarID)
            );

            CREATE TABLE IF NOT EXISTS Verblijf (
                VerblijfID INTEGER PRIMARY KEY AUTOINCREMENT,
                DierID INTEGER,
                IncheckDatum TEXT,
                UitcheckDatum TEXT,
                FOREIGN KEY(DierID) REFERENCES Dier(DierID)
            );
            ";

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
    }
}