using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Shadow
  {
    private string _name;
    private string _type;
    private string _intro;
    private string _img;
    private int _id;

    public Shadow(string Name, string Type, string Intro, string Img, int Id = 0)
    {
      _name = Name;
      _type = Type;
      _intro = Intro;
      _img = Img;
      _id = Id;
    }

    public string GetShadowName()
    {
      return _name;
    }
    public string GetShadowType()
    {
      return _type;
    }
    public string GetIntro()
    {
      return _intro;
    }
    public string GetImg()
    {
      return _img;
    }
    public int GetId()
    {
      return _id;
    }


    public override bool Equals(System.Object otherShadow)
    {
      if (!(otherShadow is Shadow))
      {
        return false;
      }
      else
      {
        Shadow newShadow = (Shadow) otherShadow;
        bool idEquality = (this.GetId() == newShadow.GetId());
        bool nameEquality = (this.GetShadowName() == newShadow.GetShadowName());
        bool typeEqulity = (this.GetShadowType() == newShadow.GetShadowType());
        bool introEquality = (this.GetIntro() == newShadow.GetIntro());
        bool imgEquality = (this.GetImg() == newShadow.GetImg());
        return (idEquality && nameEquality && typeEqulity);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM shadows;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


    public static List<Shadow> GetAll()
    {
      List<Shadow> allShadows = new List<Shadow>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM shadows;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int shadowId = rdr.GetInt32(0);
        string shadowName = rdr.GetString(1);
        string shadowType = rdr.GetString(2);
        string shadowIntro = rdr.GetString(3);
        string shadowImg = rdr.GetString(4);
        Shadow newShadow = new Shadow(shadowName, shadowType, shadowIntro, shadowImg, shadowId);
        allShadows.Add(newShadow);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allShadows;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO shadows (name, type, intro, img) OUTPUT INSERTED.id VALUES (@ShadowName, @ShadowType, @ShadowIntro, @ShadowImg)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ShadowName";
      nameParameter.Value = this.GetShadowName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@ShadowType";
      typeParameter.Value = this.GetShadowType();

      SqlParameter introParameter = new SqlParameter();
      introParameter.ParameterName = "@ShadowIntro";
      introParameter.Value = this.GetIntro();

      SqlParameter imgParameter = new SqlParameter();
      imgParameter.ParameterName = "@ShadowImg";
      imgParameter.Value = this.GetImg();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(typeParameter);
      cmd.Parameters.Add(introParameter);
      cmd.Parameters.Add(imgParameter);

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


    public static Shadow Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM shadows WHERE id = @ShadowId", conn);
      SqlParameter shadowIdParameter = new SqlParameter();
      shadowIdParameter.ParameterName = "@ShadowId";
      shadowIdParameter.Value = id.ToString();
      cmd.Parameters.Add(shadowIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundShadowId = 0;
      string foundShadowName = null;
      string foundShadowType = null;
      string foundShadowIntro = null;
      string foundShadowImg = null;

      while(rdr.Read())
      {
        foundShadowId = rdr.GetInt32(0);
        foundShadowName = rdr.GetString(1);
        foundShadowType = rdr.GetString(2);
        foundShadowIntro = rdr.GetString(3);
        foundShadowImg = rdr.GetString(4);
      }
      Shadow foundShadow = new Shadow(foundShadowName, foundShadowType, foundShadowIntro, foundShadowImg, foundShadowId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundShadow;
    }

    public void AddAnswer(Answer newAnswer)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO shadows_answers (shadow_id, answer_id) VALUES (@AnswerId, @ShadowId);", conn);
      SqlParameter answerIdParameter = new SqlParameter();
      answerIdParameter.ParameterName = "@AnswerId";
      answerIdParameter.Value = this.GetId();
      cmd.Parameters.Add(answerIdParameter);

      SqlParameter shadowIdParameter = new SqlParameter();
      shadowIdParameter.ParameterName = "@ShadowId";
      shadowIdParameter.Value = newAnswer.GetId();
      cmd.Parameters.Add(shadowIdParameter);

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

      SqlCommand cmd = new SqlCommand("SELECT answers.* FROM shadows JOIN shadows_answers ON (shadows.id = shadows_answers.shadow_id) JOIN answers ON (shadows_answers.answer_id = answers.id) WHERE shadows.id = @ShadowId;", conn);
      SqlParameter shadowIdParameter = new SqlParameter();
      shadowIdParameter.ParameterName = "@ShadowId";
      shadowIdParameter.Value = this.GetId();

      cmd.Parameters.Add(shadowIdParameter);

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

    // public Dictionary<string,object> RandomShadow(){
    //   Dictionary<string, object> model = new Dictionary<string, object>{};
    //   List<Shadow> allShadows = Shadow.GetAll();
    //   int i = new Random().Next(1, allShadows.Count + 1 );
    //   Shadow randomShadow = allShadows[i];
    //
    //   List<Answer> shadowAnswers = randomShadow.GetAnswers();
    //
    //   int j = new Random().Next(1, shadowAnswers.Count + 1);
    //   Answer randomAnswer = shadowAnswers[j];
    //   List<Question> allRandomQuestions = randomAnswer.GetQuestions();
    //
    //   int n = new Random().Next(1, allRandomQuestions.Count);
    //   Question randomQuestion = allRandomQuestions[n];
    //
    //   List<Answer> allAnswers = Answer.GetAll();
    //   int k = new Random().Next(1, allAnswers.Count + 1);
    //   Answer answerOne = allAnswers[k];
    //   int l = new Random().Next(2, allAnswers.Count);
    //   Answer answerTwo = allAnswers[l];
    //
    //   List<Answer> displayedAnswers = new List<Answer>{};
    //   displayedAnswers.Add(randomAnswer);
    //   displayedAnswers.Add(answerOne);
    //   displayedAnswers.Add(answerTwo);
    //   model.Add("shadow", randomShadow);
    //   model.Add("answers", displayedAnswers);
    //   model.Add("quesion", randomQuestion);
    //   return model;
    // }
  }
}
