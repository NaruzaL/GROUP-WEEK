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
      Question firstQuestion = new Question("What is your favorite color", "gloomy");
      Question secondQuestion = new Question("What is your favorite color", "gloomy");
      Assert.Equal(firstQuestion, secondQuestion);
    }

    [Fact]
    public void Test_Save_ToQuestionDatabase()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy");
      testQuestion.Save();

      List<Question> result = Question.GetAll();
      List<Question> testList = new List<Question>{testQuestion};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy");
      testQuestion.Save();
      int testId = testQuestion.GetId();
      int savedQuestionId = Question.GetAll()[0].GetId();
      Assert.Equal(testId, savedQuestionId);
    }

    [Fact]
    public void Test_Find_FindsQuestionsInDatabase()
    {
      Question testQuestion = new Question("What is your favorite color", "gloomy");
      testQuestion.Save();
      Question foundQuestion = Question.Find(testQuestion.GetId());
      Assert.Equal(testQuestion, foundQuestion);
    }

    [Fact]
    public void Test_GetAnswer_RetrievesAllAnswerWithQuestion()
    {

      Question testQuestion = new Question("sentence question", "gloomy");
      testQuestion.Save();

      Answer testAnswer = new Answer("sentence answer", "gloomy");
      testAnswer.Save();
      Answer testAnswer2 = new Answer("sentence2 answer2", "timid");
      testAnswer2.Save();

      testQuestion.AddAnswer(testAnswer);
      testQuestion.AddAnswer(testAnswer2);
      List<Answer> result = testQuestion.GetAnswers();
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
