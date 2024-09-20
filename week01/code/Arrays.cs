public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //STEP1: We first define the function and make sure it accepts two parameters - one for the number and the second for the length of the list of multiples of that number.
        //STEP2: Create an array of doubles with the length from step 1
        //STEP3: Use the "for" loop to fill the above array with multiples of the number. The first element in the set is the number, the second is number*2 and so forth until the length is reached.
        //STEP4: Return the populated array
        double [] multiples = new double[length];
        for (int i=0; i <length; i++)
        {
            multiples[i] = number * (i+1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //STEP 1: The first thing to do is define the RotateListRight function to two parameters, a list and the the amount the List should rotate
        //STEP 2: Write a method to check if the amout is not less than 1 or greater than the number of elements in the list
        //STEP 3: Apply modulo to create effective rotation. Modulo handles cases where the amount is greater than the data count.
        //STEP 4: You break the list into two slices. I found it better to use GetRange to create the functions.
        //STEP 5: Clear the original list
        //STEP 6: Add the rotated lists by adding the last part first then the first.

        if (amount < 1|| amount > data.Count)
        {
            throw new  ArgumentOutOfRangeException("amount", "Amount must be between 1 and the count of the data.");
        }

        int effectiveAmount = amount % data.Count;

        var lastpart = data.GetRange(data.Count - effectiveAmount, effectiveAmount);
        var firstpart = data.GetRange(0,data.Count- effectiveAmount);
        
        data.Clear();
        data.AddRange(lastpart);
        data.AddRange(firstpart);


    }





}
