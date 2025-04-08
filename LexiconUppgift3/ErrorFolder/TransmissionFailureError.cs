using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.ErrorFolder
{
    class TransmissionFailureError : SystemError
    {
        public override string ErrorMessage()
        {
            return "Transmission error: Control transmission status.";
        }
    }
}
