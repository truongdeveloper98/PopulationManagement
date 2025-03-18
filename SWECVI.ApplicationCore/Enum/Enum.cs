namespace SWECVI.ApplicationCore
{
    public class Enum
    {
        public enum Gender
        {
            UnKnow = 0,
            Male = 1,
            Female = 2,
            Unknown = 3,
        }
        public enum Date
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6,
        }
        public enum BuildingStatus
        {
            Open = 0,
            Close = 1,
        }
        public enum StatusApartment
        {
            Empty = 0,
            UnderRenovation = 1,
            WaitReceive = 2,
            Living = 3,
            TemporarilyAbsent = 4
        }
        public enum RelationShip
        {
            Host = 0,
            Wife = 1,
            Children = 2,
            Dad = 3,
            Mom = 4,
            GrandFa = 5,
            GrandMa = 6
        }
        public enum TypeOfService
        {
            Manager = 0,
            Electric = 1,
            Water = 2,
            Vehicle = 3,
            Others = 4,
        }
        public enum TypeOfObject
        {
            Company = 0,
            Manager = 1,
            ProjectOwner = 2,
            CollectionService = 3,
        }
        public enum TypeOfFee
        {
            OneFee = 0,
            Progressive = 1,
            Population = 2,
            Norm = 3,
        }
        public enum Cycle
        {
            OneMonth = 0,
            TwoMonth = 1,
            ThreeMonth = 2,
        }
        public enum PriceCalculationMethod
        {
            OneMonth = 0,
            HalfMonth = 1
        }
        public enum TypeOfVehicle
        {
            Car = 0,
            Bike = 1,
            MotorBike = 2,
            ElectricBike = 3
        }
        public enum VehicleColor
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Yellow = 3,
            Purple = 4,
            Black = 5,
            White = 6,
        }
        public enum FeeLevel
        {
            BikeFee = 0,
            CarFee = 1,
            MotorBikeFee = 2,
            ElectricFee = 3,
        }
    }
}
