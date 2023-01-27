using Microsoft.Data.Sqlite;
using Vocabulary_Telegram_Helper.Repository;
using Newtonsoft.Json;

DBRepository.DbConnect(new SqliteConnectionStringBuilder() { Mode = SqliteOpenMode.ReadWriteCreate, DataSource = "Vocabulary.db" }.ToString());
ListenerTelegramBot.Start("5579409979:AAE21jKujk0qlnBEahzxEHBliyg62TGea_k", JsonConvert.DeserializeObject<List<long>>(File.ReadAllText("appsettings.txt")));
Console.ReadLine();