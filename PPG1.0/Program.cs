using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace PPG1._0
{
    public class Program
    {
        // Create parking information
        public static string[] info = new string[100];
        public static int x;
        public static string X;
        public static string vehicleType;
        public static string type;
        public static string newType;
        public static string newParking;
        public static string regNumber;
        public static double a;
        public static int index = 0;
        public static int looper;
        public static int currentParking;
        public static int newIndex;
        public static int mcParking;
        public static int len;
        private static bool fail = false;
        public static bool fullCheck = false;


        public static void Main()
        {
            if (fail != true)
            {
                for (index = 0; index < info.Length; index++)
                {
                    info[index] = "0//";
                }
            }
            fail = true;
            ClearConsole();
            //Add the logo here with padding to the right
            Console.WriteLine("".PadRight(10) + "Welcome to Prague Parking Garage");
            Console.WriteLine("".PadRight(10) + "Open Daily from 04 - 00");
            Console.WriteLine();
            Console.WriteLine("".PadRight(10) + "What would you like to do today?");
            Console.WriteLine("".PadRight(10) + "1. Park Vehicle: ");
            Console.WriteLine("".PadRight(10) + "2. Move Vehicle: ");
            Console.WriteLine("".PadRight(10) + "3. Search For Vehicle: ");
            Console.WriteLine("".PadRight(10) + "4. Return Vehicle: ");
            Console.WriteLine("".PadRight(10) + "5. Check Status of garage: ");
            Console.WriteLine("".PadRight(10) + "6. Collect Vehicle Information: ");
            Console.WriteLine("".PadRight(10) + "7. Exit Program: ");
            Console.WriteLine();
            Console.Write("".PadRight(2) + "Choose: ");
            X = Console.ReadLine();
            Checker(X);
            x = int.Parse(X);
            if (x < 8 && x > 0)
            {
                switch (x)
                {
                    // ------------------------------------Park Vehicle menu----------------------------------
                    case 1:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Park Vehicle--");
                        Console.WriteLine("".PadRight(5) + "Please choose which vehicle you would like to park\n");
                        Console.WriteLine("".PadRight(5) + "1. Car: ");
                        Console.WriteLine("".PadRight(5) + "2. Motorcycle: ");
                        Console.WriteLine("".PadRight(5) + "3. Return to menu: ");
                        Console.WriteLine();
                        Console.Write("".PadRight(2) + "Choose: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 4 && x > 0)
                        {
                            switch (x)
                            {
                                // ----------------------------------------Park car ----------------------------------------
                                case 1:
                                    Console.Clear();
                                    looper = 4;
                                    Console.WriteLine("".PadRight(9) + "--Park Car--");
                                    Console.WriteLine("".PadRight(5) + "How would you would like to park it\n");
                                    Console.WriteLine("".PadRight(5) + "1. Next Available: ");
                                    Console.WriteLine("".PadRight(5) + "2. Your Chosen Spot: ");
                                    Console.WriteLine("".PadRight(5) + "3. Return to menu: ");
                                    Console.WriteLine();
                                    Console.Write("".PadRight(2) + "Choose: ");
                                    X = Console.ReadLine();
                                    Checker(X);
                                    x = int.Parse(X);
                                    if (x < 4 && x > 0)
                                    {
                                        Console.WriteLine("Please input RegNumber (Max 10 characters)");
                                        regNumber = (Console.ReadLine()).ToUpper();
                                        if (regNumber.Length <= 10)
                                        {
                                            
                                            switch (x)
                                            {
                                                case 1:
                                                    newIndex = FindNextAvai(looper);
                                                    if(newIndex == -1)
                                                    {
                                                        Console.WriteLine("Sorry all spots are full");
                                                        Console.ReadKey();
                                                        Main();
                                                    }
                                                    type = "4";
                                                    var separate = (info[newIndex]).Split("/");
                                                    separate[0] = type;
                                                    separate[1] = regNumber;
                                                    info[newIndex] = string.Join("/", separate);
                                                    Console.WriteLine("You car with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
                                                    Console.ReadKey();
                                                    Main();
                                                    break;
                                                case 2:
                                                    newIndex = YouChoose(looper);
                                                    if (newIndex == -1)
                                                    {
                                                        Console.WriteLine("Sorry all spots are full");
                                                        Console.ReadKey();
                                                        Main();
                                                    }
                                                    type = "4";
                                                    separate = (info[index]).Split("/");
                                                    separate[0] = type;
                                                    separate[1] = regNumber;
                                                    info[newIndex] = string.Join("/", separate);
                                                    Console.WriteLine("You car with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
                                                    Console.ReadKey();
                                                    Main();
                                                    break;
                                                case 3:
                                                    Main();
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Error();
                                        }

                                    }
                                    else
                                    {
                                        Error();
                                    }
                                    break;
                                // ----------------------------------------Park Motorcycle ----------------------------------------
                                case 2:
                                    Console.Clear();
                                    looper = 1;
                                    Console.WriteLine("".PadRight(9) + "--Park Motorbike--");
                                    Console.WriteLine("".PadRight(5) + "How would you would like to park it\n");
                                    Console.WriteLine("".PadRight(5) + "1. Next Available: ");
                                    Console.WriteLine("".PadRight(5) + "2. Your Chosen Spot: ");
                                    Console.WriteLine("".PadRight(5) + "3. Return to menu: ");
                                    Console.WriteLine();
                                    Console.Write("".PadRight(2) + "Choose: ");
                                    X = Console.ReadLine();
                                    Checker(X);
                                    x = int.Parse(X);
                                    if (x < 4 && x > 0)
                                    {
                                        Console.WriteLine("Please input RegNumber (Max 10 characters)");
                                        regNumber = (Console.ReadLine()).ToUpper();
                                        if (regNumber.Length <= 10)
                                        { 
                                            switch (x)
                                        {
                                            case 1:
                                                newIndex = FindNextAvai(looper);
                                                if (newIndex == -1)
                                                {
                                                    Console.WriteLine("Sorry all spots are full");
                                                    Console.ReadKey();
                                                    Main();
                                                }
                                                type = "1";
                                                var separate = (info[newIndex]).Split("/");
                                                mcParking = 1;
                                                if(separate[1].Length > 0)
                                                {
                                                    mcParking = 2;
                                                    type = "3";
                                                }
                                                separate[0] = type;
                                                separate[mcParking] = regNumber;
                                                info[newIndex] = string.Join("/", separate);
                                                Console.WriteLine("You Motorbike with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
                                                Console.ReadKey();
                                                Main();
                                                break;
                                            case 2:
                                                newIndex = YouChoose(looper);
                                                if (newIndex == -1)
                                                {
                                                    Console.WriteLine("Sorry all spots are full");
                                                    Console.ReadKey();
                                                    Main();
                                                }
                                                type = "1";
                                                separate = (info[newIndex]).Split("/");
                                                mcParking = 1;
                                                if (separate[1].Length > 0)
                                                {
                                                    mcParking = 2;
                                                    type = "3";
                                                }
                                                separate[0] = type;
                                                separate[mcParking] = regNumber;
                                                info[newIndex] = string.Join("/", separate);
                                                Console.WriteLine("You Motorbike with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
                                                Console.ReadKey();
                                                Main();
                                                break;
                                            case 3:
                                                Main();
                                                break;
                                        }
                                        }
                                    }
                                    else
                                    {
                                        Error();
                                    }
                                    break;
                                case 3:
                                    Main();
                                    break;
                            }
                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Move Vehicle menu----------------------------------
                    case 2:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Move Vehicle--");
                        Console.WriteLine("".PadRight(5) + "Please choose which vehicle you would like to move\n");
                        Console.WriteLine("".PadRight(5) + "1. Car: ");
                        Console.WriteLine("".PadRight(5) + "2. Motorcycle: ");
                        Console.WriteLine("".PadRight(5) + "3. Return to menu: ");
                        Console.WriteLine();
                        Console.Write("".PadRight(2) + "Choose: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 4 && x > 0)
                        {
                            switch (x)
                            {
                                // ----------------------------------------Move car ----------------------------------------
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("".PadRight(9) + "--Move Car--");
                                    Console.WriteLine("".PadRight(5) + "Which car would you like to move?\n");
                                    Console.WriteLine("".PadRight(5) + "1. Choose regnumber: ");
                                    Console.WriteLine("".PadRight(5) + "2. Return to menu: ");
                                    Console.WriteLine();
                                    X = Console.ReadLine();
                                    Checker(X);
                                    x = int.Parse(X);
                                    if (x < 3 && x > 0)
                                    {
                                        switch (x)
                                        {
                                            case 1:
                                                looper = 4;
                                                currentParking = SearchVehicle(looper);
                                                looper = 4;
                                                newIndex = ParkingSpotChecker(looper);
                                                if(newIndex == -1)
                                                {
                                                    Console.WriteLine("Sorry that spot is taken");
                                                    Console.ReadKey();
                                                    Main();
                                                }
                                                type = "4";
                                                info[currentParking] = "0//";
                                                var separate = (info[newIndex]).Split("/");
                                                separate[0] = type;
                                                separate[1] = regNumber;
                                                info[newIndex] = string.Join("/", separate);
                                                Console.WriteLine("You car with registration number {0} has been moved to the new spot {1}", regNumber, (newIndex + 1));
                                                Console.ReadKey();
                                                Main();
                                                break;
                                            case 2:
                                                Main();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Error();
                                    }
                                    break;
                                // ----------------------------------------Move Motorcycle ----------------------------------------
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("".PadRight(9) + "--Move Motorcycle--");
                                    Console.WriteLine("".PadRight(5) + "Which motorcycle would you like to move?\n");
                                    Console.WriteLine("".PadRight(5) + "1. Choose regnumber: ");
                                    Console.WriteLine("".PadRight(5) + "2. Return to menu: ");
                                    Console.WriteLine();
                                    Console.Write("".PadRight(2) + "Choose: ");
                                    X = Console.ReadLine();
                                    Checker(X);
                                    x = int.Parse(X);
                                    if (x < 3 && x > 0)
                                    {
                                        switch (x)
                                        {
                                            case 1:
                                                looper = 1;
                                                mcParking = SearchVehicle(looper);
                                                looper = 1;
                                                newIndex = ParkingSpotChecker(looper);
                                                if (newIndex == -1)
                                                {
                                                    Console.WriteLine("Sorry that spot is taken");
                                                    Console.ReadKey();
                                                    Main();
                                                }
                                                if (mcParking == -1)
                                                {
                                                    Console.WriteLine("Sorry We could not find your vehicle");
                                                    Console.ReadKey();
                                                    Main();
                                                }
                                                Console.WriteLine(info[1]);
                                                if (mcParking >= 200)
                                                {
                                                    mcParking = mcParking - 200;
                                                    var separateNew = (info[newIndex]).Split("/");
                                                    var separateOld = (info[mcParking]).Split("/");
                                                    type = "1";
                                                    separateOld[0] = type;
                                                    separateOld[2] = "";
                                                    if (separateNew[0] == "1" || separateNew[0] == "2")
                                                    {
                                                        type = "3";
                                                        if(separateNew[1].Length > 0)
                                                        {
                                                            separateNew[2] = regNumber;
                                                        }
                                                        else
                                                            if (separateNew[2].Length > 0)
                                                        {
                                                            separateNew[1] = regNumber;
                                                        }
                                                    }
                                                    if (separateNew[0] == "0")
                                                    {
                                                        separateNew[0] = "1";
                                                        separateNew[1] = regNumber;
                                                    }
                                                    info[newIndex] = string.Join("/", separateNew);
                                                    info[mcParking] = string.Join("/", separateOld);
                                                }
                                                if(mcParking < 200 && mcParking >= 100)
                                                {
                                                    mcParking = mcParking - 100;
                                                    var separateNew = (info[newIndex]).Split("/");
                                                    var separateOld = (info[mcParking]).Split("/");
                                                    type = "2";
                                                    separateOld[0] = type;
                                                    separateOld[1] = "";
                                                    if (separateNew[0] == "1" || separateNew[0] == "2")
                                                    {
                                                        type = "3";
                                                        if (separateNew[1].Length > 0)
                                                        {
                                                            separateNew[2] = regNumber;
                                                        }
                                                        else
                                                            if (separateNew[2].Length > 0)
                                                        {
                                                            separateNew[1] = regNumber;
                                                        }
                                                    }
                                                    if (separateNew[0] == "0")
                                                    {
                                                        separateNew[0] = "1";
                                                        separateNew[1] = regNumber;
                                                    }
                                                    info[newIndex] = string.Join("/", separateNew);
                                                    info[mcParking] = string.Join("/", separateOld);
                                                }
                                                Console.WriteLine("You Motorbike with registration number {0} has been moved to the new spot {1}", regNumber, (newIndex + 1));
                                                Console.ReadKey();
                                                Main();
                                                break;
                                            case 2:
                                                Main();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Error();
                                    }
                                    break;
                                case 3:
                                    Main();
                                    break;
                            }
                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Search For Vehicle menu----------------------------------
                    case 3:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Search for Vehicle--");
                        Console.WriteLine("".PadRight(5) + "Please search by reg number\n");
                        Console.WriteLine("".PadRight(5) + "1. Input reg number eg) ABC123 ");
                        Console.WriteLine("".PadRight(5) + "2. Return to menu: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 3 && x > 0)
                        {
                            looper = 1;
                            switch (x)
                            {
                                case 1:
                                    currentParking = SearchVehicle(looper);
                                    if(currentParking >= 200)
                                    {
                                        currentParking = currentParking - 200;
                                    }
                                    if (currentParking >= 100 || currentParking < 200)
                                    {
                                        currentParking = currentParking - 100;
                                    }
                                    Console.WriteLine("Vehicle with registration is parked on spot {0}", (currentParking + 1));
                                    Console.ReadKey();
                                    Main();
                                    break;
                                case 2:
                                    Main();
                                    break;
                            }

                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Return Vehicle menu----------------------------------
                    case 4:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Return Vehicle--");
                        Console.WriteLine("".PadRight(5) + "Please search by reg number\n");
                        Console.WriteLine("".PadRight(5) + "1. Input reg number eg) ABC123 ");
                        Console.WriteLine("".PadRight(5) + "2. Return to menu: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 3 && x > 0)
                        {
                            looper = 1;
                            switch (x)
                            {
                                case 1:
                                    currentParking = SearchVehicle(looper);
                                    if(looper == -1)
                                    {
                                        Console.WriteLine("Your vehicle was not found, please search again");
                                        Console.ReadKey();
                                        Main();
                                    }
                                    if (currentParking >= 200)
                                    {
                                        currentParking = currentParking - 200;
                                    }
                                    else 
                                    if (currentParking >= 100 || currentParking < 200)
                                    {
                                        currentParking = currentParking - 100;
                                    }
                                    var separate = (info[looper]).Split("/");
                                    //---------------- If there is a car in the spot-------------------
                                    if(separate[0] == "4")
                                    {
                                        separate[0] = "0";
                                        separate[1] = "";
                                        Console.WriteLine("Your car with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                    }
                                    else
                                    if (separate[0] == "3" || separate[0] == "2" || separate[0] == "1")
                                    {
                                        //-------------If there is only 1 MC on parking--------------------
                                        if(separate[0] == "2" || separate[0] == "1")
                                        {
                                            separate[0] = "0";
                                            if(separate[1] == regNumber)
                                            {
                                                separate[1] = "";
                                            }
                                            if (separate[2] == regNumber)
                                            {
                                                separate[2] = "";
                                            }
                                            Console.WriteLine("Your Motorcycle with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                        }
                                        //---------------If there are 2 MCs on parking--------
                                        if(separate[0] == "3")
                                        {
                                            if(separate[1] == regNumber)
                                            {
                                                separate[0] = "2";
                                                separate[1] = "";
                                            }
                                            if (separate[2] == regNumber)
                                            {
                                                separate[0] = "1";
                                                separate[2] = "";
                                            }

                                            Console.WriteLine("Your Motorcycle with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                        }
                                        info[currentParking] = string.Join("/", separate);
                                    }
                                    Main();
                                    break;
                                case 2:
                                    Main();
                                    break;
                            }
                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Check Status of garage menu----------------------------------
                    case 5:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Check status of garage--");
                        Console.WriteLine("".PadRight(5) + "Would you like to see a list or the map\n");
                        Console.WriteLine("".PadRight(5) + "1. List of parking spaces");
                        Console.WriteLine("".PadRight(5) + "2. Map of Garage ");
                        Console.WriteLine("".PadRight(5) + "3. Return to menu: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 4 && x > 0)
                        {
                            switch (x)
                            {
                                case 1:
                                    PrintListOfSpaces();
                                    Console.ReadKey();
                                    Main();
                                    break;
                                case 2:
                                    parkingMap();
                                    Console.ReadKey();
                                    Main();
                                    break;
                                case 3:
                                    Main();
                                    break;
                            }

                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Collect Vehicle Information----------------------------------
                    case 6:
                        Console.Clear();
                        Console.WriteLine("".PadRight(9) + "--Collect Vehicle Information and Price--");
                        Console.WriteLine("".PadRight(5) + "Please input Regnumber to see your parking ticket");
                        Console.WriteLine("".PadRight(5) + "1. Enter Regnumber ");
                        Console.WriteLine("".PadRight(5) + "2. Return to menu: ");
                        X = Console.ReadLine();
                        Checker(X);
                        x = int.Parse(X);
                        if (x < 3 && x > 0)
                        {
                            Console.WriteLine("Please input RegNumber (Max 10 characters)");
                            regNumber = Console.ReadLine();
                            if (regNumber.Length <= 10)
                            {
                                switch (x)
                                {
                                    case 1:
                                        FindInfoOnVehicle(regNumber);
                                        Main();
                                        break;
                                    case 3:
                                        Main();
                                        break;
                                }
                            }
                            else
                            {
                                Error();
                            }

                        }
                        else
                        {
                            Error();
                        }
                        break;
                    // ------------------------------------Exit Garage----------------------------------
                    case 7:
                        // Add a moving arrow/exit sign above here
                        ClearConsole();
                        Console.WriteLine("     Thank you for using Prague Parking\n     We hope to see you again");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Error();
            }
        }


        //----------------------------------Clear Console Method----------------------------

        public static void ClearConsole()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        //----------------------------------Error Program-----------------------------------

        public static void Error()
        {
            Console.WriteLine("Sorry Wrong input, please try again");
            Console.ReadKey();
            Main();
        }

        //------------------------------Bool Checker--------------------------------

        public static void Checker(string X)

        {
            bool check = double.TryParse(X, out a);
            if (check)
            {
            }
            else
            {
                Error();
                Main();
            }
        }

        //--1--------------------------------------------------------Parking Vehicle Methods-----------------------------------------
        //---------------------Find next spot-----------------------
        public static int FindNextAvai(int looper)
        {
            fullCheck = false;
            if (looper == 4)
            {
                for (index = 0; index < 100; index++)
                {
                    string parking = info[index];
                    if (parking.Substring(0, 1) == "0")
                    {
                        looper = index;
                        fullCheck = true;
                        break;
                    }
                }
            }
            else
                if (looper == 1)
            {
                for (index = 0; index < 100; index++)
                {
                    string parking = info[index];
                    if (parking.Substring(0, 1) == "0" || parking.Substring(0, 1) == "1" || parking.Substring(0, 1) == "2")
                    {
                        looper = index;
                        fullCheck = true;
                        break;
                    }
                }
            }
            if(fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        //-------------------------------------You choose the spot yourself--------------------------
        public static int YouChoose(int looper)
        {
            Console.WriteLine("Please input what spot you would like to park in");
            X = Console.ReadLine();
            Checker(X);
            x = ((int.Parse(X))-1);
            fullCheck = false;
            if (looper == 4)
            {
                    string parking = info[x];
                    if (parking.Substring(0, 1) == "0")
                    {
                        looper = x;
                        fullCheck = true;
                    }
            }
            else
                if (looper == 1)
            {
                string parking = info[x];
                if (parking.Substring(0, 1) == "0" || parking.Substring(0, 1) == "1" || parking.Substring(0, 1) == "2")
                {
                    looper = x;
                    fullCheck = true;
                }
            }
            if (fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        //--2--------------------------------------------------------Moving Vehicle methods´-----------------------------------------
        //---------------------------------------Move vehicle to chosen spot-----------------------

        public static int SearchVehicle(int looper)
        {
            Console.WriteLine("Please input reg number to search");
            regNumber = (Console.ReadLine()).ToUpper();
            fullCheck = false;
            if (looper == 4)
            {
                for (index = 0; index < info.Length; index++)
                {
                    string parking = info[x];
                    var separate = info[index].Split("/");
                    if (separate[1] == regNumber && parking.Substring(0, 1) == "4")
                    {
                        looper = index;
                        fullCheck = true;
                    }
                }
            }
            else
            if(looper == 1)
            {
                for (index = 0; index < info.Length; index++)
                {
                    var separate = info[index].Split("/");
                    if (separate[1] == regNumber)
                    {
                        info[index] = string.Join("/", separate);
                        looper = index + 100;
                        fullCheck = true;
                        break;
                    }
                    if (separate[2] == regNumber)
                    {
                        info[index] = string.Join("/", separate);
                        looper = index + 200; ;
                        fullCheck = true;
                        break;
                    }
                }
            }

            if(fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        //----------------------------------------Check if spot is full----------------------------------------------

        public static int ParkingSpotChecker(int looper)
        {
            Console.WriteLine("Please input new spot to move car");
            X = Console.ReadLine();
            Checker(X);
            x = (int.Parse(X));
            x = x - 1;
            fullCheck = false;
            if (looper == 4)
            {
                string parking = info[x];
                if (parking.Substring(0, 1) == "0")
                {
                    looper = x;
                    fullCheck = true;
                }
            }
            else
            if (looper == 1)
            {
                string parking = info[x];
                if (parking.Substring(0, 1) == "1" || parking.Substring(0, 1) == "2" || parking.Substring(0, 1) == "0")
                {
                    looper = x;
                    fullCheck = true;
                }
            }

            if (fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        // 5 ---------------------------------------Print Info on Parking spots-----------------------------------
        //-----------------------------This is only for the map section so is not necessary but for my own visual enjoyment-----------------------------

        public static void PrintListOfSpaces()
        {
            ClearConsole();
            Console.WriteLine("Here is a list of all the parking spaces");
            Console.WriteLine("Guide: 0 = empty, 1 = One Mc on left side, 2 = One MC on right side; 3 = Two MCS, 4 = Car in Parking");
            Console.WriteLine();
            EmptyPark(index);
            for (index = 0; index < info.Length-3; index++)
            {
                Console.Write(" {0}. Contains {1}", (index + 1), info[index]);
                index++;
                int a = (info[index].Length);
                a = 15 - a;
                Console.Write("".PadRight(a) + " {0}. Contains {1}", (index + 1), info[index]);
                index++;
                a = (info[index].Length);
                a = 15 - a;
                Console.Write("".PadRight(a) + " {0}. Contains {1}", (index + 1), info[index]);
                Console.WriteLine();
            }
            Console.Write("{0}. Contains {1}", (index + 1), info[index]);
            RedoArray(index);
        }

        //-----------------------------------Turn parking to empty------------------------------------------

        public static int EmptyPark(int index)
        {
            for(index = 0; index < info.Length; index++)
                if(info[index] == "0//")
                {
                    info[index] = "0/Empty/";
                }
            index = 0;
            return index;
        }

        //-----------------------------------------Repopulate Array--------------------------------------
        public static int RedoArray(int index)
        {
            for (index = 0; index < info.Length; index++)
                if (info[index] == "0/Empty/")
                {
                    info[index] = "0//";
                }
            index = 0;
            return index;
        }

        //----------------------------------------Parking Map----------------------------------------

        public static void parkingMap()
        {
            Console.WriteLine("Map of garage");
            Console.WriteLine(" O = Empty,  1 = 1 MC, 2 = 2 MC, 3 = Car ");
            for(index = 0; index < 21; index++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for(index = )
            

            Console.Write();
        }

        // 6 ---------------------------------------Bring back info on vehicle---------------------------------------
        // --------------------------------Parking Receipt-------------------------------------

        public static string FindInfoOnVehicle(string regNumber)
        {
            return regNumber;
        }
    }
}