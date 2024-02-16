using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IPresenter
    {
        void Success<TResponse>(TResponse response);
        void Error<TResponse>(TResponse response, bool hasValidationErrors);
        void Error(bool hasValidationErrors);
    }
}
