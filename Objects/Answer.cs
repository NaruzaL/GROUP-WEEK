using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Answer
  {
    private string _name;
    private string _type;
    private int _id;

    public Answer(string Name, string Type, int Id = 0)
    {
      _name = Name;
      _type = Type;
      _id = Id;
    }

    public string GetAnswerName()
    {
      return _name;
    }
    public string GetAnswerType()
    {
      return _type;
    }
    public int GetId()
    {
      return _id;
    }


    public override bool Equals(System.Object otherAnswer)
    {
      if (!(otherAnswer is Answer))
      {
        return false;
      }
      else
      {
        Answer newAnswer = (Answer) otherAnswer;
        bool idEquality = (this.GetId() == newAnswer.GetId());
        bool nameEquality = (this.GetAnswerName() == newAnswer.GetAnswerName());
        bool typeEqulity = (this.GetAnswerType() == newAnswer.GetAnswerType());
        return (idEquality && nameEquality && typeEqulity);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM answers;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


    public static List<Answer> GetAll()
    {
      List<Answer> allAnswers = new List<Answer>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM answers;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int answerId = rdr.GetInt32(0);
        string answerName = rdr.GetString(1);
        string answerType = rdr.GetString(2);
        Answer newAnswer = new Answer(answerName, answerType, answerId);
        allAnswers.Add(newAnswer);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allAnswers;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO answers (answer, type) OUTPUT INSERTED.id VALUES (@AnswerName, @AnswerType)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@AnswerName";
      nameParameter.Value = this.GetAnswerName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@AnswerType";
      typeParameter.Value = this.GetAnswerType();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(typeParameter);

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


    public static Answer Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM answers WHERE id = @AnswerId", conn);
      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = id.ToString();
      cmd.Parameters.Add(answerIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundAnswerId = 0;
      string foundAnswerName = null;
      string foundAnswerType = null;

      while(rdr.Read())
      {
        foundAnswerId = rdr.GetInt32(0);
        foundAnswerName = rdr.GetString(1);
        foundAnswerType = rdr.GetString(2);
      }
      Answer foundAnswer = new Answer(foundAnswerName, foundAnswerType, foundAnswerId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundAnswer;
    }


    // public List<Answer> GetAnswers()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT answers.* FROM shadows JOIN shadows_answers ON (shadows.id = shadows_answers.shadows_id) JOIN answers ON (shadows_answers.answer_id = answers.id) WHERE shadows.id = @AnswerId;", conn);
    //   SqlParameter shadowIdParameter = new SqlParameter();
    //   shadowIdParameter.ParameterName = "@AnswerId";
    //   shadowIdParameter.Value = this.GetId();
    //
    //   cmd.Parameters.Add(shadowIdParameter);
    //
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   List<Answer> answers = new List<Answer> {};
    //
    //   while(rdr.Read())
    //     {
    //       int AnswerId = rdr.GetInt32(0);
    //       string answerAnswer = rdr.GetString(1);
    //       string answerType = rdr.GetString(2);
    //       Answer foundAnswer = new Answer(answerName, answerType, AnswerId);
    //       answers.Add(foundAnswer);
    //     }
    //     if (rdr != null)
    //     {
    //       rdr.Close();
    //     }
    //
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return answers;
    // }

  }
}
