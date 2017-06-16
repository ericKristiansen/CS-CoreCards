using System;
using NUnit.Common;
using NUnitLite;
using System.Reflection;

namespace Testing123
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the test application to launch 
        /// the tests in the 'ClassTest.cs' file.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Main(string[] args)
        {
            return new AutoRun(typeof(Program).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);

        }
    }

}
