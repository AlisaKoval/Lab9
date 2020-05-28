using System;

namespace Lab9._8.b
{
    class Program
    {
        public static MatrixList GetMatrix(int[,] array)
        {
            MatrixList matrixList = new MatrixList();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] tmp = new int[array.GetLength(1)];
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    tmp[j] = array[i, j];
                }
                matrixList.Add(tmp);
            }
            return matrixList;
        }
        public static void MatrixFilling(ref int [,] matrix,ref MatrixList matrixList)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(2);
                }
            }
            matrixList = GetMatrix(matrix);
        }
        public static MatrixList TransposeMatrix(MatrixList matrix)
        {
            int[,] newMatrix = new int[matrix.Lenght, matrix.Count];
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix.Elem(j, i);
                }
            }
            return GetMatrix(newMatrix);
        }
        public static MatrixList SumMatrix(MatrixList matrix1, MatrixList matrix2)
        {
            if (matrix1.Count != matrix2.Count || matrix1.Lenght != matrix2.Lenght)
            {
                return null;
            }
            int[,] sumMatrix = new int[matrix1.Count, matrix1.Lenght];
            for (int i = 0; i < sumMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sumMatrix.GetLength(1); j++)
                {
                    sumMatrix[i, j] = matrix1.Elem(i, j) + matrix2.Elem(i, j);
                }
            }
            return GetMatrix(sumMatrix);
        }
        public static MatrixList MultiplicationMatrix(MatrixList matrix1, MatrixList matrix2)
        {
            if (matrix1.Lenght != matrix2.Count)
            {
                return null;
            }
            int[,] MultiplicationMatrix = new int[matrix1.Count, matrix2.Lenght];
            for (int i = 0; i < MultiplicationMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < MultiplicationMatrix.GetLength(1); j++)
                {

                    MultiplicationMatrix[i, j] = 0;
                    for (int k = 0; k < matrix1.Lenght; k++)
                        MultiplicationMatrix[i, j] += matrix1.Elem(i, k) * matrix2.Elem(k, j);
                }
            }
            return GetMatrix(MultiplicationMatrix);
        }
        static void Main(string[] args)
        {
            MatrixList matrixList1 = new MatrixList();
            MatrixList matrixList2 = new MatrixList();
            Console.WriteLine("Enter the number of rows:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix1 = new int[n, m];
            Console.WriteLine("Enter the number of rows:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int m1 = int.Parse(Console.ReadLine());
            int[,] matrix2 = new int[n1, m1];

            MatrixFilling(ref matrix1, ref matrixList1);
            MatrixFilling(ref matrix2, ref matrixList2);
            Console.WriteLine("Matrix1:");
            matrixList1.PrintMatrix();
            Console.WriteLine("Matrix2:");
            matrixList2.PrintMatrix();

            Console.WriteLine("Transpose Matrix1:");
            TransposeMatrix(matrixList1).PrintMatrix();
            Console.WriteLine("Transpose Matrix2:");
            TransposeMatrix(matrixList2).PrintMatrix();

            Console.WriteLine("Sum matrix:");
            if (SumMatrix(matrixList1, matrixList2) == null)
                Console.WriteLine("For summation, matrices of the same size are needed");
            else
                SumMatrix(matrixList1, matrixList2).PrintMatrix();

            Console.WriteLine("Multiply matrix:");
            if (MultiplicationMatrix(matrixList1, matrixList2) == null)
                Console.WriteLine("To multiply marices, it is necessary that the number of columns of the first matrix is equal to the number of rows of the second");
            else
                MultiplicationMatrix(matrixList1, matrixList2).PrintMatrix();
            Console.ReadKey();
        }
    }
}
