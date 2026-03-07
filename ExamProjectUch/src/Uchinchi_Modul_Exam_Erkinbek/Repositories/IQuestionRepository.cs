
using Uchinchi_Modul_Exam_Erkinbek.Entities;

namespace Uchinchi_Modul_Exam_Erkinbek.Repositories
{
    public interface IQuestionRepository
    {
        public List<Question>? GetAllQuestions();
        public void SaveAllQuestions(List<Question> questions);

    }
}