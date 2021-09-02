using System;
using System.IO;

namespace Classwork1.Math
{
    public struct AngleStruct
    {
        private double angle; // Angle in radians
        public double angleDegrees
        {
            get { return this.angle * 180.0 / System.Math.PI; }
            set { this.angle = value / 180.0 * System.Math.PI; }
        }
    }

    public class AngleClass
    {
        private double angle; // Angle in radians
        public double angleDegrees
        {
            get { return this.angle * 180.0 / System.Math.PI; }
            set { this.angle = value / 180.0 * System.Math.PI; }
        }
    }

    public class BasicMessageClass
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public BasicMessageClass()
        {
            message = "Default Meassage";
        }

        public BasicMessageClass(string value)
        {
            message = value;
        }
    }

    public class LinkedList
    {
        internal class LinkedListNode
        {
            internal int data;
            internal LinkedListNode next;
            public LinkedListNode(int dataToPutInNode)
            {
                data = dataToPutInNode;
                next = null;
            }
        }

        private LinkedListNode head;
        private LinkedListNode current;

        public LinkedList ()
        {
            head = new LinkedListNode(0);
            current = head;
        }

        public bool AddNode(int dataToAddToList)
        {
            LinkedListNode NodeToAdd = new LinkedListNode(dataToAddToList);
            current.next = NodeToAdd;
            current = NodeToAdd;
            return true;
        }

        public void PrintList()
        {
            current = head;
            while (current.next != null)
            {
                System.Console.WriteLine(current.next.data);
                current = current.next;
            }
        }
    }

    class Program
    {
        static void DisplayMenu()
        {
            System.Console.WriteLine("C# Demo");
            System.Console.WriteLine("1 = Show pass by reference and pass by value scenario");
            System.Console.WriteLine("2 = Show Hello World on the screen");
            System.Console.WriteLine("3 = Write Hello World into a file");
            System.Console.WriteLine("4 = Adding two numbers in a linked list");
            System.Console.WriteLine("0 = Quit");
        }

        static void Main()
        {
            // Declare local variables
            string menuSelection = "Start";
            BasicMessageClass helloWorld = new BasicMessageClass("Hello World");
            AngleStruct angleStruct1 = new AngleStruct();
            AngleStruct angleStruct2 = new AngleStruct();
            AngleClass angleClass1 = new AngleClass();
            AngleClass angleClass2 = new AngleClass();

            while (menuSelection != "0")
            {
                // Display menu
                DisplayMenu();

                // Get user choice
                menuSelection = System.Console.ReadLine();
                System.Console.WriteLine("");

                // Switch statment for menuing
                switch (menuSelection)
                {
                    case "1":
                        System.Console.WriteLine("Showing pass by value:");
                        angleStruct1.angleDegrees = 0;
                        System.Console.WriteLine("angleStruct1 set to zero");
                        angleStruct2 = angleStruct1;
                        System.Console.WriteLine("angleStruct2 set equal to angleStruct1");
                        angleStruct1.angleDegrees = 45;
                        System.Console.WriteLine("angleStruct1 updated to 45");
                        System.Console.WriteLine("Printing angleStruct1");
                        System.Console.WriteLine(angleStruct1.angleDegrees);
                        System.Console.WriteLine("Printing angleStruct2");
                        System.Console.WriteLine(angleStruct2.angleDegrees);
                        System.Console.WriteLine("");

                        System.Console.WriteLine("Showing pass by reference:");
                        angleClass1.angleDegrees = 0;
                        System.Console.WriteLine("angleClass1 set to zero");
                        angleClass2 = angleClass1;
                        System.Console.WriteLine("angleClass2 set equal to angleClass1");
                        angleClass1.angleDegrees = 45;
                        System.Console.WriteLine("angleClass1 updated to 45");
                        System.Console.WriteLine("Printing angleClass1");
                        System.Console.WriteLine(angleClass1.angleDegrees);
                        System.Console.WriteLine("Printing angleClass2");
                        System.Console.WriteLine(angleClass2.angleDegrees);

                        break;

                    case "2":
                        System.Console.WriteLine(helloWorld.Message);
                        break;

                    case "3":
                        File.WriteAllText(@"C:\Temp\HelloWorld.txt", helloWorld.Message);
                        System.Console.WriteLine(@"HelloWorld.txt in C:\Temp\ updated to read 'Hello World");
                        break;

                    case "4":
                        LinkedList list = new LinkedList(); // Declared in case so recuring calls to this case each start with a fresh list
                        System.Console.WriteLine("Adding node with a value of 1 to an empty list, then printing the list");
                        list.AddNode(1);
                        list.PrintList();
                        System.Console.WriteLine("Adding node with a value of 2 to the list, then printing the list");
                        list.AddNode(2);
                        list.PrintList();
                        break;

                    case "0":
                        break;

                    default:
                        System.Console.WriteLine("Input not recognized. Please enter a number between 0 and 4: ");
                        break;
                }
                System.Console.WriteLine("");
            }
        }
    }
}
