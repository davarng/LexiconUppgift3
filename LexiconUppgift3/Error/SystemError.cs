using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.ErrorFolder
{
    abstract class SystemError
    {
        abstract public string ErrorMessage();
        public static void PrintAllErrors()
        {
            EngineFailureError engineFailureError = new EngineFailureError();
            TransmissionFailureError transmissionFailureError = new TransmissionFailureError();
            BrakeFailureError brakeFailureError = new BrakeFailureError();
            List<SystemError> errorList = [brakeFailureError, transmissionFailureError, engineFailureError];

            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var error in errorList)
            {
                Console.WriteLine(error.ErrorMessage());
            }
        }
    }
}
