using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
    }
    class WeatherData
    {

    }
    class Location
    {

    }
    class WeatherDataServiceException 
    {

    }
    class WeatherDataServiceFactory : IWeatherDataService
    {
        WeatherData data;
        Location location;
        public WeatherData GetWeatherData(Location location)
        {
            return data;
        }
    }
    public enum Days
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wendsday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7
    }
    public class Utils
    {
        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    class Person
    {
        protected long id;
        protected string name, occupation;
        protected bool male;
        public virtual void setData(long idVal, string nameVal, bool maleVal = true, string occupationVal = "student")
        {
            id = idVal;
            name = nameVal;
            male = maleVal;
            occupation = occupationVal;
        }
        public override string ToString()
        {
            return name + ", " + occupation + ", " + id + ", " + (male ? "male" : "female");
        }
    }
    class Student : Person
    {
        public double Average { get; set; }
        public void PrintAverage()
        {
            Console.WriteLine("average=" + this.Average);
        }
        public override string ToString()
        {
            return name + ", " + occupation + ", " + id + ", " + (male ? "male" : "female")+","+Average;
        }
        public override void setData(long idVal, string nameVal, bool maleVal = true, string occupationVal = "student")
        {
            id = idVal;
            name = nameVal;
            male = maleVal;
            occupation = occupationVal;
            Average = 89.5;
    
        }
    }
    class Employee: Person
    {
        public double Salary { get; set; }
        public override string ToString()
        {
            return name + ", " + occupation + ", " + id + ", " + (male ? "male" : "female") + "," + Salary;
        }
        public override void setData(long idVal, string nameVal, bool maleVal = true, string occupationVal = "employee")
        {
            id = idVal;
            name = nameVal;
            male = maleVal;
            occupation = occupationVal;
            Salary = 4000.35;
        }
    }
    class Teacher: Student
    {
        public string Topic { get; set; }
        public override string ToString()
        {
            return name + ", " + occupation + ", " + id + ", " + (male ? "male" : "female") + "," + Topic;
        }
        public override void setData(long idVal, string nameVal, bool maleVal = true, string occupationVal = "teacher")
        {
            id = idVal;
            name = nameVal;
            male = maleVal;
            occupation = occupationVal;
            Topic = "Biology";
        }
    }

    struct Rectangle
    {
        private double width, height;
    /*    public Rectangle(): this(10.0, 10.0)
        {
            Console.WriteLine("Rectangle() is executed");
        }
     */   public Rectangle(double widthVal, double heightVal)
        {
            this.width = widthVal;
            this.height = heightVal;
            Console.WriteLine("Rectangle(double, double) is executed");
        }
        public void PrintDetails()
        {
            Console.WriteLine("[" + width + "," + height + "]");
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0) { width = value; }
                else { Console.WriteLine("width value was not set...");  }
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0) { height = value; }
                else { Console.WriteLine("height value was not set..."); }
            }
        }
        //public string NameRec { get; set; }
    }

    public class Friends
    {
        string[] names = new string[2];
        public string this [int index]
        {
            get
            {
                return names[index];
            }
            set
            {
                names[index] = value;
            }
        }
    }
    class StaticConstructorDemo
    {
        static StaticConstructorDemo()
        {
            defaultWidth = 10;
            defaultHeight = 4;
        }
        public static double defaultWidth { get; set; }
        public static double defaultHeight { get; set; }
    }

    class Program
    {
        static void DoSomething(ref int num)
        {
            num++;
        }
        static void AnotherDoSomething(out int num)
        {
            num = 123;
        }
        static int Total(int val1, int val2)
        {
            return val1 + val2;
        }
        static int Total(int val1, int val2, int val3)
        {
            return val1 + val2+val3;
        }

        static void Main(string[] args)
        {
            const double sum = 100.24;
            var num = 242;
            var name = "michael";
            var condition = true;
            Type sumType = sum.GetType();
            Type numType = num.GetType();
            Type nameType = name.GetType();
            Type condType = condition.GetType();
            Console.WriteLine("the Type of sum is " + sumType.ToString() + "\nthe Type of num is "
                + numType.ToString() + "\nthe Type of name is " + nameType.ToString() + "\nthe Type of cond is " + condType.ToString());

            Friends obs =new Friends();
            obs[0] = "Dave";
            obs[1] = "Philip";
            for (int k = 0; k < 2; k++)
            {
                Console.WriteLine(obs[k]);
            }

            int val1 = 20, val2 = 44, val3 = 24, val4;
            val4 = Total(val1, val2);
            Console.WriteLine("num4=" + val4);
            val4 = Total(val1, val2, val3);
            Console.WriteLine("num4=" + val4);
            int i = 2;
            Console.WriteLine("before... i=" + i);
            DoSomething(ref i);
            Console.WriteLine("after DoSomething... i=" + i);
            AnotherDoSomething(out i);
            Console.WriteLine("after AnotherDoSomething... i=" + i);

            Rectangle rec = new Rectangle();
            rec.Width = StaticConstructorDemo.defaultWidth;
            rec.Height = StaticConstructorDemo.defaultHeight;
           // rec.NameRec = "Rectangle";
            rec.PrintDetails();
            rec = new Rectangle(86.2, 85.3);

            var stud = new
            {
                Name = "Yair Shur",
                id = 029912312,
                average = 81.99
            };

            Person ob = new Person();
            ob.setData(idVal:12312323, nameVal:"Yair");
            Console.WriteLine(ob);

            Student ob2 = new Student();
            ob2.setData(idVal: 12312323, nameVal: "Yair");
            Console.WriteLine(ob2);
            ob2.PrintAverage();

            Teacher teacher = new Teacher();
            teacher.setData(idVal: 12312323, nameVal: "Yair");
            Console.WriteLine(teacher);

            Employee emp = new Employee();
            emp.setData(idVal: 12312323, nameVal: "Yair");
            Console.WriteLine(emp);

            int choice = 5;
            switch(choice)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            int[] vec;
            vec = new int[4];
            vec[0] = 12;
            vec[1] = 14;
            vec[2] = 16;
            vec[3] = 18;
            foreach(int temp in vec)
            {
                Console.WriteLine(temp);
            }

            Days today = Days.Sunday;
            switch(today)
            {
                case Days.Sunday:
                    Console.WriteLine("SUN");
                    break;
                case Days.Monday:
                    Console.WriteLine("MON");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            int num1 = 4, num2 = 12, sumAll;
            sumAll = Utils.Sum(num1, num2);
            Console.WriteLine("num1=" + num1 + "\nnum2=" + num2 + "\nsumAll=" + sumAll);

            Console.WriteLine("Hello Yair!!");
            Console.ReadLine();
            return;
        }
    }
}
