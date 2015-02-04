using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerMe.Common.Models;
using AutoMapper;

namespace AnswerMe.Data
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            // Question
            Mapper.CreateMap<QuestionDto, Question>();
            Mapper.CreateMap<Question, QuestionDto>();
        }
    }
}
