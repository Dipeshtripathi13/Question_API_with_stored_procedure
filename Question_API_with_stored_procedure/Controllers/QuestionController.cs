using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_API_with_stored_procedure.Model;
using System.Collections.Generic;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace Question_API_with_stored_procedure.Controllers
{
    [ApiController] //this attribute is used to indicate that the controller will handle Http requests
    [Route("[controller]")]// specifies the base URL path for the controller
    public class QuestionController : ControllerBase
    {
        db drop = new db();
        string msg = string.Empty;
        // GET: QuestionController
        [HttpGet]
        public List<Question_Ent> GetAll()
        {
            Question_Ent qsn = new Question_Ent();
            qsn.Action = "get";
            DataSet ds = drop.QuestionGet(qsn, out msg);
            List<Question_Ent> list = new List<Question_Ent>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Question_Ent
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Question = dr["Question"].ToString(),
                    Option1 = dr["Option1"].ToString(),
                    Option2 = dr["Option2"].ToString(),
                    Option3 = dr["Option3"].ToString(),
                    Option4 = dr["Option4"].ToString(),
                    Answer = dr["Answer"].ToString()
                });
            }
            return list;
        }


        [HttpGet("random")]
        public List<Question_Ent> GetRandomQuestions()
        {
            Question_Ent qsn = new Question_Ent();
            qsn.Action = "get";
            DataSet ds = drop.QuestionGet(qsn, out msg);
            List<Question_Ent> list = new List<Question_Ent>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Question_Ent
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Question = dr["Question"].ToString(),
                    Option1 = dr["Option1"].ToString(),
                    Option2 = dr["Option2"].ToString(),
                    Option3 = dr["Option3"].ToString(),
                    Option4 = dr["Option4"].ToString(),
                    Answer = dr["Answer"].ToString()
                });
            }

            // Shuffle the list of questions
            Random random = new Random();
            list = list.OrderBy(q => random.Next()).ToList();

            // Get the first 5 questions (randomly shuffled)
            List<Question_Ent> randomQuestions = list.Take(5).ToList();
            return randomQuestions;
        }
        






        // GET: QuestionController/Details/5
                [HttpGet("{Id}")]
        public List<Question_Ent> GetById(int Id)
    {
        Question_Ent qsn = new Question_Ent();
        qsn.Id = Id;
        qsn.Action = "getid";
        DataSet ds = drop.QuestionGet(qsn, out msg);
        List<Question_Ent> list = new List<Question_Ent>();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            list.Add(new Question_Ent
            {
                Id = Convert.ToInt32(dr["Id"]),
                Question = dr["Question"].ToString(),
                Option1 = dr["Option1"].ToString(),
                Option2 = dr["Option2"].ToString(),
                Option3 = dr["Option3"].ToString(),
                Option4 = dr["Option4"].ToString(),
                Answer = dr["Answer"].ToString()
            });
        }
        return list;
    }



    // POST: QuestionController
        [HttpPost]
        
        public string Post([FromBody] Question_Ent qsn)
        {
            qsn.Action = "insert";
            string msg = string.Empty;
            try
            {
                msg = drop.QuestionOpt(qsn);
            }
            catch (Exception ex)
            {
                // msg = ex.Message;
                msg = $"Error occurred while executing the stored procedure: {ex.Message}";

            }
            return msg;
        }

      

        // put: QuestionController/Edit/5
        [HttpPut("{Id}")]

        public string Put(int Id, [FromBody] Question_Ent qsn)
        {
            string msg = string.Empty;
            try
            {
                msg = drop.QuestionOpt(qsn);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        //delete: QuestionController/Delete/5
        [HttpDelete("{Id}")]
        public string Delete(int Id)
        {
            string msg = string.Empty;
            try
            {
                Question_Ent qsn = new Question_Ent();
                qsn.Id = Id;
                qsn.Action = "delete";
                msg = drop.QuestionOpt(qsn);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        
    }
}
