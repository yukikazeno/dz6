namespace Latypova
{
    internal class RecyclableWaste : Waste
    {
        public string MaterialType;
        public bool IsClean;

        double approximateDensity = 150.0;
        double pressingCoefficient = 0.8;
        double cleanWasteCoefficient = 12.5;
        double dirtyWasteCoefficient = 5.0;

        public RecyclableWaste(string name, double weight)
            : base(name, weight, (DangerLevel)1)
        {
            MaterialType = "Общий пластик/бумага";
            IsClean = true;
        }

        public RecyclableWaste(string name, double weight, string materialType, bool isClean)
            : base(name, weight, (DangerLevel)1)
        {
            MaterialType = materialType;
            IsClean = isClean;
        }
        
        public override double GetVolume() => Weight / approximateDensity;

        public override string GetInfo()
        {
            string cleanStatus = IsClean ? "Чистый" : "Грязный";
            return base.GetInfo() + $"\nТип: {MaterialType} ({cleanStatus})";
        }

        public void SendToRecycle()
        {
            if (IsClean)
            {
                Console.WriteLine($"Отходы '{Name}' успешно отправлены на завод переработки {MaterialType}!");
            }
            else
            {
                Console.WriteLine($"'{Name}' слишком грязный. Требуется предварительная очистка.");
            }
        }

        public void Compress()
        {
            Console.WriteLine($"Прессование '{Name}'...");
            Weight *= pressingCoefficient;
        }

        public double GetRecyclingValue()
        {
            return IsClean ? Weight * cleanWasteCoefficient : Weight * dirtyWasteCoefficient;
        }
    }
}
