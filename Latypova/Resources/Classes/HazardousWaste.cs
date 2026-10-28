namespace Latypova
{
    internal class HazardousWaste : Waste
    {
        public string ChemicalComposition;
        public int ContainerId;

        public HazardousWaste(string name, double weight, DangerLevel dangerLevel)
            : base(name, weight, dangerLevel)
        {
            ChemicalComposition = "Неизвестные токсины";
            ContainerId = 0;
        }

        public HazardousWaste(string name, double weight, DangerLevel dangerLevel, string chemical, int containerId)
            : base(name, weight, dangerLevel)
        {
            ChemicalComposition = chemical;
            ContainerId = containerId;
        }

        public override double GetVolume() => (Weight / 800.0) * 2.5;

        public override bool IsHazardous() => true;

        public override string GetInfo()
        {
            return base.GetInfo() + $"\nТОКСИЧНО! Состав: {ChemicalComposition}, Контейнер №{ContainerId}";
        }

        public void CheckContainerIntegrity()
        {
            if (ContainerId == 0)
                Console.WriteLine($"ВНИМАНИЕ! '{Name}' хранится БЕЗ специального контейнера!");
            else
                Console.WriteLine($"Контейнер No.{ContainerId} для '{Name}' проверен. Утечек нет.");
        }

        public void Utilize()
        {
            Console.WriteLine($"Объект '{Name}' ({ChemicalComposition})залит бетоном в бункере.");
            Weight = 0;
        }
    }
}
