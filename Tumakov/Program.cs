namespace Tumakov
{ 
    class Program
    {
        static public BankAcc CreateAcc()
        {
            Console.Write("Введите данные счета \nНомер счета (если хотите сгенерировать номер автоматически нажмите Enter)");
            ulong? accNumber = ulong.TryParse(Console.ReadLine(), out ulong nu) ? nu : null;
            Console.Clear();
            Console.WriteLine("Выберите тип счета: \n1 - Сберегательный \n2 - Кредитный \n3 - Накопительный \n4 - Депозитный \n5 - Расчетный");
            AccType accType = (AccType)(int.TryParse(Console.ReadLine(), out int ty) ? ty : 0);
            Console.Clear();
            Console.Write("Введите текущий баланс: ");
            decimal balance = decimal.TryParse(Console.ReadLine(), out decimal bal) ? bal : 0;
            Console.Clear();
            BankAcc accOut = new BankAcc(accNumber, accType, balance);
            return accOut;

        }

        static public Building CreateBuilding()
        {
            Console.Write("Введите параметры здания \nНомер здания (если хотите задать автоматически - нажмите Enter: ");
            uint? buildNum = uint.TryParse(Console.ReadLine(), out uint num) ? num : null;
            Console.Clear();
            Console.Write("Введите высоту здания: ");
            uint height = uint.TryParse(Console.ReadLine(), out uint hght) ? hght : 0;
            Console.Clear();
            Console.Write("Введите количество этажей: ");
            byte floorsQuantity = byte.TryParse(Console.ReadLine(), out byte flrs) ? flrs : (byte)0;
            Console.Clear();
            Console.Write("Введите количество квартир: ");
            uint apartmentsQuantity = uint.TryParse(Console.ReadLine(), out uint aprts) ? aprts : 0;
            Console.Clear();
            Console.Write("Введите количество подъездов: ");
            byte entrantsQuantity = byte.TryParse(Console.ReadLine(), out byte entrs) ? entrs : (byte)0;
            Console.Clear();
            Building buildOut = new Building(buildNum, height, floorsQuantity, apartmentsQuantity, entrantsQuantity);
            return buildOut;
        }

        static void Classwork()
        {
            Console.WriteLine("Создание счета Тестика");
            BankAcc testikAcc = CreateAcc();

            Console.WriteLine("Информация о счете гражданина Тестика:");
            testikAcc.DisplayInfo();
            Console.Write("Введите сумму пополнения счета Тестика: ");
            decimal putCash = decimal.TryParse(Console.ReadLine(), out decimal cash) ? cash : 0m;
            testikAcc.PutMoney(putCash);

            Console.Write("Введите сумму снятия средств со счета Тестика: ");
            decimal takeCash = decimal.TryParse(Console.ReadLine(), out decimal money) ? money : 0m;
            testikAcc.TakeMoney(putCash);

            Console.WriteLine("Информация о счете Тестика после пополнения и снятия:");
            testikAcc.DisplayInfo();
            Console.ReadKey();
            Console.Clear();
        }

        static void Homework()
        {
            Console.WriteLine("Создание здания");
            Building exampleBuilding =  CreateBuilding();
            exampleBuilding.PrintOnConsole();
            Console.WriteLine();

            double flrHeight = exampleBuilding.FloorHeight();
            uint aprtInEntrant = exampleBuilding.apartmentsInEntrants();
            byte aprtsOnFlr = exampleBuilding.apartmentsInFloors();
            Console.WriteLine($"Другие параметры здания: \nВысота одного этажа - {flrHeight} \nКоличество квартир в подъезде - {aprtInEntrant} \nКоличество квартир - {aprtsOnFlr}");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            byte runningFlag = 1;
            while (runningFlag == 1)
            {
                Console.WriteLine("Введите номер действия: \n1 - Задание из лабораторной работы \n2 - Домашнее задание \n0 - Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        Classwork();
                        break;
                    case "2":
                        Homework();
                        break;
                    case "0":
                        runningFlag = 0;
                        break;
                    default:
                        Console.WriteLine("Неверное значение!!! Пожалуйста введите номер задания()");
                        break;
                }
            }
        }
    }
}