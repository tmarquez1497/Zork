using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Zork
{
    class Program
    {
        static Program()
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                RoomMap[room.Name] = room;
            }
        }

        private static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
            
        }

        //Main Function
        static void Main(string[] args)
        {
            const string defaultRoomsFilename = "Rooms.txt";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);
            
           
            InitializeRoomDescription(roomsFilename);
            
            
            
            Console.WriteLine("Welcome to Zork!");

            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);

                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
                        break;

                    //Fall-Through Cases
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false) 
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
                       

                    default:
                        Console.WriteLine("Unknown command");
                        break;


                }


            }   

        }

           
       


        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }

        //Move Commands - Tracks Players Movement and Returns a bool to tell if movement was successful
        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction.");

            bool isValidMove = true;

            switch (command)
            {

                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;


                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                     break;
                   

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break; 
                   

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;
                    

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }


        private static bool IsDirection(Commands command) => Directions.Contains(command);

        //private static readonly Dictionary<string, Room> RoomMap;

        private static readonly Dictionary<string, Room> RoomMap;

        private enum Fields
        {
            Name = 0,
            Description = 1
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0,
            
        }

        private static void InitializeRoomDescription(string roomsFilename)
        {
            var rooms = JsonConvert.DeserializeObject<Room[]>(File.ReadAllText(roomsFilename));
            foreach (Room room in rooms)
            {
                RoomMap[room.Name].Description = room.Description;
            }
            
        }




        private static Room[,] Rooms;
       /* {
            {new Room("Rocky Trail"),   new Room("South of House"),     new Room ("Canyon View")    },  
            {new Room("Forest"),        new Room("West of House"),      new Room("Behind House")    },        
            {new Room("Dense Woods"),   new Room("North of House"),     new Room("Clearing")        }       

          };
         */

        private static (int Row, int Column) Location = (1, 1);

        private static readonly List<Commands> Directions = new List<Commands>
        {
                Commands.NORTH,
                Commands.SOUTH,
                Commands.EAST,
                Commands.WEST
        };

       

    } 
    
}




        
        

     












      
    

            
    
        
    

    
