using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonaFive.Objects
{
  public class Player
  {
    private string _name;
    private bool _chosen;
    private string _image;
    private int _id;

    public Player(string Name, bool Chosen, string Image, int Id = 0)
    {
      _name = Name;
      _chosen = Chosen;
      _image = Image;
      _id = Id;
    }

    public string GetPlayerName()
    {
      return _name;
    }
    public bool GetChosen()
    {
      return _chosen;
    }
    public string GetImage()
    {
      return _image;
    }
    public int GetId()
    {
      return _id;
    }


    public override bool Equals(System.Object otherPlayer)
    {
      if (!(otherPlayer is Player))
      {
        return false;
      }
      else
      {
        Player newPlayer = (Player) otherPlayer;
        bool idEquality = (this.GetId() == newPlayer.GetId());
        bool nameEquality = (this.GetPlayerName() == newPlayer.GetPlayerName());
        bool chosenEqulity = (this.GetChosen() == newPlayer.GetChosen());
        bool imageEquality = (this.GetImage() == newPlayer.GetImage());
        return (idEquality && nameEquality && chosenEqulity && imageEquality);
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM players;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }


    public static List<Player> GetAll()
    {
      List<Player> allPlayers = new List<Player>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM players;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int playerId = rdr.GetInt32(0);
        string playerName = rdr.GetString(1);
        bool playerChosen = rdr.GetBoolean(2);
        string playerImage = rdr.GetString(3);
        Player newPlayer = new Player(playerName, playerChosen, playerImage, playerId);
        allPlayers.Add(newPlayer);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allPlayers;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO players (name, chosen, image) OUTPUT INSERTED.id VALUES (@PlayerName, @PlayerChosen, @PlayerImage)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@PlayerName";
      nameParameter.Value = this.GetPlayerName();

      SqlParameter chosenParameter = new SqlParameter();
      chosenParameter.ParameterName = "@PlayerChosen";
      chosenParameter.Value = this.GetChosen();

      SqlParameter imageParameter = new SqlParameter();
      imageParameter.ParameterName = "@PlayerImage";
      imageParameter.Value = this.GetImage();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(chosenParameter);
      cmd.Parameters.Add(imageParameter);

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


    public static Player Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE id = @PlayerId", conn);
      SqlParameter playerIdParameter = new SqlParameter();
      playerIdParameter.ParameterName = "@PlayerId";
      playerIdParameter.Value = id.ToString();
      cmd.Parameters.Add(playerIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundPlayerId = 0;
      string foundPlayerName = null;
      bool foundPlayerChosen = false;
      string foundPlayerImage = null;

      while(rdr.Read())
      {
        foundPlayerId = rdr.GetInt32(0);
        foundPlayerName = rdr.GetString(1);
        foundPlayerChosen = rdr.GetBoolean(2);
        foundPlayerImage = rdr.GetString(3);
      }
      Player foundPlayer = new Player(foundPlayerName, foundPlayerChosen, foundPlayerImage, foundPlayerId);

      if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }

     return foundPlayer;
    }

    public List<Shadow> GetShadows()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("SELECT * FROM shadows WHERE player_id = @Player_id;", conn);
     SqlParameter playerIdParameter = new SqlParameter();
     playerIdParameter.ParameterName = "@Player_id";
     playerIdParameter.Value = this.GetId();
     cmd.Parameters.Add(playerIdParameter);
     SqlDataReader rdr = cmd.ExecuteReader();

     List<Shadow> shadows = new List<Shadow> {};
     while(rdr.Read())
     {
       int shadowId = rdr.GetInt32(0);
       string shadowName = rdr.GetString(1);
       string shadowType = rdr.GetString(2);
       string shadowIntro = rdr.GetString(3);
       string shadowImg = rdr.GetString(4);

       Shadow newShadow = new Shadow(shadowName, shadowType, shadowIntro, shadowImg, shadowId);
       shadows.Add(newShadow);
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
