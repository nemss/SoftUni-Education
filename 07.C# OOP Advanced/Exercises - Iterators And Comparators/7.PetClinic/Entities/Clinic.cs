namespace _7.PetClinic.Entities
{
    using System;
    using System.Text;

    public class Clinic
    {
        private int roomsNumber;
        private RoomRegister roomRegister;
        private int occupiedRooms;
        public Clinic(string name, int roomsNumber)
        {
            this.Name = name;
            this.roomsNumber = roomsNumber;
            this.roomRegister = new RoomRegister(roomsNumber);
            this.occupiedRooms = 0;
        }

        public string Name { get; private set; }

        public int Roomsnumber
        {
            get { return this.Roomsnumber; }
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.roomsNumber = value;
            }
        }

        public bool TryAddPet(Pet currentPet)
        {
            foreach (var roomIndex in this.roomRegister)
            {
                if (this.roomRegister[roomIndex] == null)
                {
                    this.roomRegister[roomIndex] = currentPet;
                    this.occupiedRooms++;
                    return true;
                }
            }

            return false;
        }

        public bool TryReleasePet()
        {
            var centralRoomIndex = this.Roomsnumber / 2;
            for (int i = 0; i < Roomsnumber; i++)
            {
                var currentIndex = (centralRoomIndex + i) % this.Roomsnumber;
                if (this.roomRegister[currentIndex] != null)
                {
                    this.roomRegister[currentIndex] = null;
                    this.occupiedRooms--;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.occupiedRooms < this.roomsNumber;
        }

        public string Print()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Roomsnumber; i++)
            {
                sb.AppendLine(this.Print(i));
            }

            return sb.ToString().Trim();
        }

        public string Print(int roomIndex)
        {
            return this.roomRegister[roomIndex]?.ToString() ?? "Room empty";
        }
    }
}
