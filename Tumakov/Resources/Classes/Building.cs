namespace Tumakov
{
    public class Building
    {
        private static uint _buildCount = 10;
        private uint _buildNum;
        private uint _height;
        private byte _floorsQuantity;
        private uint _apartmentsQuantity;
        private byte _entrantsQuantity;

        public uint BuildNum => _buildNum;
        public uint Height => _height;
        public byte FloorsQuantity => _floorsQuantity;
        public uint ApartmentQuantity => _apartmentsQuantity;
        public byte EntrantsQuantity => _entrantsQuantity;

        public Building() { }
        public Building(uint? BuildNum, uint Height, byte FloorsQuantity, uint ApartmentsQuantity, byte EntrantsQuantity)
        {
            _buildNum = BuildNum ?? GetAutoNumber();
            _height = Height;
            _floorsQuantity = FloorsQuantity;
            _apartmentsQuantity = ApartmentsQuantity;
            _entrantsQuantity = EntrantsQuantity;
        }

        private static uint GetAutoNumber()
        {
            _buildCount++;
            return _buildCount;
        }

        public void PrintOnConsole()
        {
            Console.WriteLine($"Номер здания - {_buildNum} \nВысота - {_height} \nКоличество этажей - {_floorsQuantity} \nКоличество квартир - {_apartmentsQuantity} \nКоличество подъездов - {_entrantsQuantity}");
        }

        public double FloorHeight()
        {
            return (_height / _floorsQuantity);
        }
        public uint apartmentsInEntrants()
        {
            return (_apartmentsQuantity / _entrantsQuantity);
        }
        public byte apartmentsInFloors()
        {
            return (byte)(_apartmentsQuantity / _floorsQuantity);
        }
    }
}