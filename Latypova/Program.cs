namespace Latypova
{
    class Program
    { 
        static FieldManager FileReader(string filePath, string fieldName)
        {
            FieldManager landfill = new FieldManager(fieldName);


            string[] fileLines = File.ReadAllLines(filePath);

            foreach (var line in fileLines)
            {
                string[] parts = line.Split(';');
                if (parts[0] == "RECYCLABLE")
                {
                    string name = parts[1];
                    double weight = double.Parse(parts[2]);
                    string material = parts[3];
                    bool isClean = bool.Parse(parts[4]);

                    landfill.AddWaste(new RecyclableWaste(name, weight, material, isClean));
                }
                else if (parts[0] == "HAZARDOUS")
                {
                    string name = parts[1];
                    double weight = double.Parse(parts[2]);
                    int danger = int.Parse(parts[3]);
                    string chemical = parts[4];
                    int containerId = int.Parse(parts[5]);
                    landfill.AddWaste(new HazardousWaste(name, weight, (DangerLevel)danger, chemical, containerId));
                }
            }
            return landfill;
        }

        static void ShowHeirsMethods(FieldManager myLandfill)
        {
            foreach (var waste in myLandfill.ActiveWaste)
            {
                if (waste is RecyclableWaste recWaste)
                {
                    recWaste.Compress();
                    recWaste.SendToRecycle();
                    Console.WriteLine($"Потенциальная выгода: {recWaste.GetRecyclingValue()} руб.");
                }
                else if (waste is HazardousWaste hazWaste)
                {
                    hazWaste.CheckContainerIntegrity();
                    if (hazWaste.ContainerId == 0)
                    {
                        Console.WriteLine("Срочно принимаем меры безопасности!");
                        hazWaste.Utilize();
                    }
                }
                Console.WriteLine($"Стоимость хранения за неделю: {waste.CalculateStorageCost(7):F2} руб. \n");
            }

            Console.WriteLine("Состояние свалки после обработки мусора: ");
            myLandfill.ShowReport();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string filePath = args[0];

            FieldManager myLandfill = FileReader(filePath, "Центральный Полигон г. Казань");
            myLandfill.ShowReport();

            ShowHeirsMethods(myLandfill);
        }
    }
}