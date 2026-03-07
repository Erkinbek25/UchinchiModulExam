using Uchinchi_Modul_Exam_Erkinbek.Dtos;
using Uchinchi_Modul_Exam_Erkinbek.Entities;


namespace Uchinchi_Modul_Exam_Erkinbek.Services
{
    public interface IQuestionService
    {
        public Guid AddQuestion(QuestionCreateDto  questionCreateDto);
        public List<QuestionGetDto> GetAllQuestions();
        public bool DelateQuestion(Guid questionId);
        public bool UpdateQuestion(Guid  questionId, QuestionUpdateDto questionUpdate);
        public (bool, string) Question(bool isCorrect, string correctAnswer);
        public (bool, string) SolveQuestion(Guid QuestionId, string Answer);
        public QuestionGetDto GetRandomQuestion();
        public int GetCountOfQuestions();

    }
}