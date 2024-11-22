using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionHomeWork_1.Services.Abstracts
{
    public interface ISMTPService
    {

        void SendSMTP(string email, string message);

    }
}
