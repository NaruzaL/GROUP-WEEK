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

        int j = new Random().Next(1, shadowAnswers.Count + 1);
        Answer randomAnswer = shadowAnswers[j-1];
        List<Question> allRandomQuestions = randomAnswer.GetQuestions();

        int n = new Random().Next(1, allRandomQuestions.Count);
        Question randomQuestion = allRandomQuestions[n-1];

        List<Answer> allAnswers = Answer.GetAll();
        int k = new Random().Next(1, allAnswers.Count + 1);
        Answer answerOne = allAnswers[k-1];
        int l = new Random().Next(1, allAnswers.Count + 1);
        Answer answerTwo = allAnswers[l-1];

        List<Answer> displayedAnswers = new List<Answer>{};
        displayedAnswers.Add(randomAnswer);
        displayedAnswers.Add(answerOne);
        displayedAnswers.Add(answerTwo);
        //make random selection of two other answers that are not same type as selected shadow | List<Answer> answers = allAnswers.GetTwoRandoms() | answers.Add("shadowanswer") | shuffle positions of list then display ["anwers", answers]
        model.Add("shadow", randomShadow);
        model.Add("answers", displayedAnswers);
        model.Add("question", randomQuestion);
        return View["first_question.cshtml", model];
        //include shadow.GetId() in links | parameters?
      };

      // Post["/first_question/result/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>{};
      //   Shadow randomShadow = new Shadow.Find(parameters.id);
      //   List<Answer> shadowAnswers = Shadow.GetAnswers();
      //   Answer selecetedAnswer = Answer.Find(Request.Form["answer-id"]);
      //   string result = "";
      //   if (shadowAnswers.Contains(selectedAnswer))
      //   {
      //     result = "Your answer pleases me";
      //   }
      //   else
      //   {
      //     result = "DIE!";
      //   }
      //   model.Add("shadow", randomShadow);
      //   model.Add("result", result);
      //   // in .cshtml have "next question" link appear if result == good <a href = "/second_question/ask/@Model["shadow"].GetId()">Next question</a>
      //   // otherwise link back to "/"
      //   return View["result.cshtml", model];
      //   //possibly need a bool for shadow to indicate question1 question2 correctness instead of string result
      // };
      //
      // Get["second_question/ask/{id}"] = parameters => {
      //   Shadow sameShadow = new Shadow.Find(parameters.id);
      //   //do random question again same way as before
      // };

    }
  }
}
