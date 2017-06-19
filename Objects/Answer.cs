using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Answer
  {
    private string _name;
    private string _type;
    private int _questionId;
    private int _id;

    public Answer(string Name, string Type, int QuestionId, int Id = 0)
    {
      _name = Name;
      _type = Type;
      _questionId = QuestionId;
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
    public int GetQuestionId()
    {
      return _questionId;
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
        bool questionIdEquality = (this.GetQuestionId() == newAnswer.GetQuestionId());
        return (idEquality && nameEquality && typeEqulity && questionIdEquality);
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
        int answerQuestionId = rdr.GetInt32(3);
        Answer newAnswer = new Answer(answerName, answerType, answerQuestionId, answerId);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO answers (answer, type, question_id) OUTPUT INSERTED.id VALUES (@AnswerName, @AnswerType, @AnswerQuestionId)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@AnswerName";
      nameParameter.Value = this.GetAnswerName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@AnswerType";
      typeParameter.Value = this.GetAnswerType();

      SqlParameter questionIdParameter = new SqlParameter();
      questionIdParameter.ParameterName = "@AnswerQuestionId";
      questionIdParameter.Value = this.GetQuestionId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(typeParameter);
      cmd.Parameters.Add(questionIdParameter);

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
      int foundQuestionId = 0;

      while(rdr.Read())
      {
        foundAnswerId = rdr.GetInt32(0);
        foundAnswerName = rdr.GetString(1);
        foundAnswerType = rdr.GetString(2);
        foundQuestionId = rdr.GetInt32(3);
      }
      Answer foundAnswer = new Answer(foundAnswerName, foundAnswerType, foundQuestionId, foundAnswerId);

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


    public void AddShadow(Shadow newShadow)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO shadows_answers (shadow_id, answer_id) VALUES (@AnswerId, @ShadowId);", conn);
      SqlParameter shadowIdParameter = new SqlParameter();
      shadowIdParameter.ParameterName = "@ShadowId";
      shadowIdParameter.Value = this.GetId();
      cmd.Parameters.Add(shadowIdParameter);

      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = newShadow.GetId();
      cmd.Parameters.Add(answerIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Shadow> GetShadows()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT shadows.* FROM answers JOIN shadows_answers ON (answers.id = shadows_answers.answer_id) JOIN shadows ON (shadows_answers.shadow_id = shadows.id) WHERE answers.id = @AnswerId;", conn);
      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = this.GetId();

      cmd.Parameters.Add(answerIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Shadow> shadows = new List<Shadow> {};

      while(rdr.Read())
        {
          int shadowId = rdr.GetInt32(0);
          string shadowName = rdr.GetString(1);
          string shadowType = rdr.GetString(2);
          string shadowIntro = rdr.GetString(3);
          string shadowImg = rdr.GetString(4);
          Shadow foundShadow = new Shadow(shadowName, shadowType, shadowIntro, shadowImg, shadowId);
          shadows.Add(foundShadow);
        }
        if (rdr != null)
        {
          rdr.Close();
        }

      if (conn != null)
      {
        conn.Close();
      }
      return shadows;
    }

  }
}
