using System;


namespace Practica2ConsoleApp.Classes
{
    public class Logic
    {
        public static void ThrowException()
        {
            throw new Exception("Excepción lanzada desde Logic");
        }

        public static void ThrowCustomException(string message)
        {
            throw new CustomException(message);
        }
    }
}
