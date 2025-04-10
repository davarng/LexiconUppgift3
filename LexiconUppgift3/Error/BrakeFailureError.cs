using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.ErrorFolder;

class BrakeFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Brake error: Control brake status.";
    }
}
