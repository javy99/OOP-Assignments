using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMatrixSolution
{
    
    public class XMatrix
    {
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };
        #endregion

        #region Attributes
        private List<int> mainDiagonal;
        private List<int> secondaryDiagonal;
        private int size;
        #endregion

        #region Constructor
        public XMatrix(int size)
        {
            if (size <= 0) throw new NegativeSizeException();
           
            this.size = size;
            mainDiagonal = new List<int>(size);
            secondaryDiagonal = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                mainDiagonal.Add(0);
                secondaryDiagonal.Add(0);
            }
        }
        public XMatrix(XMatrix x)
        {
            mainDiagonal = new List<int>(x.mainDiagonal);
            secondaryDiagonal = new List<int>(x.secondaryDiagonal);
        }
        #endregion


        public int GetEntry(int i, int j)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new ReferenceToNullPartException();
            }

            if (i == j)
            {
                return mainDiagonal[i];
            }
            else if (i + j == size - 1)
            {
                return secondaryDiagonal[i];
            }
            else
            {
                return 0;
            }
        }

        public void SetEntry(int i, int j, int value)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new FormatException();
            }

            if (i == j)
            {
                mainDiagonal[i] = value;
            }
            else if (i + j == size - 1)
            {
                secondaryDiagonal[i] = value;
            }
            else
            {
                if (value != 0)
                {
                    throw new ReferenceToNullPartException();
                }

            }
        }

        public static XMatrix Add(XMatrix a, XMatrix b)
        {
            if (a.size != b.size) throw new DifferentSizeException();
           
            XMatrix result = new XMatrix(a.size);

            for (int i = 0; i < a.size; i++)
            {
                result.mainDiagonal[i] = a.mainDiagonal[i] + b.mainDiagonal[i];
                result.secondaryDiagonal[i] = a.secondaryDiagonal[i] + b.secondaryDiagonal[i];
            }

            return result;
        }

        public static XMatrix Multiply(XMatrix a, XMatrix b)
        {
            
            if (a.size != b.size)
            {
                throw new DifferentSizeException();
            }
            

            XMatrix result = new XMatrix(a.size);

            for (int i = 0; i < a.size; i++)
            {
                for (int j = 0; j < a.size; j++)
                {
                    int value = 0;

                    for (int k = 0; k < a.size; k++)
                    {
                        value += a.GetEntry(i, k) * b.GetEntry(k, j);
                    }

                    result.SetEntry(i, j, value);
                }
            }

            return result;
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(GetEntry(i, j) + "\t");
                }

                Console.WriteLine();
            }
        }
    }

}

