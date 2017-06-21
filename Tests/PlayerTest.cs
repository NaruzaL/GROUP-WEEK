using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PersonaFive.Objects;

namespace PersonaFive
{
  [Collection("persona_five_test")]
 public class PlayerTest : IDisposable
  {
   public PlayerTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=persona_five_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Player.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfPlayersAreTheSame()
    {
      Player firstPlayer = new Player("Jim", false, "img filepath");
      Player secondPlayer = new Player("Jim", false, "img filepath");
      Assert.Equal(firstPlayer, secondPlayer);
    }

    [Fact]
    public void Test_Save_ToPlayerDatabase()
    {
      Player testPlayer = new Player("Jim", false, "img filepath");
      testPlayer.Save();

      List<Player> result = Player.GetAll();
      List<Player> testList = new List<Player>{testPlayer};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Player testPlayer = new Player("Jim", false, "img filepath");
      testPlayer.Save();
      int testId = testPlayer.GetId();
      int savedPlayerId = Player.GetAll()[0].GetId();
      Assert.Equal(testId, savedPlayerId);
    }

    [Fact]
    public void Test_Find_FindsPlayersInDatabase()
    {
      Player testPlayer = new Player("Jim", false, "img filepath");
      testPlayer.Save();
      Player foundPlayer = Player.Find(testPlayer.GetId());
      Assert.Equal(testPlayer, foundPlayer);
    }


    public void Dispose()
    {
      Player.DeleteAll();
      Shadow.DeleteAll();
      Answer.DeleteAll();
      Question.DeleteAll();
    }
  }
}