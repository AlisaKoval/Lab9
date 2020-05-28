using System;

namespace Lab9._8.a
{
    class Program
    {
        public static void MatrixFilling( ref int[,] matrix)
        {
            Random rnd = new Random();
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(2);
                }
            }
        }
        public static void PrintMatrix (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int[,] TransposeMatrix (int[,] matrix)
        {
            int[,] newMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[j, i];
                }
            }
            return newMatrix;
        }
        public static int[,] SumMatrix(int[,] matrix1, int [,] matrix2)
        {
            if (matrix1.GetLength(0)!= matrix2.GetLength(0)|| matrix1.GetLength(1)!= matrix2.GetLength(1))
            {
                return null;
            }
                int[,] sumMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < sumMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sumMatrix.GetLength(1); j++)
                {
                    sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return sumMatrix;
        }
        public static int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                return null;
            }
            int[,] MultiplicationMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < MultiplicationMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < MultiplicationMatrix.GetLength(1); j++)
                {

                    MultiplicationMatrix[i,j] = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                        MultiplicationMatrix[i,j] += matrix1[i, k] * matrix2[k, j];
                }
            }
            return MultiplicationMatrix;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix1 = new int[n, m];
            MatrixFilling( ref matrix1);
            Console.WriteLine("Enter the number of rows:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int m1 = int.Parse(Console.ReadLine());
            int[,] matrix2 = new int[n1, m1];
            MatrixFilling( ref matrix2);
            Console.WriteLine("Matrix1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Matrix2:");
            PrintMatrix(matrix2);
            Console.WriteLine("Transpose Matrix1:");
            PrintMatrix(TransposeMatrix(matrix1));
            Console.WriteLine("Transpose Matrix2:");
            PrintMatrix(TransposeMatrix(matrix2));
            Console.WriteLine("Sum matrix:");
            if (SumMatrix(matrix1, matrix2) == null)
                Console.WriteLine("For summation, matrices of the same size are needed");
            else
                PrintMatrix(SumMatrix(matrix1, matrix2));
            Console.WriteLine("Multiply matrix:");
            if (MultiplicationMatrix(matrix1, matrix2) == null)
                Console.WriteLine("To multiply marices, it is necessary that the number of columns of the first matrix is equal to the number of rows of the second");
            else
                PrintMatrix(MultiplicationMatrix(matrix1, matrix2));
            Console.ReadKey();
        }
    }
}
