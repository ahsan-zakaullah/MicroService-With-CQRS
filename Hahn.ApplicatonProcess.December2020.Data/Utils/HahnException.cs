using System;

namespace Hahn.ApplicatonProcess.December2020.Data.Utils
{
    /// <summary>
    /// Implement the custom exception handling
    /// </summary>
    public class HahnException : Exception
    {
        public HahnException(string message)
            : base(message)
        {

        }

    }
}
