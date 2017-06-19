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

    [Fact]
    public void Test_GetShadow_RetrievesAllShadowWithAnswer()
    {

      Answer testAnswer = new Answer("sentence answer", "gloomy");
      testAnswer.Save();

      Shadow testShadow = new Shadow("Boogie man", "irritable", "intro sentence", "/Content/img/shadow.png");
      testShadow.Save();
      Shadow testShadow2 = new Shadow("something man", "gloomy", "intro sentence two", "/Content/img/shadow_two.png");
      testShadow2.Save();

      testAnswer.AddShadow(testShadow);
      testAnswer.AddShadow(testShadow2);
      List<Shadow> result = testAnswer.GetShadows();
      List<Shadow> testList = new List<Shadow>{testShadow, testShadow2};
      Assert.Equal(testList, result);
    }

    [Fact]
      public void Test_GetQuestion_RetrievesAllQuestionsWithAnswers()
      {
        Answer testAnswer = new Answer("sentence answer", "gloomy");
        testAnswer.Save();

        Question firstQuestion = new Question("blah blah blah", "gloomy", testAnswer.GetId());
        firstQuestion.Save();
        Question secondQuestion = new Question("blah blah", "gloomy", testAnswer.GetId());
        secondQuestion.Save();


        List<Question> testQuestionList = new List<Question> {firstQuestion, secondQuestion};
        List<Question> resultQuestionList = testAnswer.GetQuestions();

        Assert.Equal(testQuestionList, resultQuestionList);
      }

    public void Dispose()
    {
      Shadow.DeleteAll();
      Answer.DeleteAll();
      Question.DeleteAll();
    }
  }
}
