using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexators
{
    public struct LinearEquation
    {
        private int A;
        private int B;

        public int getA()
        { 
            return A; 
        }
        public int getB()
        {
            return B;
        }

        public static LinearEquation Parse(string equation)
        {
            string[] parts = equation.Split(',');

            if (parts.Length != 2)
            {
                throw new ArgumentException("Неверный формат уравнения");
            }

            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);

            LinearEquation result = new LinearEquation() { A = a, B = b };
            return result;
        }

        public override string ToString()
        {
            return $"{A}*X + {B}*Y = 0";
        }


    }
}
