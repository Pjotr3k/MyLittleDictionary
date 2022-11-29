using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
    public class Entry
    {
        public List<Entry> GetEntryById(int entryId)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT entries.idEntry, entries.idLang, entries.idPos, languages.name AS langName, parts_of_speech.name AS posName " +
                $"FROM ((entries " +
                $"INNER JOIN languages " +
                $"ON entries.idLang=languages.idLanguage) " +
                $"INNER JOIN parts_of_speech " +
                $"ON entries.idPos=parts_of_speech.idPos) " +
                $"WHERE idEntry={entryId}";

           

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Entry> entryList = new List<Entry>();

            while (dr.Read())
            {
                Entry entry = new Entry();
                Word word = new Word();
                Definition def = new Definition();

                entry.idEntry = Convert.ToInt32(dr["idEntry"]);
                entry.idLanguage = Convert.ToInt32(dr["idLang"]);
                entry.idPos = Convert.ToInt32(dr["idPos"]);
                entry.langName = dr["langName"].ToString();
                entry.posName = dr["posName"].ToString();
                entry.wordsForms = word.GetWordsByEntry(entry.idEntry);
                entry.defList = def.GetDefinitionsByEntry(entry.idEntry);
                
                foreach(Word isItLemma in entry.wordsForms)
                {
                    if (isItLemma.isLemma) entry.lemma = isItLemma;
                }
                

                entryList.Add(entry);
            }

            con.databaseConnection.Close();

            return entryList;

        }

        public List<Entry> GetEntries()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT entries.idEntry, entries.idLang, entries.idPos, languages.name AS langName, parts_of_speech.name AS posName " +
                $"FROM ((entries " +
                $"INNER JOIN languages " +
                $"ON entries.idLang=languages.idLanguage) " +
                $"INNER JOIN parts_of_speech " +
                $"ON entries.idPos=parts_of_speech.idPos)";



            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Entry> entryList = new List<Entry>();

            while (dr.Read())
            {
                Entry entry = new Entry();
                Word word = new Word();
                Definition def = new Definition();

                entry.idEntry = Convert.ToInt32(dr["idEntry"]);
                entry.idLanguage = Convert.ToInt32(dr["idLang"]);
                entry.idPos = Convert.ToInt32(dr["idPos"]);
                entry.langName = dr["langName"].ToString();
                entry.posName = dr["posName"].ToString();
                entry.wordsForms = word.GetWordsByEntry(entry.idEntry);
                entry.defList = def.GetDefinitionsByEntry(entry.idEntry);

                foreach (Word isItLemma in entry.wordsForms)
                {
                    if (isItLemma.isLemma) entry.lemma = isItLemma;
                }


                entryList.Add(entry);
            }

            con.databaseConnection.Close();

            return entryList;

        }

        public int AddEntry(int lang, int pos, string word)
        {
            //this var is supposed to return id of just added entry as OUTPUT INSERTED doesn't work with mySQL:
            int showCode = -1;

            con = new SqlConnection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            con.databaseConnection.Open();
            sqlQuery = $"INSERT INTO entries (idLang, idPos, code) VALUES ({lang}, {pos}, '{lang}.{pos}.{word}'); ";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);
            adp.InsertCommand = cmd;
            adp.InsertCommand.ExecuteNonQuery();

            sqlQuery = $"SELECT idEntry FROM entries WHERE code='" + lang + "." + pos + "." + word + "'";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                 showCode = Convert.ToInt32(dr["idEntry"]);
            }

            con.databaseConnection.Close();

            return showCode;

            //else return -1;
        }

        public int idEntry { get; set; }
        public int idLanguage { get; set; }
        public string langName { get; set; }
        public int idPos { get; set; }
        public string posName { get; set; }
        public List<Word> wordsForms = new List<Word>();
        public Word lemma = new Word();
        public List<Definition> defList = new List<Definition>();

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;

    }
}
