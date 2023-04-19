using XMatrixSolution;
using NUnit.Framework;
using static XMatrixSolution.XMatrix;
using System.Numerics;

namespace XMatrixSolutionTest
{

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_XMatrix_Constructor_PositiveSize()
        {
            // Test a positive size
            int size = 5;
            XMatrix matrix = new XMatrix(size);
            Assert.IsNotNull(matrix);
        }

        [Test]
        public void Test_XMatrix_Constructor_NegativeSize()
        {
            // Test a negative size
            int size = -5;
            Assert.Throws<XMatrix.NegativeSizeException>(() => new XMatrix(size));
        }

        [Test]
        public void Test_GetEntry()
        {
            int size = 3;

            XMatrix matrix = new XMatrix(size);

            // Test diagonal entry
            Assert.AreEqual(0, matrix.GetEntry(0, 0));
            Assert.AreEqual(0, matrix.GetEntry(2, 0));

            Assert.AreEqual(0, matrix.GetEntry(0, 1));
            Assert.AreEqual(0, matrix.GetEntry(2, 1));

            Assert.AreEqual(0, matrix.GetEntry(0, 1));

            // Test invalid index
            Assert.Throws<ReferenceToNullPartException>(() => matrix.GetEntry(3, 3));      
        }

        [Test]
        public void Test_SetEntry()
        {
            int size = 3;
            XMatrix matrix = new XMatrix(size);

            // Test diagonal entry
            matrix.SetEntry(0, 0, 1);
            matrix.SetEntry(0, 2, 2);
            matrix.SetEntry(1, 1, 3);
            matrix.SetEntry(2, 0, 4);
            matrix.SetEntry(2, 2, 5);
            
            Assert.AreEqual(1, matrix.GetEntry(0, 0));
            Assert.AreEqual(2, matrix.GetEntry(0, 2));
            Assert.AreEqual(3, matrix.GetEntry(1, 1));
            Assert.AreEqual(4, matrix.GetEntry(2, 0));
            Assert.AreEqual(5, matrix.GetEntry(2, 2));

       
            Assert.Throws<ReferenceToNullPartException>(() => matrix.SetEntry(0, 1, 4));

            // Test invalid index
            Assert.Throws<FormatException>(() => matrix.SetEntry(3, 3, 8));
        }

        [Test]
        public void Test_Add()
        {
            int size = 3;
            XMatrix matrixA = new XMatrix(size);
            XMatrix matrixB = new XMatrix(size);

            matrixA.SetEntry(0, 0, 5);
            matrixA.SetEntry(0, 2, 7);
            matrixA.SetEntry(1, 1, 4);
            matrixA.SetEntry(2, 0, 6);
            matrixA.SetEntry(2, 2, 8);


            matrixB.SetEntry(0, 0, 3);
            matrixB.SetEntry(0, 2, 4);
            matrixB.SetEntry(1, 1, 5);
            matrixB.SetEntry(2, 0, 1);
            matrixB.SetEntry(2, 2, 2);

            XMatrix result = XMatrix.Add(matrixA, matrixB);

            Assert.AreEqual(8,  result.GetEntry(0, 0));
            Assert.AreEqual(11, result.GetEntry(0, 2));
            Assert.AreEqual(9, result.GetEntry(1, 1));
            Assert.AreEqual(7, result.GetEntry(2, 0));
            Assert.AreEqual(10, result.GetEntry(2, 2));

            XMatrix matrixC = new XMatrix(2);
            Assert.Throws<XMatrix.DifferentSizeException>(() => XMatrix.Add(matrixA, matrixC));
        }

        [Test]
        public void Test_Multiply()
        {
            int size = 3;
            XMatrix matrixA = new XMatrix(size);
            XMatrix matrixB = new XMatrix(size);

            matrixA.SetEntry(0, 0, 2);
            matrixA.SetEntry(0, 2, 3);
            matrixA.SetEntry(1, 1, 5);
            matrixA.SetEntry(2, 0, 7);
            matrixA.SetEntry(2, 2, 8);

            matrixB.SetEntry(0, 0, 4);
            matrixB.SetEntry(0, 2, 1);
            matrixB.SetEntry(1, 1, 9);
            matrixB.SetEntry(2, 0, 7);
            matrixB.SetEntry(2, 2, 3);

            XMatrix result = XMatrix.Multiply(matrixA, matrixB);

            Assert.AreEqual(29, result.GetEntry(0, 0));
            Assert.AreEqual(11, result.GetEntry(0, 2));
            Assert.AreEqual(45, result.GetEntry(1, 1));
            Assert.AreEqual(84, result.GetEntry(2, 0));
            Assert.AreEqual(31, result.GetEntry(2, 2));

            XMatrix matrixC = new XMatrix(2);
            Assert.Throws<XMatrix.DifferentSizeException>(() => XMatrix.Multiply(matrixA, matrixC));
        }
    }
}