using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PersonaFive.Objects;

namespace PersonaFive
{
  [Collection("persona_five_test")]
 public class ShadowTest : IDisposable
  {
   public ShadowTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=persona_five_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Shadow.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfShadowsAreTheSame()
    {
      Shadow firstShadow = new Shadow("Boogie man", "irritable", "intro sentence", "image filepath");
      Shadow secondShadow = new Shadow("Boogie man", "irritable", "intro sentence", "image filepath");
      Assert.Equal(firstShadow, secondShadow);
    }

    [Fact]
    public void Test_Save_ToShadowDatabase()
    {
      Shadow testShadow = new Shadow("Boogie man", "irritable", "intro sentence", "image filepath");
      testShadow.Save();

      List<Shadow> result = Shadow.GetAll();
      List<Shadow> testList = new List<Shadow>{testShadow};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Shadow testShadow = new Shadow("Boogie man", "irritable", "intro sentence", "image filepath");
      testShadow.Save();
      int testId = testShadow.GetId();
      int savedShadowId = Shadow.GetAll()[0].GetId();
      Assert.Equal(testId, savedShadowId);
    }

    [Fact]
    public void Test_Find_FindsShadowsInDatabase()
    {
      Shadow testShadow = new Shadow("Boogie man", "irritable", "intro sentence", "image filepath");
      testShadow.Save();
      Shadow foundShadow = Shadow.Find(testShadow.GetId());
      Assert.Equal(testShadow, foundShadow);
    }

    [Fact]
    public void Test_GetAnswer_RetrievesAllAnswerWithShadow()
    {

      Shadow testShadow = new Shadow("Boogie man", "irritable", "intro sentence", "/Content/img/shadow.png");
      testShadow.Save();

      Answer testAnswer = new Answer("sentence answer", "gloomy");
      testAnswer.Save();
      Answer testAnswer2 = new Answer("sentece two", "irritable");
      testAnswer2.Save();

      testShadow.AddAnswer(testAnswer);
      testShadow.AddAnswer(testAnswer2);
      List<Answer> result = testShadow.GetAnswers();
      List<Answer> testList = new List<Answer>{testAnswer, testAnswer2};
      Assert.Equal(testList, result);
    }


    public void Dispose()
    {
      Shadow.DeleteAll();
      Answer.DeleteAll();
      Question.DeleteAll();
    }
  }
}
