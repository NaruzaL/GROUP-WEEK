using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Question
  {
    private string _name;
    private string _type;
    private int _answerId;
    private int _id;

    public Question(string Name, string Type, int AnswerId, int Id = 0)
    {
      _name = Name;
      _type = Type;
      _answerId = AnswerId;
      _id = Id;
    }

    public string GetQuestionName()
    {
      return _name;
    }
    public string GetQuestionType()
    {
      return _type;
    }
    public int GetAnswerId()
    {
      return _answerId;
    }
    public int GetId()
    {
      return _id;
    }


    public override bool Equals(System.Object otherQuestion)
    {
      if (!(otherQuestion is Question))
      {
        return false;
      }
      else
      {
        Question newQuestion = (Question) otherQuestion;
        bool idEquality = (this.GetId() == newQuestion.GetId());
        bool nameEquality = (this.GetQuestionName() == newQuestion.GetQuestionName());
        bool typeEqulity = (this.GetQuestionType() == newQuestion.GetQuestionType());
        bool answerIdEquality = (this.GetAnswerId() == newQuestion.GetAnswerId());
        return (idEquality && nameEquality && typeEqulity && answerIdEquality);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM questions;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


    public static List<Question> GetAll()
    {
      List<Question> allQuestions = new List<Question>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM questions;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int questionId = rdr.GetInt32(0);
        string questionName = rdr.GetString(1);
        string questionType = rdr.GetString(2);
        int questionAnswerId = rdr.GetInt32(3);
        Question newQuestion = new Question(questionName, questionType, questionAnswerId, questionId);
        allQuestions.Add(newQuestion);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allQuestions;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO questions (question, type, answer_id) OUTPUT INSERTED.id VALUES (@QuestionName, @QuestionType, @QuestionAnswerId)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@QuestionName";
      nameParameter.Value = this.GetQuestionName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@QuestionType";
      typeParameter.Value = this.GetQuestionType();

      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@QuestionAnswerId";
      answerIdParameter.Value = this.GetAnswerId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(typeParameter);
      cmd.Parameters.Add(answerIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }


    public static Question Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM questions WHERE id = @QuestionId", conn);
      SqlParameter questionIdParameter = new SqlParameter();
      questionIdParameter.ParameterName = "@QuestionId";
      questionIdParameter.Value = id.ToString();
      cmd.Parameters.Add(questionIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundQuestionId = 0;
      string foundQuestionName = null;
      string foundQuestionType = null;
      int foundQuestionAnswerId = 0;

      while(rdr.Read())
      {
        foundQuestionId = rdr.GetInt32(0);
        foundQuestionName = rdr.GetString(1);
        foundQuestionType = rdr.GetString(2);
        foundQuestionAnswerId = rdr.GetInt32(3);
      }
      Question foundQuestion = new Question(foundQuestionName, foundQuestionType, foundQuestionAnswerId, foundQuestionId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundQuestion;
    }

  }
}
