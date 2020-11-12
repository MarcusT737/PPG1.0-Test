using System;

namespace PPG1._1
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
        public static string regChecker;
        public static string illegal = "";
        public static string space = "";
        public static int regFail;
        public static int a;
        public static string b;
        public static char c;
        public static string d;
        public static string e;
        public static int f;
        public static int index = 0;
        public static int j;
        public static int looper;
        public static int counter;
        public static int currentParking;
        public static int newIndex;
        public static int mcParking;
        public static int len;
        public static int error;
        public static bool check = true;
        public static bool fullCheck = false;
        public static DateTime checkInLocal;
        public static string checkIn;
        public static DateTime checkOutLocal;
        public static string checkOut;
        public static int dateStamp;
        public static string totalTime;

        public static void Main()
        {
            for (index = 0; index < info.Length; index++)
            {
                info[index] = "0////";
            }
            bool running = true;
            while (running)
            {
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
                                        if (x < 4 && x > 0)
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    newIndex = FindNextAvai(looper);
                                                    error = NextAvailError(newIndex);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    parkCar();
                                                    break;
                                                case 2:
                                                    newIndex = YouChoose(looper);
                                                    error = ChooseError(newIndex);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    parkCar();
                                                    break;
                                                case 3:
                                                    break;
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
                                        if (x < 4 && x > 0)
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    newIndex = FindNextAvai(looper);
                                                    error = NextAvailError(newIndex);
                                                    if(error == -2)
                                                    {
                                                        break;
                                                    }
                                                    parkBike();
                                                    break;
                                                case 2:
                                                    newIndex = YouChoose(looper);
                                                    error = ChooseError(newIndex);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    parkBike();
                                                    break;
                                                case 3:
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    case 3:
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
                                        if (x < 3 && x > 0)
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    looper = 4;
                                                    currentParking = SearchVehicle(looper);
                                                    error = SearchError(currentParking);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    looper = 4;
                                                    newIndex = ParkingSpotChecker(looper);
                                                    error = ChooseError(newIndex);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    type = "4";
                                                    var separate = (info[currentParking]).Split("/");
                                                    checkIn = separate[3];
                                                    info[currentParking] = string.Join("/", separate);
                                                    info[currentParking] = "0////";
                                                    separate = (info[newIndex]).Split("/");
                                                    separate[0] = type;
                                                    separate[1] = regNumber;
                                                    separate[3] = checkIn;
                                                    info[newIndex] = string.Join("/", separate);
                                                    Console.WriteLine("You car with registration number {0} has been moved to the new spot {1}", regNumber, (newIndex + 1));
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
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
                                        if (x < 3 && x > 0)
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    looper = 1;
                                                    mcParking = SearchVehicle(looper);
                                                    error = SearchError(mcParking);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    looper = 1;
                                                    newIndex = ParkingSpotChecker(looper);
                                                    error = ChooseError(newIndex);
                                                    if (error == -2)
                                                    {
                                                        break;
                                                    }
                                                    // If the bike is on the right side
                                                    if (mcParking >= 200)
                                                    {
                                                        mcParking = mcParking - 200;
                                                        var separateNew = (info[newIndex]).Split("/");
                                                        var separateOld = (info[mcParking]).Split("/");
                                                        type = "1";
                                                        checkIn = separateOld[4];
                                                        separateOld[0] = type;
                                                        separateOld[2] = "";
                                                        separateOld[4] = "";
                                                        if (separateNew[0] == "1" || separateNew[0] == "2")
                                                        {
                                                            type = "3";
                                                            if (separateNew[1].Length > 0)
                                                            {
                                                                separateNew[2] = regNumber;
                                                                separateNew[4] = checkIn;
                                                            }
                                                            else
                                                                if (separateNew[2].Length > 0)
                                                            {
                                                                separateNew[1] = regNumber;
                                                                separateNew[3] = checkIn;
                                                            }
                                                        }
                                                        if (separateNew[0] == "0")
                                                        {
                                                            separateNew[0] = "1";
                                                            separateNew[1] = regNumber;
                                                            separateNew[3] = checkIn;
                                                        }
                                                        info[newIndex] = string.Join("/", separateNew);
                                                        info[mcParking] = string.Join("/", separateOld);
                                                    }
                                                    // If the bike is on the left side
                                                    if (mcParking < 200 && mcParking >= 100)
                                                    {
                                                        mcParking = mcParking - 100;
                                                        var separateNew = (info[newIndex]).Split("/");
                                                        var separateOld = (info[mcParking]).Split("/");
                                                        type = "2";
                                                        checkIn = separateOld[3];
                                                        separateOld[0] = type;
                                                        separateOld[1] = "";
                                                        separateOld[3] = "";
                                                        if (separateNew[0] == "1" || separateNew[0] == "2")
                                                        {
                                                            type = "3";
                                                            if (separateNew[1].Length > 0)
                                                            {
                                                                separateNew[2] = regNumber;
                                                                separateNew[4] = checkIn;
                                                            }
                                                            else
                                                                if (separateNew[2].Length > 0)
                                                            {
                                                                separateNew[1] = regNumber;
                                                                separateNew[3] = checkIn;
                                                            }
                                                        }
                                                        if (separateNew[0] == "0")
                                                        {
                                                            separateNew[0] = "1";
                                                            separateNew[1] = regNumber;
                                                            separateNew[3] = checkIn;
                                                        }
                                                        info[newIndex] = string.Join("/", separateNew);
                                                        info[mcParking] = string.Join("/", separateOld);
                                                    }
                                                    Console.WriteLine("You Motorbike with registration number {0} has been moved to the new spot {1}", regNumber, (newIndex + 1));
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    case 3:
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
                            if (x < 3 && x > 0)
                            {
                                looper = 1;
                                switch (x)
                                {
                                    case 1:
                                        currentParking = SearchVehicle(looper);
                                        error = SearchError(currentParking);
                                        if (error == -2)
                                        {
                                            break;
                                        }
                                        if (currentParking >= 200)
                                        {
                                            currentParking = currentParking - 200;
                                        }
                                        if (currentParking >= 100 && currentParking < 200)
                                        {
                                            currentParking = currentParking - 100;
                                        }
                                        Console.WriteLine("Vehicle with registration {0} is parked on spot {1}", regNumber, (currentParking + 1));
                                        Console.ReadKey();
                                        break;
                                    case 2:
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
                            if (x < 3 && x > 0)
                            {
                                looper = 1;
                                switch (x)
                                {
                                    case 1:
                                        currentParking = SearchVehicle(looper);
                                        error = SearchError(currentParking);
                                        if (error == -2)
                                        {
                                            break;
                                        }
                                        if (currentParking >= 200)
                                        {
                                            currentParking = currentParking - 200;
                                        }
                                        else
                                        if (currentParking >= 100 && currentParking < 200)
                                        {
                                            currentParking = currentParking - 100;
                                        }
                                        var separate = (info[currentParking]).Split("/");
                                        //---------------- If there is a car in the spot-------------------
                                        if (separate[0] == "4")
                                        {
                                            checkIn = separate[3];
                                            totalTime = ExitTime(checkIn);
                                            separate[0] = "0";
                                            separate[1] = "";
                                            separate[3] = "";
                                            Console.WriteLine(" Your car with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                            Console.WriteLine("\n Check in time was {0}, and check out time was {1}", checkIn, checkOut);
                                            Console.WriteLine("\n Total time spent in garage is {0}", totalTime);
                                        }
                                        else
                                        if (separate[0] == "3" || separate[0] == "2" || separate[0] == "1")
                                        {
                                            //-------------If there is only 1 MC on parking--------------------
                                            if (separate[0] == "2" || separate[0] == "1")
                                            {
                                                
                                                
                                                separate[0] = "0";
                                                if (separate[1] == regNumber)
                                                {
                                                    separate[1] = "";
                                                    checkIn = separate[3];
                                                    totalTime = ExitTime(checkIn);
                                                    separate[3] = "";
                                                }
                                                if (separate[2] == regNumber)
                                                {
                                                    separate[2] = "";
                                                    checkIn = separate[4];
                                                    totalTime = ExitTime(checkIn);
                                                    separate[4] = "";
                                                }
                                                Console.WriteLine(" Your Motorcycle with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                                Console.WriteLine("\n Check in time was {0}, and check out time was {1}", checkIn, checkOut);
                                                Console.WriteLine("\n Total time spent in garage is {0}", totalTime);
                                            }
                                            //---------------If there are 2 MCs on parking--------
                                            if (separate[0] == "3")
                                            {
                                                if (separate[1] == regNumber)
                                                {
                                                    separate[0] = "2";
                                                    separate[1] = "";
                                                    checkIn = separate[3];
                                                    totalTime = ExitTime(checkIn);
                                                    separate[3] = "";
                                                }
                                                if (separate[2] == regNumber)
                                                {
                                                    separate[0] = "1";
                                                    separate[2] = "";
                                                    checkIn = separate[4];
                                                    totalTime = ExitTime(checkIn);
                                                    separate[4] = "";
                                                }

                                                Console.WriteLine(" Your Motorcycle with regnumber {0} has been returned from parking {1}", regNumber, (currentParking + 1));
                                                Console.WriteLine("\n Check in time was {0}, and check out time was {1}", checkIn, checkOut);
                                                Console.WriteLine("\n Total time spent in garage is {0}", totalTime);
                                            }
                                        }
                                        info[currentParking] = string.Join("/", separate);
                                        Console.ReadKey();
                                        break;
                                    case 2:
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
                            if (x < 4 && x > 0)
                            {
                                switch (x)
                                {
                                    case 1:
                                        PrintListOfSpaces();
                                        break;
                                    case 2:
                                        ParkingMap();
                                        break;
                                    case 3:
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
                            if (x < 3 && x > 0)
                            {
                                Console.WriteLine("Please input RegNumber (Max 10 characters)");
                                regNumber = Console.ReadLine();
                                if (regNumber.Length <= 10)
                                {
                                    switch (x)
                                    {
                                        case 1:
                                            Console.WriteLine("Sorry this section is under construction");
                                            Console.ReadKey();
                                            break;
                                        case 2:
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
                            Console.WriteLine("".PadRight(12) + "Thank you for using Prague Parking" + "\n" + "".PadRight(12) + "Remaining Cars will be crushed" + "\n" + "".PadRight(12) + "We hope to see you again");
                            Console.ReadKey();
                            running = false;
                            break;
                    }
                }
                else
                {
                    Error();
                }
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
            Console.WriteLine(" Sorry Wrong input, please try again");
            Console.ReadKey();
        }

        //-----------------------------------Error Checker Programs---------------------------
        //------------------------------Bool Checker--------------------------------

        public static string Checker(string X)

        {
            bool check = int.TryParse(X, out a);
            if (check)
            {
                x = int.Parse(X);
            }
            else
            {
                x = 0;
            }
            return X;
        }

        //--------------------------Input Error Methods-------------------------------------
        public static int NextAvailError(int number)
        {
            if (newIndex == -1)
            {
                if (check == false)
                {
                    if (regFail == -5)
                    {
                        Console.ReadKey();
                        number = -2;
                        return number;
                    }
                    if(f == -5)
                    {
                        number = -2;
                        return number;
                    }
                    Error();
                    number = -2;
                    return number;
                }
                Console.WriteLine(" Sorry all spots are full");
                Console.ReadKey();
                number = -2;
                return number;
            }
            else
            {
                return number;
            }
        }

        public static int SearchError(int number)
        {
            if (currentParking == -1)
            {
                if (check == false)
                {
                    if(regFail == -5)
                    {
                        Console.ReadKey();
                        number = -2;
                        return number;
                    }
                    if (f == -5)
                    {
                        number = -2;
                        return number;
                    }
                    Error();
                    number = -2;
                    return number;
                }
                Console.WriteLine(" Sorry We could not find your vehicle");
                Console.ReadKey();
                number = -2;
                return number;
            }
            else
            {
                return number;
            }
        }

        public static int ChooseError(int number)
        {
            if (newIndex == -1)
            {
                if (check == false)
                {
                    if (regFail == -5)
                    {
                        Console.ReadKey();
                        number = -2;
                        return number;
                    }
                    if (f == -5)
                    {
                        number = -2;
                        return number;
                    }
                    Error();
                    number = -2;
                    return number;
                }
                Console.WriteLine(" Sorry that spot is taken");
                Console.ReadKey();
                number = -2;
                return number;
            }
            else
            {
                return number;
            }
        }

        //-------------------------------------ParkMethod-----------------------------------------------
        //--------------------------------------Park Car--------------------------------------------------

        public static void parkCar()
        {
            type = "4";
            checkIn = CheckInTime(checkIn);
            var separate = (info[newIndex]).Split("/");
            separate[0] = type;
            separate[1] = regNumber;
            separate[3] = checkIn;
            info[newIndex] = string.Join("/", separate);
            Console.WriteLine("You car with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
            Console.WriteLine("Time of check in is {0}", checkIn);
            Console.ReadKey();
            return;
        }

        //--------------------------------------Park Bike--------------------------------------------------

        public static void parkBike()
        {
            type = "1";
            checkIn = CheckInTime(checkIn);
            mcParking = 1;
            dateStamp = 3;
            var separate = (info[newIndex]).Split("/");
            if (separate[1].Length > 0)
            {
                mcParking = 2;
                dateStamp = 4;
                type = "3";
            }
            separate[0] = type;
            separate[mcParking] = regNumber;
            separate[dateStamp] = checkIn;
            info[newIndex] = string.Join("/", separate);
            Console.WriteLine("You Motorbike with registration number {0} has been parked on spot {1}", regNumber, (newIndex + 1));
            Console.WriteLine("Time of check in is {0}", checkIn);
            Console.ReadKey();
            return;
        }

        //------------------------------------------Reg number checker--------------------------------------

        public static string RegErrorCheck()
        {
            regNumber = (Console.ReadLine()).ToUpper();
            var splitter = regNumber.Split();
            regNumber = string.Join("", splitter);
            len = regNumber.Length;
            counter = 0;
            j = 0;
            for (index = 0; index < len; index++)
            {
                check = false;
                for (int i = 48; i < 58; i++)
                {
                    c = ((char)i);
                    d = c.ToString();
                    if(regNumber.Substring(j,1) == d)
                    {
                        counter++;
                        check = true;
                    }
                }
                
                for (int i = 65; i < 91; i++)
                {
                    c = ((char)i);
                    d = c.ToString();
                    if (regNumber.Substring(j, 1) == d)
                    {
                        counter++;
                        check = true;
                    }
                }
                j++;
                if (check == false)
                {
                    illegal = illegal + (regNumber.Substring(index, 1));
                    illegal = illegal + ",";
                }
            }
            if(counter < len)
            {
                Console.WriteLine(" Sorry the following characters are illegal");
                var separate = illegal.Split(",");
                for(index = 0; index < (len - counter); index++)
                {
                    Console.Write(" {0}: {1}   ", (index + 1), separate[index]);
                }
                Console.WriteLine("\n Please try again");
                regFail = -5;
                len = -1;
            }
            return regNumber;
        }

        //-----------------------------------------Reg duplicate checker----------------------------------------

        public static string RegDuplicate(string regNumber)
        {
            for (index = 0; index < info.Length; index++)
            {
                e = info[index];
                var splitter = e.Split("/");
                if (splitter[1] == regNumber || splitter[2] == regNumber)
                {
                    Console.WriteLine(" Sorry this Registration plate alreay exists.\n The Police have been called to your location.\n Have a great day");
                    Console.ReadKey();
                    len = -1;
                    f = -5;
                    break;
                }
            }
            return regNumber;
        }

        //--1--------------------------------------------------------Parking Vehicle Methods-----------------------------------------
        //---------------------Find next spot-----------------------
        public static int FindNextAvai(int looper)
        {
            Console.WriteLine(" Please input RegNumber (Max 10 characters)");
            regNumber = RegErrorCheck();
            regNumber = RegDuplicate(regNumber);
            if (len > 10 || len < 1)
            {
                looper = -1;
                check = false;
                return looper;
            }
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
            if (fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        //-------------------------------------You choose the spot yourself--------------------------
        public static int YouChoose(int looper)
        {
            Console.WriteLine(" Please input RegNumber (Max 10 characters)");
            regNumber = RegErrorCheck();
            regNumber = RegDuplicate(regNumber);
            if (len > 10 || len < 1)
            {
                looper = -1;
                check = false;
                return looper;
            }
            Console.WriteLine(" Please input what spot you would like to park in");
            looper = SpotChecker(looper);
            return looper;
        }

        public static int SpotChecker(int looper)
        {
            X = Console.ReadLine();
            Checker(X);
            x = x - 1;
            if (x > 99 || x < 0)
            {
                looper = -1;
                check = false;
                return looper;
            }
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
            Console.WriteLine(" Please input reg number to search");
            regNumber = RegErrorCheck();
            if (len > 10 || len < 1)
            {
                looper = -1;
                check = false;
                return looper;
            }
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
            if (looper == 1)
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
            if (fullCheck == false)
            {
                looper = -1;
            }
            return looper;
        }

        //----------------------------------------Check if spot is full----------------------------------------------

        public static int ParkingSpotChecker(int looper)
        {
            Console.WriteLine(" Please input new spot to move Vehicle");
            looper = SpotChecker(looper);
            return looper;
        }


        // 5 ---------------------------------------Print Info on Parking spots-----------------------------------
        //-----------------------------This is only for the map section so is not necessary but for my own visual enjoyment-----------------------------

        public static void PrintListOfSpaces()
        {
            ClearConsole();
            Console.WriteLine(" Here is a list of all the parking spaces with registrations attached");
            Console.WriteLine(" Guide: Empty = empty, 1 = One Mc on left side, 2 = One MC on right side; 3 = Two MCS, 4 = Car in Parking");
            Console.WriteLine();
            for (index = 0; index < info.Length - 3; index++)
            {
                b = (index + 1).ToString("D3");
                space = EmptyPark(space);
                Console.Write(" {0}. Contents {1}", b, space);
                index++;
                space = EmptyPark(space);
                b = (index + 1).ToString("D3");
                a = 15 - (space.Length);
                Console.Write("".PadRight(a) + " {0}. Contents {1}", b, space);
                index++;
                space = EmptyPark(space);
                b = (index + 1).ToString("D3");
                a = 15 - (space.Length);
                Console.Write("".PadRight(a) + " {0}. Contents {1}", b, space);
                Console.WriteLine();
            }
            EmptyPark(space);
            Console.Write(" {0}. Contains {1}", (index + 1), space);
            Console.ReadKey();
        }

        //-----------------------------------Turn parking to empty------------------------------------------

        public static string EmptyPark(string space)
        {
            space = info[index];
            var separateParking = space.Split("/");
            if (separateParking[0] == "0")
            {
                space = "Empty";
                return space;
            }
            if(separateParking[0] == "1")
            {
                space = separateParking[0] + "," + separateParking[1];
                return space;
            }
            if (separateParking[0] == "2")
            {
                space = separateParking[0] + "," + separateParking[2];
                return space;
            }
            if (separateParking[0] == "3")
            {
                space = separateParking[0] + "," + separateParking[1] + "," + separateParking[2];
                return space;
            }
            if (separateParking[0] == "4")
            {
                space = separateParking[0] + "," + separateParking[1];
                return space;
            }
            space = string.Join("/", separateParking);
            return space;
        }

        //----------------------------------------Parking Map----------------------------------------

        public static void ParkingMap()
        {
            ClearConsole();
            Console.WriteLine("".PadRight(55) + "Map of garage");
            Console.WriteLine("".PadRight(25) + "P###  = Parking number,  O = Empty,  1 = 1 MC, 2 = 2 MC, 3 = Car ");
            
            Console.Write("".PadRight(5));
            for (index = 0; index < 102; index++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            Console.Write("| {0}       |", '\u2193');
            for (index = 0; index < 16; index++)
            {
                ParkingEdit(index);
            }
            Console.Write("".PadRight(8) + "|");
            Console.WriteLine("\n|" + "".PadRight(105) + "|\n|" + "".PadRight(105) + "|");
            Console.Write("|   |");
            for (index = 16; index < 33; index++)
            {
                ParkingEdit(index);
            }
            Console.WriteLine();
            Console.Write("|   |");
            for (index = 33; index < 50; index++)
            {
                ParkingEdit(index);
            }
            Console.WriteLine("\n|" + "".PadRight(105) + "|\n|" + "".PadRight(105) + "|");
            Console.Write("|   |");
            for (index = 50; index < 67; index++)
            {
                ParkingEdit(index);
            }
            Console.WriteLine();
            Console.Write("|   |");
            for (index = 67; index < 84; index++)
            {
                ParkingEdit(index);
            }
            Console.WriteLine("\n|" + "".PadRight(105) + "|\n|" + "".PadRight(105) + "|");
            Console.Write("|   |");
            for (index = 84; index < 100; index++)
            {
                ParkingEdit(index);
            }
            Console.Write(" {0}  |\n", '\u2193');
            Console.Write("|");
            for (index = 0; index < 101; index++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("_");
            }
            Console.Write("".PadRight(4) + "|");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("".PadRight(30) + "Green = Empty, Yellow = half full, Red = Full");
            Console.ReadKey();
        }

        //-------------------------------parking colour and compiler----------------------------

        public static int ParkingEdit(int index)
        {
            string type = info[index];
            type = TypeCast(type);
            type = "P" + ((index + 1).ToString()) + "-" + type.ToString();
            Console.Write(type);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|");
            return index;
        }
        public static string TypeCast(string type)
        {
            if (type.Substring(0, 1) == "0")
            {
                type = "O";
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            if (type.Substring(0, 1) == "1" || type.Substring(0, 1) == "2")
            {
                type = "1";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            if (type.Substring(0, 1) == "3")
            {
                type = "2";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (type.Substring(0, 1) == "4")
            {
                type = "3";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            return type;
        }

        // 6 ---------------------------------------Bring back info on vehicle---------------------------------------
        // --------------------------------Parking Receipt-------------------------------------

        public static string FindInfoOnVehicle(string regNumber)
        {
            return regNumber;
        }

        //---------------------------------Timestamp Methods--------------------------------------
        //---------------------------------Check in time-----------------------------------------
        public static string CheckInTime(string checkIn)
        {
            checkInLocal = DateTime.Now;
            checkIn = checkInLocal.ToString();
            return checkIn;
        }

        //---------------------------------Check Out time-----------------------------------------
        public static string CheckOutTime(string checkOut)
        {
            checkOutLocal = DateTime.Now;
            checkOut = checkOutLocal.ToString();
            return checkOut;
        }

        //--------------------------------Return Vehicle Time Stamp--------------------------------------

        public static string ExitTime(string totalTime)
        {
            checkOut = CheckOutTime(checkOut);
            DateTime checkInLocal = DateTime.Parse(checkIn);
            DateTime checkOutLocal = DateTime.Parse(checkOut);
            TimeSpan timeSpent = checkOutLocal - checkInLocal;
            totalTime = timeSpent.ToString();
            return totalTime;
        }
    }
}