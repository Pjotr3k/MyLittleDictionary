using MySql.Data.MySqlClient;
using static MyLittleDic.Models.SqlConnection;

namespace MyLittleDic.Models
{
	public class PartOfSpeech
	{
        public List<PartOfSpeech> GetPartsOfSpeech()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM parts_of_speech";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<PartOfSpeech> posList = new List<PartOfSpeech>();

            while (dr.Read())
            {
                PartOfSpeech pos = new PartOfSpeech();

                pos.idPos = Convert.ToInt32(dr["idPos"]);
                pos.namePos = dr["name"].ToString();

                posList.Add(pos);
            }

            con.databaseConnection.Close();

            return posList;

        }

        public PartOfSpeech GetPartOfSpeechById(int id)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM parts_of_speech WHERE idPos='{id.ToString()}'";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            PartOfSpeech pos = new PartOfSpeech();


            if (dr.Read())
            {

                pos.idPos = Convert.ToInt32(dr["idPos"]);
                pos.namePos = dr["name"].ToString();

            }

            con.databaseConnection.Close();

            return pos;

        }

        public int idPos { get; set; }
        public string namePos { get; set; }

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;


    }

}

