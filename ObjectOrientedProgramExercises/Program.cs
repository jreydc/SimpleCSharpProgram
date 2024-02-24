using System.Xml.Linq;

Console.WriteLine("Object Oriented Program Exercises!");

//Main Program

var rectangle = new Rectangle(5, 10);

//Medical Appointment Main Program
var patient = new MedicalAppointment();
patient.Reschedule(12, 4);

var printer = new MedicalAppointmentPrinter();
printer.Print(patient);


//Dog Class
Dog myDog = new Dog("Lucky", "german sheperd", 40);
Dog myOtherDog = new Dog("Tina", "shar pei", 25);
Dog anotherDog = new Dog("Luke", 25);

//Person Class

var person = new Person // object initializer is same with var person = new Person("John", 1980) but much more readable and concise.
{
    Name = "John",
    YearOfBirth = 1980
};

var account = new DailyAccountState(2000, 200);

//DayOfWeek Program

Console.WriteLine(NumberToDayOfWeekTranslator.Translate(1));

Console.WriteLine();
Console.WriteLine("Press Any Key to Close");
Console.ReadKey();


void InternationalPizzaDay()
{
    var internationalPizzaDay23 = new DateTime(2023, 2, 9);

    Console.WriteLine($"International Pizza Day is on {internationalPizzaDay23.Year} {internationalPizzaDay23.Month} {internationalPizzaDay23.Day}");
    Console.WriteLine("Day of the week is " + internationalPizzaDay23.DayOfWeek);

    var internationalPizzaDay24 = internationalPizzaDay23.AddYears(1);

    Console.WriteLine($"International Pizza Day is on {internationalPizzaDay24.Year} {internationalPizzaDay24.Month} {internationalPizzaDay24.Day}");
    Console.WriteLine("Day of the week is " + internationalPizzaDay24.DayOfWeek);
}

public class Triangle // Encapsulations
{
    public int Base;
    public int Height;

    public Triangle(int @base, int height)
    {
        Base = @base;
        Height = height;
    }

    public int CalculateArea()
    {
        return ((Base * Height) / 2);
    }

    public string AsString()
    {
        return $"Base is {Base}, height is {Height}";
    }
}
//Constructors
class Rectangle
{
    /* Immutability means that once an object is created, it cannot be changed or modified.
     * Fields should always be private, so if you want to expose the field to the outside world, create a Property.
    */
    //public readonly int Width; // A readonly field can only be assigned in the constructor or at the declaration whether in compilation-time or runtime .
    //public readonly int Height;
    const int NUMBER_OF_SIDES = 4; // A constant field must be assigned a value at declaration only on compilation time.

    private int _height;
    private int _width; // Backing Field

    //Property are special methods that sets and gets values
    public int Width 
    {
        //accessors getter and setter
        get
        {
            return _width;
        }
        private set
        {
            _width = value; //special variable as value
        }
    }

    public int Height { get; set; } // shorter syntax on declaring Property

    public Rectangle(int width, int height)
    {
        Width = GetLengthOrDefault(width, nameof(Width));
        Height = GetLengthOrDefault(height, nameof(Height));
    }

    //Getters and Setters
    public int GetHeight() => _height;

    public void SetHeight(int height)
    {
        if (height < 0) _height = height;
    }
    private int GetLengthOrDefault(int length, string name)
    {
        int defaultValueIfNonPositive = 1;
        if (length <= 0)
        {
            Console.WriteLine($"{name} must be positive. Defaulting to {defaultValueIfNonPositive}");
            return defaultValueIfNonPositive;
        }
        return length;
    }
    /* Computed Properties and Parameterless methods
     * Properties represent data that can be read and written. It should never bear a performance-heavy logic.
     * Parameterless methods represents actions.
     * 
     */
    public int CalculateArea() => Width * Height;
    public int CalculatePerimeter() => 2 * (Width + Height);

    public string Description => $"A {Width} by {Height} rectangle";
}

class MedicalAppointmentPrinter
{
    public void Print(MedicalAppointment medicalAppointment) => Console.WriteLine($"{medicalAppointment.GetPatientName} has an appointment on {medicalAppointment.GetDate}");
}

public class MedicalAppointment() // Method Overloading
{
    private string _patientName;
    private DateTime _date;

    public MedicalAppointment(string patientName, int daysFromNow = 7) : this ()
    {
        _patientName = patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
    }

    public DateTime GetDate => _date;
    public string GetPatientName => _patientName;

    public void Reschedule(DateTime newDate)
    {
        _date = newDate;
    }

    public void Reschedule(int month, int day)
    {
        _date = new DateTime(_date.Year, month, day);
    }
}

//Dog C# Program (OOP)
class Dog
{
    private string _name;
    private string _breed;
    private int _weight;
    private string weightDescription = string.Empty;

    public Dog(string name, string breed, int weight)
    {
        _name = name;
        _breed = breed;
        _weight = weight;
    }

    public Dog(string name, int weight, string breed = "mixed-breed")
    {
        _name = name;
        _breed = breed;
        _weight = weight;
    }

    public string Describe()
    {
        if (_weight < 5)
        {
            weightDescription = "tiny";
        }
        else if (_weight >= 5 && _weight < 30)
        {
            weightDescription = "medium";
        }
        else
        {
            weightDescription = "large";
        }
        return $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a {weightDescription} dog.";
    }
}

public class Order
{
    private DateTime _date;

    public string Item { get; }

    public DateTime Date
    {
        get => _date;
        set
        {
            if (_date.Year != DateTime.Now.Year)
            {
                _date = value;
            }
        }

    }

    public Order(string item, DateTime date)
    {
        Item = item;
        Date = date;
    }
}


class Person
{
    public string   Name { get; set; }
    public int YearOfBirth { get; init; } //init only setter in C# 9.0 sets the property only on initialization.
    /* Constructor and init 
     * The constructor is used to initialize the properties of a class. It must provide all the required parameters.
     * With init only setter, it is used to initialize the properties of a class.
    */


    //public Person(string name, int yearOfBirth)
    //{

    //}
}

public class DailyAccountState
{
    public int InitialState { get; }

    public int SumOfOperations { get; }

    public DailyAccountState(
        int initialState,
        int sumOfOperations)
    {
        InitialState = initialState;
        SumOfOperations = sumOfOperations;
    }

    public int EndOfDayState
    {
        get
        {
            return InitialState + SumOfOperations;
        }
    }

    public string Report
    {
        get => $"Day: {DateTime.Now.Day}, month: {DateTime.Now.Month}, year: {DateTime.Now.Year}, initial state: {InitialState}, end of day state: {EndOfDayState}";
    }

    /*Stateless means there is no memory of the past. Every transaction is performed as if it were being done for the very first time.
     * Stateful means that there is memory of the past. Previous transactions are remembered and may affect the current transaction.
     */
}

static class NumberToDayOfWeekTranslator
{
    public static string Translate(int number)
    {
        if (number <= 0 || number > 7)
        {
            return "Invalid day of the week";
        }

        if (number == 7)
        {
            return DayOfWeek.Sunday.ToString();
        }

        DayOfWeek dayOfWeek = (DayOfWeek)number;

        return dayOfWeek.ToString();
    }
}

public static class StringsTransformator
{
    public static string TransformSeparators(
        string input,
        string originalSeparator,
        string targetSeparator)
    {
        string[] separatedInput2Array = input.Split(originalSeparator);
        return string.Join(targetSeparator, separatedInput2Array);
    }
}