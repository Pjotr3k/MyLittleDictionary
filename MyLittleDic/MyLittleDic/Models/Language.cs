using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MyLittleDic.Models
{
    public class Language
    {

        public List<Language> GetLanguages()
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM languages";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();

            List<Language> langList = new List<Language>(); 

            while (dr.Read())
            {
                Language lang = new Language();

                lang.idLanguage = Convert.ToInt32(dr["idLanguage"]);
                lang.nameLanguage = dr["name"].ToString();

                langList.Add(lang);
            }

            con.databaseConnection.Close();

            return langList;

        }

        public Language GetLanguageById(int id)
        {
            con = new SqlConnection();
            con.databaseConnection.Open();
            sqlQuery = $"SELECT * FROM languages WHERE idLanguage='{id.ToString()}'";

            cmd = new MySqlCommand(sqlQuery, con.databaseConnection);

            dr = cmd.ExecuteReader();
            Language lang = new Language();


            if (dr.Read())
            {

                lang.idLanguage = Convert.ToInt32(dr["idLanguage"]);
                lang.nameLanguage = dr["name"].ToString();

            }

            con.databaseConnection.Close();

            return lang;

        }

        
        public int idLanguage { get; set; }
        public string nameLanguage { get; set; }

        SqlConnection con;
        MySqlCommand cmd;
        string sqlQuery;
        MySqlDataReader dr;


    }
}
