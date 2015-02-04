using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerMe.Data
{
    public interface IAnswerMeDataProviderFactory
    {
        IAnswerMeDataProvider Create();
    }

    public class AnswerMeDataProviderFactory : IAnswerMeDataProviderFactory
    {
        public IAnswerMeDataProvider Create()
        {
            return new AnswerMeDataProvider();
        }
    }
}
