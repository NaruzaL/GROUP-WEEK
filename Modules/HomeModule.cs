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
        Shadow randomShadow = allShadows[i-1];//randomly chosen shadow

        List<Answer> shadowAnswers = randomShadow.GetAnswers();//answers that will be linked to it in DB

        List<Question> answerQuestions = shadowAnswers[0].GetQuestions();
        int j = new Random().Next(1, answerQuestions.Count + 1);
        Question newQuestion = answerQuestions[j-1]//Question for the answers

        model.Add("shadow", randomShadow);
        model.Add("answers", shadowAnswers);
        model.Add("question", newQuestion);
        return View["first_question.cshtml", model];
      };

      Post["/first_question/result/{id}"] = parameters => {

        Shadow randomShadow = new Shadow.Find(Request.Form["shadow-id"]);
        Answer selecetedAnswer = Answer.Find(Request.Form["answer-id"]);
        // put if statement into cshtmlpage
        if (selectedAnswer.GetAnswerType() == randomShadow.GetShadowType())
        {
          result = "Your answer pleases me";
        }
        else
        {
          result = "DIE!";
        }
        // in .cshtml have "next question" link appear if result == good <a href = "/second_question/ask/@Model["shadow"].GetId()">Next question</a>
        // otherwise link back to "/"
        return View["result.cshtml", randomShadow];
      };

      Get["second_question/ask/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Shadow sameShadow = new Shadow.Find(Request.Form["shadow-id"]);
        List<Answer> shadowAnswers = randomShadow.GetAnswers();//answers that will be linked to it in DB

        List<Question> answerQuestions = shadowAnswers[0].GetQuestions();
        int j = new Random().Next(1, answerQuestions.Count + 1);
        Question newQuestion = answerQuestions[j-1]//Question for the answers

        model.Add("shadow", sameShadow);
        model.Add("answers", shadowAnswers);
        model.Add("question", newQuestion);
        return View["first_question.cshtml", model];
      };

    }
  }
}
