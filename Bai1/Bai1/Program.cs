using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Program
    {
        public static void Nhap(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("A[{0},{1}]=", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }
        public static void Xuat(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        public static int CheoChinh(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
                tong += a[i, i];
            return tong;
        }
        public static int CheoPhu(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (j == n - 1 - i) tong += a[i, j];
            return tong;
        }

        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Nhap n=");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 2 || n > 20);
            int[,] a = new int[n, n];
            Nhap(a, n);
            Xuat(a, n);
            int m = n + 1;
            int[,] b;
            do
            {
                m--;
                b = new int[m, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if(n-i>=m && n-j>=m && m > 1)
                        {
                            for (int x = 0; x < m; x++)
                                for (int y = 0; y < m; y++)
                                    b[x, y] = a[i + x, y + j];
                            if (CheoChinh(b, m) == CheoPhu(b, m)) goto kq;
                        }
                    }
            } while (m > 1);

        kq:
            Console.WriteLine("Ma tran can tim:");
            Xuat(b, m);
            Console.ReadKey();
        }
    }
}
