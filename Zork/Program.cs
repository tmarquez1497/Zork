using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine();

           
            //Module 3 - Finding Your Direction
            Commands command = ToCommand(inputString.Trim());
            Console.WriteLine(command);
            

        }


        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        
            //Commands command;
            //switch (commandString)
            //{
                //    if (commandString == "QUIT")
                //{
                //    command = Commands.QUIT;
                //}
                //else if (commandString == "LOOK")
                //{
                //    command = Commands.LOOK;
                //}
                //else if (commandString == "NORTH")
                //{
                //    command = Commands.NORTH;
                //}
                //else if (commandString == "SOUTH")
                //{
                //    command = Commands.SOUTH;
                //}
                //else if (commandString == "EAST")
                //{
                //    command = Commands.EAST;
                //}
                //else if (commandString == "WEST")
                //{
                //    command = Commands.WEST;
                //}
                //else
                //{
                //    command = Commands.UNKNOWN;
                //}

                //return command;
                //    case "QUIT":
                //        command = Commands.QUIT;
                //        break;

                //    case "LOOK":
                //        command = Commands.LOOK;
                //        break;

                //    case "NORTH":
                //        command = Commands.NORTH;
                //        break;

                //    case "SOUTH":
                //        command = Commands.SOUTH;
                //        break;

                //    case "EAST":
                //        command = Commands.EAST;
                //        break;

                //    case "WEST":
                //        command = Commands.WEST;
                //        break;

                //    default:
                //        command = Commands.UNKNOWN;
                //        break;
                //};

                //return command;
                //if(Enum.TryParse<Commands>(commandString, true, out Commands result))
                //{
                //   return result;
                //}
                //else
                //{
                //    return Commands.UNKNOWN;
                //}

            
       
        
           

    }
}













      
    

            
    
        
    

    
