using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base1_Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Введите тип прогрессии: 1 - арифметическая, 2 - геометрическая?: ");
            string numberofProgress = Console.ReadLine();
            Console.Write(" Установите начальное значение числа х прогрессии: ");
            int startNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Установите значение числа членов n прогрессии: ");
            uint nNumber = Convert.ToUInt32(Console.ReadLine());
            Console.Write(" Установите значение шага d прогрессии: ");
            int nSteps = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ************************************************************************");

            if (numberofProgress is "1")
            {
                ArithProgression arithProgression = new ArithProgression();
                arithProgression.step=nSteps;
                arithProgression.setStart(startNumber);
                Console.WriteLine(" 1 член арифметической прогрессии = {0}", startNumber);
                for (int i = 2; i < nNumber+1; i++)
                {
                    Console.WriteLine(" {0} член арифметической  прогрессии = {1}", i, arithProgression.getNext());
                }

            }
            else
            {
                if (numberofProgress is "2")
                {
                    GeomProgression geomProgression = new GeomProgression(nSteps, startNumber);
                    geomProgression.step = nSteps;
                    geomProgression.setStart(startNumber);
                    Console.WriteLine(" 1 член геометрической прогрессии = {0}", geomProgression.start);
                    for (int i = 2; i < nNumber + 1; i++)
                    {
                        {
                            Console.WriteLine(" {0} член арифметической  прогрессии = {1}", i, geomProgression.getNext());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Ошибка!Неверный формат ввода типа прогрессии!Прерывание");
                }
            }
            Console.ReadKey();
        }
    }
    public interface ISeries
    {
        void setStart(int x);
        int getNext();
        void reset();
    }
    class ArithProgression : ISeries
    {
        public int step;
        public int result;
        public int start;

        public int getNext()
        {
            result += step;
            return result;
        }

        public void reset()
        {
            result = start;
        }

        public void setStart(int x)
        {
            start = x;
            result = start;
        }
    }
    class GeomProgression : ISeries
    {
        public int step;
        public int result;
        public int start;
        public int Step
        {
            set
            {
                if (value > 0 | value < 0)
                {
                    step = value;
                }
                else
                {
                    Console.WriteLine(" Ошибка!Шаг геометрической прогрессии не может быть = 0!Прерывание.");
                }
            }
            get
            {
                return step;
            }
        }
        public int Start
        {
            set
            {
                if (value > 0 | value < 0)
                {
                    start = value;
                }
                else
                {
                    Console.WriteLine(" Ошибка!начальное значение геометрической прогрессии не может быть = 0!Прерывание.");
                }
            }
            get
            {
                return start;
            }
        }
        public GeomProgression (int step, int start)
        {
            this.Step = step;
            this.Start = start;
        }
        public int getNext()
        {
            result = result*step;
            return result;
        }

        public void reset()
        {
            result = start;
        }

        public void setStart(int x)
        {
            start = x ;
            result = start;
        }
    }
}
