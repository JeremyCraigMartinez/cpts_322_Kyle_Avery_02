/// Created By: Kyle Avery 
/// Student ID: 11237105
/// Created On: 1/31/2014
/// Edited By: N/A
/// Edited On: N/A
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace cpts_322_Kyle_Avery_02
{
    class FibTextReader : System.IO.TextReader
    {
        public FibTextReader() { max_fib = 0; fib_location = 0; mcurrent = new BigInteger(0); mlast = new BigInteger(0); }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/31/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: FibTextReader
        /// Relies On: knowing how big the Fibonacci sequence you want is
        /// Purpose: generates fib lines
        /// </summary>
        /// <param name="max_lines"> max fib sequence </param>
        public FibTextReader(int max_lines) { max_fib = max_lines; fib_location = 0; mcurrent = new BigInteger(0); mlast = new BigInteger(0); }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/31/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: fib_location
        /// Relies On: Fibonacci sequence size being passed in
        /// Purpose: Returns the next fibonacci number 
        /// </summary>
        /// <returns> The next Fibonacci number </returns>
        public override string ReadLine()
        {
            BigInteger temp = new BigInteger(0);
            string output = "";
            temp = BigInteger.Add(mcurrent, mlast);
            if (fib_location <= 1)
                temp = new BigInteger(fib_location);
            else if (fib_location == 2)
                temp = new BigInteger(1);
            
            mlast = mcurrent;
            mcurrent = temp;
            ++fib_location;
            output = mcurrent.ToString();
            return output;
            //if (fib_location == max_fib)
            //    return null;
            //BigInteger fib = fib_helper(fib_location);
            //BigInteger last_fib = fib_helper(fib_location - 1);
            //++fib_location;
            //return ((fib + last_fib).ToString());
        }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/31/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: fib_helper
        /// Relies On: The fib index to be passed in
        /// Purpose: returns the fibonacci number
        /// </summary>
        /// <param name="n"> How far in the fib sequence we want to go </param>
        /// <returns> the fibonacci number </returns>
        //private BigInteger fib_helper(BigInteger n)
        //{
        //    if (n <= 1)
        //        return n;
        //    if (n == 2)
        //        return 1;
        //    return (fib_helper(n - 1) + fib_helper(n - 2));
        //}
        public override int Peek()
        {
            if (fib_location > max_fib)
                return -1;
            return 0;

        }
        #region Variables
        private int max_fib;
        private int fib_location;
        private BigInteger mcurrent;
        private BigInteger mlast;
        #endregion
    }
}
