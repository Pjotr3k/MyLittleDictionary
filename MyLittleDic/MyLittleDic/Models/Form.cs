using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
    public class Form
    {
        public List<Form> GetForms()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM forms";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Form> formList = new List<Form>();

            while (dr.Read())
            {
                Form form = new Form();

                form.idForm = Convert.ToInt32(dr["idForm"]);
                form.idLanguage = Convert.ToInt32(dr["idLanguage"]);
                form.idPos = Convert.ToInt32(dr["idPos"]);
                form.isLemma = Convert.ToBoolean(dr["isLemma"]);
                form.nameForm = dr["name"].ToString();

                formList.Add(form);
            }

            con.databaseConnection.Close();

            return formList;

        }

        public List<Form> GetPosFormsByLang(int idLang, int idPos, bool onlyLemma = false)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM forms WHERE idLanguage='{idLang}' AND idPos='{idPos}'";
            if (onlyLemma) sqlQuery += " AND isLemma=1";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Form> formList = new List<Form>();

            while (dr.Read())
            {
                Form form = new Form();

                form.idForm = Convert.ToInt32(dr["idForm"]);
                form.idLanguage = Convert.ToInt32(dr["idLanguage"]);
                form.idPos = Convert.ToInt32(dr["idPos"]);
                form.isLemma = Convert.ToBoolean(dr["isLemma"]);
                form.nameForm = dr["name"].ToString();

                formList.Add(form);
            }

            con.databaseConnection.Close();

            return formList;

        }

        public void AddForm(int lang, int pos, string name)
        {
            con = new SqlConnection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            con.databaseConnection.Open();
            sqlQuery = $"INSERT INTO forms (idLanguage, idPos, name, isLemma) VALUES ({lang}, {pos}, '{name}', false); ";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);
            adp.InsertCommand = cmd;
            adp.InsertCommand.ExecuteNonQuery();

            con.databaseConnection.Close();
        }

        public int idForm { get; set; }
        public int idLanguage { get; set; }
        public int idPos { get; set; }
        public bool isLemma { get; set; }
        public string nameForm { get; set; }

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;

    }
}
