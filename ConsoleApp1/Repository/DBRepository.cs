using Vocabulary_Telegram_Helper.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Vocabulary_Telegram_Helper.Repository
{
    public class DBRepository
    {
        private static string dbConnectionString;

        public static void DbConnect(string connectionString)
        {
            dbConnectionString = connectionString;

            using (IDbConnection db = new SqliteConnection(dbConnectionString))
            {
                bool isHasWorkTable = db.ExecuteScalar<bool>("SELECT 1 FROM sqlite_master WHERE type='table' AND name='vocabularyTable';");
                if (!isHasWorkTable)
                {
                    db.Execute("create table vocabularyTable (id INTEGER PRIMARY KEY AUTOINCREMENT, Word text, Translation text)");
                }
            }
        }


        public static void SetItem(VocabularyModel vocabularyModel)
        {
            using (IDbConnection db = new SqliteConnection(dbConnectionString))
                db.Execute($"insert into vocabularyTable (Word, Translation) values ('{vocabularyModel.Word}', '{vocabularyModel.Translation}')");
        }

        public static List<VocabularyModel> GetAllItems()
        {
            using (IDbConnection db = new SqliteConnection(dbConnectionString))
                return db.Query<VocabularyModel>("select * from vocabularyTable").ToList();
        }

        public static void DeleteItem(int id)
        {
            using (IDbConnection db = new SqliteConnection(dbConnectionString))
                db.Execute($"delete from vocabularyTable where id = {id}");
        }
    }
}
