using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerMe.Data;

namespace AnswerMe.Business
{
    public class AutoMapperManager
    {
        public static void Initialize()
        {
            AutoMapperInitializer.Initialize();
        }
    }
}
