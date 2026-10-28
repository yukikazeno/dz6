namespace Latypova
{
    public class FieldManager
    {
        public string Name;
        public List<Waste> ActiveWaste = new List<Waste>();

        public FieldManager(string name)
        {
            Name = name;
        }

        public void AddWaste(Waste waste)
        {
            ActiveWaste.Add(waste);
            Console.WriteLine($"[Свалка]: Принят новый груз -> {waste.Name}");
        }

        public void ShowReport()
        {
            Console.WriteLine($"\nОтчет по объекту: {Name}");
            double totalWeight = 0;
            double totalVolume = 0;

            foreach (var waste in ActiveWaste)
            {
                Console.WriteLine(waste.GetInfo());
                totalWeight += waste.Weight;
                totalVolume += waste.GetVolume();
            }

            Console.WriteLine($"Всего мусора на свалке: {totalWeight:F2} кг.");
            Console.WriteLine($"Занимаемый объем: {totalVolume:F2} м^3.");
        }
    }
}
