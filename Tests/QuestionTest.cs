using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PersonaFive.Objects;

namespace PersonaFive
{
  [Collection("persona_five_test")]
 public class QuestionTest : IDisposable
  {
   public QuestionTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=persona_five_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Question.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfQuestionsAreTheSame()
    {
      Question firstQuestion = new Question("What is your favorite color", "gloomy", 1);
      Question secondQuestion = new Question("What is your favorite color", "gloomy", 1);
      Assert.Equal(firstQuestion, secondQuestion);
    }

    [Fact]
    public void Test_Save_ToQuestionDatabase()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy", 2);
      testQuestion.Save();

      List<Question> result = Question.GetAll();
      List<Question> testList = new List<Question>{testQuestion};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy", 2);
      testQuestion.Save();
      int testId = testQuestion.GetId();
      int savedQuestionId = Question.GetAll()[0].GetId();
      Assert.Equal(testId, savedQuestionId);
    }

    [Fact]
    public void Test_Find_FindsQuestionsInDatabase()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy", 2);
      testQuestion.Save();
      Question foundQuestion = Question.Find(testQuestion.GetId());
      Assert.Equal(testQuestion, foundQuestion);
    }

    public void Dispose()
    {
      Shadow.DeleteAll();
      Answer.DeleteAll();
      Question.DeleteAll();
    }
  }
}
