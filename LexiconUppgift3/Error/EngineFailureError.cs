using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.ErrorFolder;

class EngineFailureError : SystemError
{
    public override string ErrorMessage()
    {
        return "Engine error: Control engine status.";
    }
}
