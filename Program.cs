namespace SarmalHareketli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo Hareket; // SarmalOptimizeFinal'den alındı,
            Console.Write("\t-- Sarmal Matris --\n\n3 veya üzerinde tek sayı girebilirsiniz\nMatrisin boyutu (nxn) n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ortaya gelmesini istediniz sayı:");
            int OrtadakiSayi = Convert.ToInt32(Console.ReadLine());
            int[,] MainMatrix = new int[n, n];
            Console.Clear();
            do
            {
                Console.Write("\t-- Sarmal Matris --\t{0}x{0} Matris\n\n", n);
                int SayacDeg = OrtadakiSayi - n * n + 1, SatirSutunV2 = 0, Uyukseklik = MainMatrix.GetLength(0);
                MainMatrix[(int)MainMatrix.GetLength(0) / 2, (int)MainMatrix.GetLength(0) / 2] = OrtadakiSayi;
                for (int i = Uyukseklik; i >= 3; i -= 2)
                    Yazdir.MatrisKare(i, ref SayacDeg, ref MainMatrix, SatirSutunV2++);
                for (int k = 0; k < MainMatrix.GetLength(0); k++)
                {
                    for (int j = 0; j < MainMatrix.GetLength(1); j++)
                    {
                        if (MainMatrix[k, j] == 0)
                            Console.Write("{0}\t", MainMatrix[k, j], Console.ForegroundColor = ConsoleColor.Green);
                        else if (MainMatrix[k, j] % 2 == 0)
                            Console.Write("{0}\t", MainMatrix[k, j], Console.ForegroundColor = ConsoleColor.Cyan);
                        else
                            Console.Write("{0}\t", MainMatrix[k, j], Console.ForegroundColor = ConsoleColor.DarkMagenta);  
                        Console.ForegroundColor = ConsoleColor.White;
                    }  
                    Console.WriteLine("\n");
                }
                Hareket = Console.ReadKey();
                switch (Hareket.Key)
                {
                    case ConsoleKey.A: OrtadakiSayi++; break;
                    case ConsoleKey.D: OrtadakiSayi--; break;
                }
                Console.Clear();
            } while (Hareket.Key == ConsoleKey.A || Hareket.Key == ConsoleKey.D);
        }
    }
    class Yazdir
    {
        public static void MatrisKare(int UYukseklik, ref int SayacDeg, ref int[,] MainMatrix, int SatirSutun)
        {
            for (int durum = 0; durum < 4; durum++)
                switch (durum)
                {
                    case 0:
                        for (int i = 0; i < UYukseklik; i++)
                            MainMatrix[SatirSutun, i + SatirSutun] = SayacDeg++;
                        break;
                    case 1:
                        for (int i = 0; i < UYukseklik - 1; i++)
                            MainMatrix[i + SatirSutun + 1, SatirSutun + UYukseklik - 1] = SayacDeg++;
                        break;
                    case 2:
                        for (int i = MainMatrix.GetLength(0) - SatirSutun - 2; i >= SatirSutun; i--)
                            MainMatrix[SatirSutun + UYukseklik - 1, i] = SayacDeg++;
                        break;
                    case 3:
                        for (int i = MainMatrix.GetLength(0) - SatirSutun - 2; i > SatirSutun; i--)
                            MainMatrix[i, SatirSutun] = SayacDeg++;
                        break;
                }
        }
    }
}