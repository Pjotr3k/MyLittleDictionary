using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
	public class Word
	{
        public List<Word> GetWords()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM words" +
                $"LEFT JOIN forms" +
                $"ON words.idForm = forms.idForm";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Word> wordList = new List<Word>();

            while (dr.Read())
            {
                Word aWord = new Word();

                aWord.idWord = Convert.ToInt32(dr["idWord"]);
                aWord.idEntry = Convert.ToInt32(dr["idEntry"]);
                aWord.idForm = Convert.ToInt32(dr["idForm"]);
                aWord.word = dr["word"].ToString();
                aWord.formName = dr["word"].ToString();

                wordList.Add(aWord);
            }

            con.databaseConnection.Close();

            return wordList;

        }

        public List<Word> GetWordsByEntry(int entry)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT words.idWord, words.idEntry, words.idForm, words.word, forms.name AS formName, forms.isLemma " +
                $"FROM (words " +
                $"LEFT JOIN forms " +
                $"ON words.idForm = forms.idForm) " +
                $"WHERE idEntry={entry}";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Word> wordList = new List<Word>();

            while (dr.Read())
            {
                Word aWord = new Word();

                aWord.idWord = Convert.ToInt32(dr["idWord"]);
                aWord.idEntry = Convert.ToInt32(dr["idEntry"]);
                aWord.idForm = Convert.ToInt32(dr["idForm"]);
                aWord.word = dr["word"].ToString();
                aWord.formName = dr["formName"].ToString();
                aWord.isLemma = Convert.ToBoolean(dr["isLemma"]);


                wordList.Add(aWord);
            }

            con.databaseConnection.Close();

            return wordList;

        }

        public void AddWord(int form, int entry, string wordText)
        {
            con = new SqlConnection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            con.databaseConnection.Open();
            sqlQuery = $"INSERT INTO words (idEntry, idForm, word) VALUES ({entry}, {form}, '{wordText}'); ";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);
            adp.InsertCommand = cmd;
            adp.InsertCommand.ExecuteNonQuery();

            con.databaseConnection.Close();
        }

        public int idWord { get; set; }
        public int idEntry { get; set; }
        public int idForm { get; set; }
        public string word { get; set; }
        public string formName { get; set; }
        public bool isLemma { get; set; }



        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;
    }
}
