using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2ConsoleApp;
using System;
using System.IO;
using System.Reflection;

namespace Practica2UnitTests
{
    [TestClass]
    public class ProgramTests
    {
        private MethodInfo GetPrivateMethod(string methodName)
        {
            Type type = typeof(Program);
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;
            return type.GetMethod(methodName, flags);
        }

        [TestMethod]
        public void TestEjercicio1_DivisionByZero()
        {
            string input = "5";

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            using (StringReader inputReader = new StringReader(input))
            {
                Console.SetIn(inputReader);

                MethodInfo method = GetPrivateMethod("Ejercicio1");
                method.Invoke(null, null);

                Assert.IsTrue(output.ToString().Trim().Length > 0);
            }
        }

        [TestMethod]
        public void TestEjercicio2_DivisionByZero()
        {
            string inputDividendo = "10";
            string inputDivisor = "0";

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            using (StringReader inputDividendoReader = new StringReader(inputDividendo))
            using (StringReader inputDivisorReader = new StringReader(inputDivisor))
            {
                Console.SetIn(inputDividendoReader);
                Console.SetIn(inputDivisorReader);

                MethodInfo method = GetPrivateMethod("Ejercicio2");
                method.Invoke(null, null);

                Assert.IsTrue(output.ToString().Trim().Length > 0);
            }
        }

        [TestMethod]
        public void TestEjercicio3_Exception()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            MethodInfo method = GetPrivateMethod("Ejercicio3");
            method.Invoke(null, null);
      
            Assert.IsTrue(output.ToString().Trim().Length > 0);
        }

        [TestMethod]
        public void TestEjercicio4_CustomException()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            MethodInfo method = GetPrivateMethod("Ejercicio4");
            method.Invoke(null, null);

            Assert.IsTrue(output.ToString().Trim().Length > 0);
        }
    }
}
