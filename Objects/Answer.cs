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
          int shadowPlayerId = rdr.GetInt32(5);
          Shadow foundShadow = new Shadow(shadowName, shadowType, shadowIntro, shadowImg, shadowPlayerId, shadowId);
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

    public void AddQuestion(Question newQuestion)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO questions_answers (question_id, answer_id) VALUES (@AnswerId, @QuestionId);", conn);
      SqlParameter questionIdParameter = new SqlParameter();
      questionIdParameter.ParameterName = "@QuestionId";
      questionIdParameter.Value = this.GetId();
      cmd.Parameters.Add(questionIdParameter);

      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = newQuestion.GetId();
      cmd.Parameters.Add(answerIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Question> GetQuestions()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT questions.* FROM answers JOIN questions_answers ON (answers.id = questions_answers.answer_id) JOIN questions ON (questions_answers.question_id = questions.id) WHERE answers.id = @AnswerId;", conn);
      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = this.GetId();

      cmd.Parameters.Add(answerIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Question> questions = new List<Question> {};

      while(rdr.Read())
        {
          int questionId = rdr.GetInt32(0);
          string questionName = rdr.GetString(1);
          string questionType = rdr.GetString(2);
          Question foundQuestion = new Question(questionName, questionType, questionId);
          questions.Add(foundQuestion);
        }
        if (rdr != null)
        {
          rdr.Close();
        }

      if (conn != null)
      {
        conn.Close();
      }
      return questions;
    }

  }
}
