using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PersonaFive.Objects;

namespace PersonaFive
{
  [Collection("persona_five_test")]
 public class AnswerTest : IDisposable
  {
   public AnswerTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=persona_five_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Answer.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfAnswersAreTheSame()
    {
      Answer firstAnswer = new Answer("Why so serious", "irritable");
      Answer secondAnswer = new Answer("Why so serious", "irritable");
      Assert.Equal(firstAnswer, secondAnswer);
    }

    [Fact]
    public void Test_Save_ToAnswerDatabase()
    {
      Answer testAnswer = new Answer("Why so serious", "irritable");
      testAnswer.Save();

      List<Answer> result = Answer.GetAll();
      List<Answer> testList = new List<Answer>{testAnswer};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Answer testAnswer = new Answer("Why so serious", "irritable");
      testAnswer.Save();
      int testId = testAnswer.GetId();
      int savedAnswerId = Answer.GetAll()[0].GetId();
      Assert.Equal(testId, savedAnswerId);
    }

    [Fact]
    public void Test_Find_FindsAnswersInDatabase()
    {
      Answer testAnswer = new Answer("Why so serious", "irritable");
      testAnswer.Save();
      Answer foundAnswer = Answer.Find(testAnswer.GetId());
      Assert.Equal(testAnswer, foundAnswer);
    }

    public void Dispose()
    {
      Shadow.DeleteAll();
      Answer.DeleteAll();
      Question.DeleteAll();
    }
  }
}
