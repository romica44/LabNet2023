using System;


namespace Practica2ConsoleApp.Classes
{
     public class CustomException : Exception
    {
        public CustomException(string message) : base("CustomException: " + message)
        {
        }
    }
}
