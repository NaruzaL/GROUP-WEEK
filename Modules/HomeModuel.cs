// using System;
// using System.Collections.Generic;
// using PersonaFive.Objects;
// using System.Data;
// using System.Data.SqlClient;
// using Nancy;
//
// namespace PersonaFive
// {
//   public class HomeModule : NancyModule
//   {
//     public HomeModule()
//     {
//       Get["/"] = _ => View["index.cshtml"];
//
//       Get["/first_question/ask"] = _ => {
//         Dictionary<string, object> model = new Dictionary<string, object>{};
//         List<Shadow> allShadows = Shadow.GetAll(); //randomly pick by RNG "int i = whatever random math is"
//         Shadow randomShadow = allShadows[i];
//         List<Answer> shadowAnswer = randomShadow.GetAnswers();
//         //make random selecion of one answer in shadowAnswers, shadowAnswer = shadowAnswers[i] (same as randomShadow)
//         Question randomQuestion = shadowAnwer.FindQuestion(); //FindQuestion will need to be written
//         List<Answer> allAnswers = Answers.GetAll();
//         //make random selection of two other answers that are not same type as selected shadow (method ?AddDummies?), List<Answer> answers = ..., answer.Add("shadowanswer"), shuffle positions of list then display(method ?Shuffle?) ["anwers", answers]
//         model.Add("shadow", randomShadow);
//         model.Add("answers", answers);
//         model.Add("quesion", randomQuestion);
//         return View["first_question.cshtml", model];
//         //include shadow.GetId() in links
//       };
//
//       Post["/first_question/result/{id}"] = parameters => {
//         Dictionary<string, object> model = new Dictionary<string, object>{};
//         Shadow randomShadow = new Shadow.Find(parameters.id);
//         List<Answer> shadowAnswers = Shadow.GetAnswers();
//         string result = "";
//         if (shadowAnswers.Contains(Request.Form["user-choice"]))
//         {
//           result = "good";
//         }
//         else
//         {
//           result = "bad";
//         }
//         model.Add("shadow", randomShadow);
//         model.Add("result", result);
//         // in .cshtml have "next question" link appear if result == good <a href = "/second_question/ask/@Model["shadow"].GetId()">Next question</a>
//         // otherwise link back to "/"
//         return View["result.cshtml", model];
//         //possibly need a bool for shadow to indicate question1 question2 correctness instead of string result
//       };
//
//       Get["second_question/ask/{id}"] = parameters => {
//         Shadow sameShadow = new Shadow.Find(parameters.id);
//         //do random question again same way as before
//       };
//
//     }
//   }
// }
