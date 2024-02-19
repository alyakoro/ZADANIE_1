using System;

namespace ZADANIE_1
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (exit != true)
            {
                VvodCoordinat();

                Console.Write(Environment.NewLine + 
                    "Введите 'exit' для выхода: " + 
                    Environment.NewLine);
                string exitword = Console.ReadLine();
                if (exitword == "exit")
                    exit = true;
            }
        }

        
        // Функция рисование шахматной доски.
        static void DrawChessboard(
            int LX, 
            int LY, 
            int FX, 
            int FY)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write((i) + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if (j == LX && i == LY)
                        Console.Write("L ");
                    else if (j == FX && i == FY)
                        Console.Write("F ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }

        // Функция ввода и проверки данных.
        static void VvodCoordinat()
        {
            bool vvod_reght = false;
            do
            {
                Console.Write("Введите координаты ладьи(L) " +
                    "и фигуры(F) (например, a1 b3): ");
                string coordinat_fig = Console.ReadLine();

                string[] coordinat = coordinat_fig.Split(' ');
                
                if ((coordinat.Length == 2) && 
                    (coordinat[0] != coordinat[1]))
                {
                    string ladiaPosition = coordinat[0];
                    string figurePosition = coordinat[1];

                    if (CorrectPosition(ladiaPosition) &&
                        CorrectPosition(figurePosition))
                    {
                        vvod_reght = true;
                        SravnrniePossision(ladiaPosition,
                            figurePosition);
                    }
                }

            } while(vvod_reght != true);
        }

        // Функция сравнения координаты ладьи и фигуры.
        static void SravnrniePossision(string ladia, 
            string figure)
        {
            // Нахождение координат ладьи и фигуры.
            int ladiaX = ladia[0] - 'a' + 1;
            int ladiaY = ladia[1] - '0';
            int figureX = figure[0] - 'a' + 1;
            int figureY = figure[1] - '0';

            DrawChessboard(ladiaX, ladiaY, figureX, figureY);

            if (ladiaX == figureX || ladiaY == figureY)
                Console.WriteLine("Ладья сможет побить фигуру");
            else
                Console.WriteLine("Ладья не сможет побить фигуру");
        }
        
        // Функция проверки на правильность ввода:
        //1. Количество символов.
        //2. Пределы (a-h) и (1 - 8).
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char bokva = position[0];
            char numer = position[1];

            return bokva >= 'a' && bokva <= 'h' 
                && numer >= '1' && numer <= '8';
        }
    }
}
