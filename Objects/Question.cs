using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Question
  {
    private string _name;
    private string _type;
    private int _id;

    public Question(string Name, string Type, int Id = 0)
    {
      _name = Name;
      _type = Type;
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
        return (idEquality && nameEquality && typeEqulity);
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
        Question newQuestion = new Question(questionName, questionType, questionId);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO questions (question, type) OUTPUT INSERTED.id VALUES (@QuestionName, @QuestionType)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@QuestionName";
      nameParameter.Value = this.GetQuestionName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@QuestionType";
      typeParameter.Value = this.GetQuestionType();

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

      while(rdr.Read())
      {
        foundQuestionId = rdr.GetInt32(0);
        foundQuestionName = rdr.GetString(1);
        foundQuestionType = rdr.GetString(2);
      }
      Question foundQuestion = new Question(foundQuestionName, foundQuestionType, foundQuestionId);

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

    public void AddAnswer(Answer newAnswer)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO questions_answers (question_id, answer_id) VALUES ( @AnswerId, @QuestionId);", conn);
      SqlParameter AnswerIdParameter = new SqlParameter();
      AnswerIdParameter.ParameterName = "@AnswerId";
      AnswerIdParameter.Value = this.GetId();
      cmd.Parameters.Add(AnswerIdParameter);

      SqlParameter questionIdParameter = new SqlParameter();
      questionIdParameter.ParameterName = "@QuestionId";
      questionIdParameter.Value = newAnswer.GetId();
      cmd.Parameters.Add(questionIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Answer> GetAnswers()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT answers.* FROM questions JOIN questions_answers ON (questions.id = questions_answers.question_id) JOIN answers ON (questions_answers.answer_id = answers.id) WHERE questions.id = @QuestionId;", conn);
      SqlParameter questionIdParameter = new SqlParameter();
      questionIdParameter.ParameterName = "@QuestionId";
      questionIdParameter.Value = this.GetId();

      cmd.Parameters.Add(questionIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Answer> answers = new List<Answer> {};

      while(rdr.Read())
        {
          int answerId = rdr.GetInt32(0);
          string answerName = rdr.GetString(1);
          string answerType = rdr.GetString(2);

          Answer foundAnswer = new Answer(answerName, answerType, answerId);
          answers.Add(foundAnswer);
        }
        if (rdr != null)
        {
          rdr.Close();
        }

      if (conn != null)
      {
        conn.Close();
      }
      return answers;
    }

  }
}
