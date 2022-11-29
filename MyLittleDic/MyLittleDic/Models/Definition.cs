using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
    public class Definition
    {
        public List<Definition> GetDefinitions()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM definitions";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Definition> defList = new List<Definition>();

            while (dr.Read())
            {
                Definition def = new Definition();

                def.idDef = Convert.ToInt32(dr["idDef"]);
                //def.idPrimeEntry = Convert.ToInt32(dr["primeEntryId"]);
                def.descr = dr["descr"].ToString();

                defList.Add(def);
            }

            con.databaseConnection.Close();

            return defList;

        }

        public List<Definition> GetDefinitionByDescr(string descr)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM definitions WHERE descr='" + descr + "'";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Definition> defList = new List<Definition>();

            while (dr.Read())
            {
                Definition def = new Definition();

                def.idDef = Convert.ToInt32(dr["idDef"]);
                //def.idPrimeEntry = Convert.ToInt32(dr["primeEntryId"]);
                def.descr = dr["descr"].ToString();

                defList.Add(def);
            }

            /*if(defList.Count == 0)
            {
                AddDefinition(descr);
                defList = GetDefinitionByDescr(descr);
            }*/

            con.databaseConnection.Close();

            return defList;

        }

        public List<Definition> GetDefinitionsByEntry(int entry)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT entry_def_connect.idEntry, definitions.idDef, definitions.descr " +
                $"FROM (entry_def_connect " +
                $"INNER JOIN definitions " +
                $"ON entry_def_connect.idDef=definitions.idDef) " +
                $"WHERE idEntry={entry}";


            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Definition> defList = new List<Definition>();

            while (dr.Read())
            {
                Definition aDef= new Definition();

                aDef.idDef = Convert.ToInt32(dr["idDef"]);
                aDef.idEntry = Convert.ToInt32(dr["idEntry"]);
                aDef.descr = dr["descr"].ToString();
                


                defList.Add(aDef);
            }

            con.databaseConnection.Close();

            return defList;

        }

        public void AddDefinition(string descr)
        {
            //this var is supposed to return id of just added entry as OUTPUT INSERTED doesn't work with mySQL:
            //int showCode = -1;

            con = new SqlConnection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            con.databaseConnection.Open();
            sqlQuery = $"INSERT INTO definitions (descr) VALUES ('{descr}'); ";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);
            adp.InsertCommand = cmd;
            adp.InsertCommand.ExecuteNonQuery();

 
        }

        public int idDef { get; set; }
        public int idEntry { get; set; }
        public string descr { get; set; }

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;

    }
}
