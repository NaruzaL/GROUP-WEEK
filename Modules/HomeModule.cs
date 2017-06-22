using System;
using System.Collections.Generic;
using PersonaFive.Objects;
using System.Data;
using System.Data.SqlClient;
using Nancy;

namespace PersonaFive
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];

      Get["/first_question/ask"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        List<Shadow> allShadows = Shadow.GetAll();
        int i = new Random().Next(1, allShadows.Count + 1 );
        Shadow randomShadow = allShadows[i-1];

        List<Answer> shadowAnswers = randomShadow.GetAnswers();
        int n = new Random().Next(1, shadowAnswers.Count + 1);
        Answer shadowAnswer = shadowAnswers[n-1];
        List<Question> answerQuestions = shadowAnswer.GetQuestions();
        int j = new Random().Next(1, answerQuestions.Count + 1);
        Question answerQuestion = answerQuestions[j -1];


        List<Answer> newAnswers = answerQuestion.GetAnswers();

        List<Answer> leftOverAnswers = new List<Answer>{};
        List<Answer> questionAnswers = new List<Answer>{};
        foreach (var answer in newAnswers)
        {
          string shadowType = randomShadow.GetShadowType();
          string answerType = answer.GetAnswerType();
          if (answerType == shadowType)
          {
            questionAnswers.Add(answer);
          }
          else
          {
            leftOverAnswers.Add(answer);
          }
        }
        int a = new Random().Next(1, leftOverAnswers.Count + 1);
        leftOverAnswers.Remove(leftOverAnswers[a-1]);
        foreach (var answer in leftOverAnswers)
        {
          questionAnswers.Add(answer);
        }
        model.Add("shadow", randomShadow);
        model.Add("answers", questionAnswers);
        model.Add("question", answerQuestion);
        return View["first_question.cshtml", model];
      };

      Post["/first_question/result/{id}"] = parameters => {
        Dictionary<string,object> model = new Dictionary<string,object>{};
        Shadow randomShadow = Shadow.Find(Request.Form["shadow-id"]);
        Question firstQuestion = Question.Find(Request.Form["question-id"]);
        Answer selectedAnswer = Answer.Find(Request.Form["answer-id"]);
        model.Add("shadow", randomShadow);
        model.Add("question1", firstQuestion);
        model.Add("answer", selectedAnswer);
        return View["result.cshtml", model];
      };

      Get["second_question/ask"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Shadow sameShadow = Shadow.Find(Request.Query["shadow-id"]);
        Question question1 = Question.Find(Request.Query["question-id"]);

        List<Answer> shadowAnswers = sameShadow.GetAnswers();
        int n = new Random().Next(1, shadowAnswers.Count + 1);
        Answer shadowAnswer = shadowAnswers[n-1];
        List<Question> answerQuestions = shadowAnswer.GetQuestions();
        lock (answerQuestions)
        {
          for(int q = 0; q < answerQuestions.Count; q++)
          {
            if(answerQuestions[q].GetQuestionName() == question1.GetQuestionName())
            {
              answerQuestions.Remove(answerQuestions[q]);
            }
          }
        }

        int j = new Random().Next(1, answerQuestions.Count + 1);
        Question answerQuestion = answerQuestions[j -1];
        List<Answer> newAnswers = answerQuestion.GetAnswers();

        List<Answer> leftOverAnswers = new List<Answer>{};
        List<Answer> questionAnswers = new List<Answer>{};
        foreach (var answer in newAnswers)
        {
          string shadowType = sameShadow.GetShadowType();
          string answerType = answer.GetAnswerType();
          if (answerType == shadowType)
          {
            questionAnswers.Add(answer);
          }
          else
          {
            leftOverAnswers.Add(answer);
          }
        }
        int a = new Random().Next(1, leftOverAnswers.Count + 1);
        leftOverAnswers.Remove(leftOverAnswers[a-1]);
        foreach (var answer in leftOverAnswers)
        {
          questionAnswers.Add(answer);
        }

        model.Add("shadow", sameShadow);
        model.Add("answers", questionAnswers);
        model.Add("question", answerQuestion);
        return View["second_question.cshtml", model];
      };

      Post["/second_question/result/{id}"] = parameters => {
        Dictionary<string,object> model = new Dictionary<string,object>{};
        Shadow randomShadow = Shadow.Find(parameters.id);
        Answer selectedAnswer = Answer.Find(Request.Form["answer-id"]);
        model.Add("shadow", randomShadow);
        model.Add("answer", selectedAnswer);
        return View["second_result.cshtml", model];
      };

      Get["/capture/{id}"] = parameters => {
        Shadow capturedShadow = Shadow.Find(parameters.id);
        return View["capture.cshtml", capturedShadow];
      };

      Get["/about"] = _ => View["about.cshtml"];

    }
  }
}
