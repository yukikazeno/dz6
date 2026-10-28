namespace Latypova
{
    public abstract class Waste
    {
        private readonly string _name;
        private double _weight;
        private readonly DangerLevel _dangerLevel;
        public DateTime arrivalDate;

        public string Name => _name;
        public double Weight
        { 
            get => _weight;
            set
            {
                if (value >= 0) _weight = value;
                else Console.WriteLine("Вес не может быть отрицательным!!!");
            }
        }
        public DangerLevel DangerLevel => _dangerLevel;
        
        protected Waste(string Name, double Weight, DangerLevel DangerLevel)
        {
            _name = string.IsNullOrWhiteSpace(Name) ? "Неизвестный мусор!" : Name;
            _weight = Weight;
            _dangerLevel = DangerLevel;
            arrivalDate = DateTime.Now;
        }

        public abstract double GetVolume();
        public virtual bool IsHazardous()
        {
            return (_dangerLevel == DangerLevel.Среднеопасные) || (_dangerLevel == DangerLevel.Высокоопасные);
        }

        public virtual string GetInfo()
        {
            return $"[{Name}] Вес: {Weight} кг \nКласс опасности: {DangerLevel} \nДата: {arrivalDate.ToShortDateString()}";
        }

        public void ChangeWeight(double extraWeight)
        {
            Weight += extraWeight;
            Console.WriteLine($"[Система]: Вес объекта '{Name}' изменен. Новый вес: {Weight} кг.");
        }

        public double CalculateStorageCost(int days)
        {
            return _weight * (int)_dangerLevel * days * 1.5;
        }
    }
}
