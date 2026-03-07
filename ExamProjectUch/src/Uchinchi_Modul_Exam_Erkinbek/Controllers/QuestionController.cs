using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uchinchi_Modul_Exam_Erkinbek.Dtos;
using Uchinchi_Modul_Exam_Erkinbek.Entities;
using Uchinchi_Modul_Exam_Erkinbek.Services;

namespace Uchinchi_Modul_Exam_Erkinbek.Controllers
{
    [Route("api/Question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService QuestionService;

        public QuestionController()
        {
            QuestionService = new QuestionService();
        }

        [HttpPost("add")]

        public Guid Create(QuestionCreateDto questionCreateDto)
        {
            return QuestionService.AddQuestion(questionCreateDto);
        }

        [HttpGet("get-all")]

        public List<QuestionGetDto> GetAll()
        {
            return QuestionService.GetAllQuestions();
        }

        [HttpDelete("delete")]
        public bool Delete(Guid postId)
        {
            return QuestionService.DelateQuestion(postId);
        }

        [HttpPut("update")]
        public bool Update(Guid questionId, QuestionUpdateDto questionnew)
        {
            return QuestionService.UpdateQuestion(questionId, questionnew);
        }



    }
}
