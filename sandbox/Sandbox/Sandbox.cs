using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHome
{
    abstract class SmartDevice
    {
        public string Name { get; }
        private bool IsOn { get; set; }
        private DateTime? TurnedOnTime { get; set; }

        protected SmartDevice(string name)
        {
            Name = name;
            IsOn = false;
            TurnedOnTime = null;
        }

        public void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                TurnedOnTime = DateTime.Now;
                Console.WriteLine($"{Name} is turned on.");
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                TurnedOnTime = null;
                Console.WriteLine($"{Name} is turned off.");
            }
        }

        public bool IsDeviceOn()
        {
            return IsOn;
        }

        public TimeSpan? GetTimeOn()
        {
            if (IsOn && TurnedOnTime.HasValue)
            {
                return DateTime.Now - TurnedOnTime.Value;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Name} (On: {IsOn})";
        }
    }

    class SmartLight : SmartDevice
    {
        public SmartLight(string name) : base(name) { }
    }

    class SmartHeater : SmartDevice
    {
        public SmartHeater(string name) : base(name) { }
    }

    class SmartTV : SmartDevice
    {
        public SmartTV(string name) : base(name) { }
    }

    class Room
    {
        public string Name { get; }
        private List<SmartDevice> Devices { get; }

        public Room(string name)
        {
            Name = name;
            Devices = new List<SmartDevice>();
        }

        public void AddDevice(SmartDevice device)
        {
            Devices.Add(device);
        }

        public void TurnOnAllLights()
        {
            foreach (var device in Devices.OfType<SmartLight>())
            {
                device.TurnOn();
            }
        }

        public void TurnOffAllLights()
        {
            foreach (var device in Devices.OfType<SmartLight>())
            {
                device.TurnOff();
            }
        }

        public void TurnOnDevice(string deviceName)
        {
            var device = Devices.FirstOrDefault(d => d.Name == deviceName);
            device?.TurnOn();
        }

        public void TurnOffDevice(string deviceName)
        {
            var device = Devices.FirstOrDefault(d => d.Name == deviceName);
            device?.TurnOff();
        }

        public void TurnOnAllDevices()
        {
            foreach (var device in Devices)
            {
                device.TurnOn();
            }
        }

        public void TurnOffAllDevices()
        {
            foreach (var device in Devices)
            {
                device.TurnOff();
            }
        }

        public void ReportAllItems()
        {
            Console.WriteLine($"Room: {Name}");
            foreach (var device in Devices)
            {
                Console.WriteLine(device);
            }
        }

        public void ReportAllItemsOn()
        {
            Console.WriteLine($"Room: {Name} - Devices On:");
            foreach (var device in Devices.Where(d => d.IsDeviceOn()))
            {
                Console.WriteLine(device);
            }
        }

        public void ReportItemOnLongest()
        {
            var longestOnDevice = Devices
                .Where(d => d.IsDeviceOn())
                .OrderByDescending(d => d.GetTimeOn())
                .FirstOrDefault();

            if (longestOnDevice != null)
            {
                Console.WriteLine($"Device on the longest: {longestOnDevice.Name} (Time On: {longestOnDevice.GetTimeOn()})");
            }
            else
            {
                Console.WriteLine("No devices are currently on.");
            }
        }
    }

    class House
    {
        private List<Room> Rooms { get; }

        public House()
        {
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void ReportAllRooms()
        {
            foreach (var room in Rooms)
            {
                room.ReportAllItems();
            }
        }

        public void ReportAllItemsOn()
        {
            foreach (var room in Rooms)
            {
                room.ReportAllItemsOn();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create devices
            var light1 = new SmartLight("Living Room Light");
            var heater1 = new SmartHeater("Living Room Heater");
            var tv1 = new SmartTV("Living Room TV");

            // Create room and add devices
            var livingRoom = new Room("Living Room");
            livingRoom.AddDevice(light1);
            livingRoom.AddDevice(heater1);
            livingRoom.AddDevice(tv1);

            // Create house and add rooms
            var house = new House();
            house.AddRoom(livingRoom);

            // Turn on some devices
            livingRoom.TurnOnDevice("Living Room Light");
            livingRoom.TurnOnDevice("Living Room TV");

            // Report all items in the living room
            livingRoom.ReportAllItems();

            // Report all items that are on
            house.ReportAllItemsOn();

            // Report the item that has been on the longest
            livingRoom.ReportItemOnLongest();
        }
    }
}
