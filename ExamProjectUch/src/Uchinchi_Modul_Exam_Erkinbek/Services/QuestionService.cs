using Uchinchi_Modul_Exam_Erkinbek.Dtos;
using Uchinchi_Modul_Exam_Erkinbek.Entities;
using Uchinchi_Modul_Exam_Erkinbek.Repositories;

namespace Uchinchi_Modul_Exam_Erkinbek.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository QuestionRepository;



    public QuestionService()
    {
        QuestionRepository = new QuestionRepository();
    }



    public Guid AddQuestion(QuestionCreateDto questionCreateDto)
    {

        //var questions = QuestionRepository.GetAllQuestions();





        var newQuestion = new Question()
        {
            QuestionId = Guid.NewGuid(),
            Text = questionCreateDto.Text,
            VariantA = questionCreateDto.VariantA,
            VariantB = questionCreateDto.VariantB,
            VariantC = questionCreateDto.VariantC,
        };

        var questions = QuestionRepository.GetAllQuestions();
        questions.Add(newQuestion);
        QuestionRepository.SaveAllQuestions(questions);

        return newQuestion.QuestionId;


    }
    public List<QuestionGetDto> GetAllQuestions()
    {

        var questions = QuestionRepository.GetAllQuestions();

        var queastionDtos = new List<QuestionGetDto>();
        foreach (var question in questions)
        {
            var questionDto = new QuestionGetDto()
            {
                QuestionId = question.QuestionId,
                Text = question.Text,
                VariantA = question.VariantA,
                VariantB = question.VariantB,
                VariantC = question.VariantC,


            };

            queastionDtos.Add(questionDto);
        }

        return queastionDtos;

    }
    public bool UpdateQuestion(Guid questionId, QuestionUpdateDto questionUpdateDto)
    {
        

       

        var questions = QuestionRepository.GetAllQuestions();

        if (questions == null)
        {
            questions = new List<Question>(); return false;

        }

        foreach (var question in questions)
        {
            if (question.QuestionId == questionId)
            {
                question.Text = questionUpdateDto.Text;
                question.VariantA = questionUpdateDto.VariantA;
                question.VariantB = questionUpdateDto.VariantB;
                question.VariantC = questionUpdateDto.VariantC;
                question.Answer = questionUpdateDto.Answer;
             
                return true;
            }
        }

        return false;
    }
    public bool DelateQuestion(Guid questionId)
    {
        var questions = QuestionRepository.GetAllQuestions();
       

        foreach (var question in questions)
        {
            if (question.QuestionId == questionId)
            {
                questions.Remove(question);
                QuestionRepository.SaveAllQuestions(questions);
               
                return true;
            }
        }

        return false;
    }

    public (bool, string) Question(bool isCorrect, string correctAnswer)
    {
        throw new NotImplementedException();
    }

    public (bool, string) SolveQuestion(Guid QuestionId, string Answer)
    {

        var questions = QuestionRepository.GetAllQuestions();

        if (questions == null)
        {
            questions = new List<Question>(); return (false, string.Empty);

        }
        var res = string.Empty;
        foreach( var question in questions)
        {
            if ( question.QuestionId == QuestionId)
            {
                res = question.Answer;
                if(question.Answer == Answer)
                {
                    return (true, Answer);
                }
            }
        }
        return (false, res);
    }

    public QuestionGetDto GetRandomQuestion()
    {
        //var questions = QuestionRepository.GetAllQuestions();

        //if (questions == null)
        //{
        //    questions = new List<Question>(); return new QuestionGetDto() ;

        //}
        //Random random = new Random();
        //for( var i = 0; i < questions.Count; i++)
        //{
        //    if ( i == random.Next(0, questions.Count) )
        //    {
        //        return QuestionGetDto.questions[i];
        //    }
        //}
        //return new QuestionGetDto() ;
        throw new NotImplementedException();
    }

    public int GetCountOfQuestions()
    {
        throw new NotImplementedException();
    }
}


