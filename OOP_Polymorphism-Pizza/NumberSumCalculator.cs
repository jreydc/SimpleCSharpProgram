
namespace OOP_Polymorphism_Pizza;

public class NumberSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            if (ShallBeAdded(number))
            {
                sum += number;
            }
            
        }
        return sum;
    }

    protected virtual bool ShallBeAdded(int number)
    {
        return true;
    }
}

public class PositiveNumberSumCalculator : NumberSumCalculator
{
    protected override bool ShallBeAdded(int number)
    {
        return number > 0;
    }
}

//public class PositiveNumberSumCalculator
//{
//    public int Calculate(List<int> numbers)
//    {
//        int sum = 0;
//        foreach (var number in numbers)
//        {
//            if (number > 0)
//            {
//                sum += number;
//            }
//        }
//        return sum;
//    }
//}
