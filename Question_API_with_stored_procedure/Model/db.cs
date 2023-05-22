using System.Data.SqlClient;
using System.Data;
using System;

namespace Question_API_with_stored_procedure.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=silence;Initial Catalog=Question_storeprocedure;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string QuestionOpt(Question_Ent qsn)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("ManageQuestionEntity", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", qsn.Id);
                com.Parameters.AddWithValue("@Question", qsn.Question);
                com.Parameters.AddWithValue("@Option1", qsn.Option1);
                com.Parameters.AddWithValue("@Option2", qsn.Option2);
                com.Parameters.AddWithValue("@Option3", qsn.Option3);
                com.Parameters.AddWithValue("@Option4", qsn.Option4);
                com.Parameters.AddWithValue("@Answer", qsn.Answer);
                com.Parameters.AddWithValue("@Action", qsn.Action);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
            

        }

        //Get Record

        public DataSet QuestionGet(Question_Ent qsn, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("ManageQuestionEntity", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", qsn.Id);
                com.Parameters.AddWithValue("@Question", qsn.Question);
                com.Parameters.AddWithValue("@Option1", qsn.Option1);
                com.Parameters.AddWithValue("@Option2", qsn.Option2);
                com.Parameters.AddWithValue("@Option3", qsn.Option3);
                com.Parameters.AddWithValue("@Option4", qsn.Option4);
                com.Parameters.AddWithValue("@Answer", qsn.Answer);
                com.Parameters.AddWithValue("@Action", qsn.Action);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            
            return ds;


        }
    }
}
