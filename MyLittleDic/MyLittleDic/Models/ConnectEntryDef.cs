using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
    public class ConnectEntryDef
    {
        public void ConnectEntryMeaning(int definition, int entry)
        {
            con = new SqlConnection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            con.databaseConnection.Open();
            sqlQuery = $"INSERT INTO entry_def_connect (idEntry, idDef) VALUES ({entry}, {definition}); ";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);
            adp.InsertCommand = cmd;
            
                adp.InsertCommand.ExecuteNonQuery();
            
            

            con.databaseConnection.Close();
        }

        /*bool IsConnected(int definition, int entry)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM definitions WHERE descr='" + descr + "'";


            cmd = new ConnectEntryDef(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<ConnectEntryDef> defList = CedList List<ConnectEntryDef>();

            while (dr.Read())
            {
                ConnectEntryDef ced = new ConnectEntryDef();

                ced.idDef = Convert.ToInt32(dr["idDef"]);
                ced.idEntry = Convert.ToInt32(dr["idDef"]);

                //def.idPrimeEntry = Convert.ToInt32(dr["primeEntryId"]);

                defList.Add(def);
            }

            /*if(defList.Count == 0)
            {
                AddDefinition(descr);
                defList = GetDefinitionByDescr(descr);
            

            con.databaseConnection.Close();

            return defList;
        }*/

        public int idDef { get; set; }
        public int idEntry { get; set; }
       

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;
    }
}
