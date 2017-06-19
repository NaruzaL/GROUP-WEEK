using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Shadow
  {
    private string _name;
    private string _type;
    private int _id;

    public Shadow(string Name, string Type, int Id = 0)
    {
      _name = Name;
      _type = Type;
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
        Shadow newShadow = new Shadow(shadowName, shadowType, shadowId);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO shadows (name, type) OUTPUT INSERTED.id VALUES (@ShadowName, @ShadowType)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ShadowName";
      nameParameter.Value = this.GetShadowName();

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@ShadowType";
      typeParameter.Value = this.GetShadowType();

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

      while(rdr.Read())
      {
        foundShadowId = rdr.GetInt32(0);
        foundShadowName = rdr.GetString(1);
        foundShadowType = rdr.GetString(2);
      }
      Shadow foundShadow = new Shadow(foundShadowName, foundShadowType, foundShadowId);

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


    public List<Answer> GetAnswers()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT answers.* FROM shadows JOIN shadows_answers ON (shadows.id = shadows_answers.shadows_id) JOIN answers ON (shadows_answers.answer_id = answers.id) WHERE shadows.id = @ShadowId;", conn);
      SqlParameter shadowIdParameter = new SqlParameter();
      shadowIdParameter.ParameterName = "@ShadowId";
      shadowIdParameter.Value = this.GetId();

      cmd.Parameters.Add(shadowIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Answer> answers = new List<Answer> {};

      while(rdr.Read())
        {
          int AnswerId = rdr.GetInt32(0);
          string answerName = rdr.GetString(1);
          string answerType = rdr.GetString(2);
          Answer foundAnswer = new Answer(answerName, answerType, AnswerId);
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
