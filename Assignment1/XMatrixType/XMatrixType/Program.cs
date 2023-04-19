namespace XMatrixSolution
{
    internal class Program
    {
        static XMatrix matrix = null;
        static XMatrix matrix2 = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=============== MENU ===============");
                Console.WriteLine("1. Create matrix");
                Console.WriteLine("2. Print matrix");
                Console.WriteLine("3. Get entry");
                Console.WriteLine("4. Set entry");
                Console.WriteLine("5. Add matrices");
                Console.WriteLine("6. Multiply matrices");
                Console.WriteLine("0. Exit");
                Console.WriteLine("====================================");
                Console.Write("Choose: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("====================================");

                switch (choice)
                {
                    case 1:
                        CreateMatrix();
                        break;
                    case 2:
                        PrintMatrix();
                        break;
                    case 3:
                        GetEntry();
                        break;
                    case 4:
                        SetEntry();
                        break;
                    case 5:
                        AddMatrices();
                        break;
                    case 6:
                        MultiplyMatrices();
                        break;
                    case 0:
                        return;
                }

                Console.WriteLine();
            }

        }

        static void CreateMatrix()
        {
            bool ok = false;
            int size = -1;
            do
            {
                try
                {
                    Console.Write("Enter matrix size: ");
                    size = int.Parse(Console.ReadLine());
                    ok = size > 0;
                    matrix = new XMatrix(size);
                    Console.WriteLine("====================================");
                }
                catch (XMatrix.NegativeSizeException)
                {
                    Console.WriteLine("Size of matrix should be positive!");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid Format!");
                }
            } while (!ok);
        }

        static void PrintMatrix()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix not created!");
                Console.WriteLine("====================================");
            }
            else
            {
                matrix.Print();
                Console.WriteLine("====================================");
            }
        }

        static void GetEntry()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix is not created!");
                Console.WriteLine("====================================");
            }
            else
            {
                try
                {
                    Console.Write("Enter row index: ");
                    int row = int.Parse(Console.ReadLine());

                    Console.Write("Enter column index: ");
                    int col = int.Parse(Console.ReadLine());

                    Console.WriteLine("Entry value: " + matrix.GetEntry(row, col));
                    Console.WriteLine("====================================");
                }
                catch (XMatrix.ReferenceToNullPartException)
                {
                    Console.WriteLine("Invalid index(es)!");
                }

            }
        }

        static void SetEntry()
        {
            if (matrix == null)
            {
                Console.WriteLine("Matrix is not created!");
            }
            else
            {
                try
                {
                    Console.Write("Enter row index: ");
                    int row = int.Parse(Console.ReadLine());


                    Console.Write("Enter column index: ");
                    int col = int.Parse(Console.ReadLine());

                    Console.Write("Enter entry value: ");
                    int value = int.Parse(Console.ReadLine());
                    matrix.SetEntry(row, col, value);
                    Console.WriteLine("====================================");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid index(es)!");
                }
                catch (XMatrix.ReferenceToNullPartException)
                {
                    Console.WriteLine("Only elements on the diagonal may be non-zero!");
                }
            }
        }

        static void AddMatrices()
        {
            if (matrix == null)
            {
                Console.WriteLine("First matrix is not created!");
            }
            else
            {
                CreateSecondMatrix();
                Console.WriteLine("====================================");
                try
                {
                    XMatrix result = XMatrix.Add(matrix, matrix2);
                    result.Print();
                    Console.WriteLine("====================================");
                }
                catch (XMatrix.DifferentSizeException)
                {
                    Console.WriteLine("Both matrices should be of the same size!");
                }
            }
        }

        static void MultiplyMatrices()
        {
            if (matrix == null)
            {
                Console.WriteLine("First matrix not created!");
            }
            else
            {
                CreateSecondMatrix();
                Console.WriteLine("====================================");
                try
                {
                    XMatrix result = XMatrix.Multiply(matrix, matrix2);
                    result.Print();
                    Console.WriteLine("====================================");
                }
                catch (XMatrix.DifferentSizeException)
                {
                    Console.WriteLine("Both matrices should be of the same size!");
                }

            }
        }

        static void CreateSecondMatrix()
        {
            bool ok2 = false;
            int size2 = -1;
            do
            {
                try
                {
                    Console.Write("Enter second matrix size: ");
                    size2 = int.Parse(Console.ReadLine());
                    ok2 = size2 > 0;
                    matrix2 = new XMatrix(size2);
                    Console.WriteLine("====================================");
                }
                catch (XMatrix.NegativeSizeException)
                {
                    Console.WriteLine("Size of matrix should be positive!");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid Format!");
                }
            } while (!ok2);

            for (int i = 0; i < size2; i++)
            {
                Console.Write($"Enter element at diagonal ({i}, {i}): ");
                int mainDiagonalEntry = int.Parse(Console.ReadLine());
                matrix2.SetEntry(i, i, mainDiagonalEntry);

                if (i != size2 - 1 - i)
                {
                    Console.Write($"Enter element at diagonal ({i}, {size2 - 1 - i}): ");
                    int secondaryDiagonalEntry = int.Parse(Console.ReadLine());
                    matrix2.SetEntry(i, size2 - 1 - i, secondaryDiagonalEntry);
                }
            }
        }
    }
}
