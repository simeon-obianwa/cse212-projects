using System;
using System.Collections.Generic;
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
        // Implememtation plan for the MultiplesOf function:
        // I implemented MultiplesOf to generate an array of multiples using a simple for loop that multiplies the base number by the loop index.
        // 1. Create a new double array with the specified length.
        // 2. Create a loop that iterates length times, from index 0 up to length - 1.
        // 3. Inside the loop, I calculated the multiple for the current position by multiplying number by i.
        // 4. Take the first element as 1 * number, the element at index i will be (i + 1) * number.
        // 5. Assign the calculated value to the current index of the array.
        // 6. Then, store the calculated multiple in the array at index 'i - 1'.
        // 7. Return the populated array, after the loop finishes.

        double[] multiples = new double[length];
        for (int i = 1; i <= length; i++)
        {
            multiples[i - 1] = number * i;
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Implememtation plan for the RotateListRight function:
        // I implemented RotateListRight using list slicing techniques using GetRange, RemoveRange, and InsertRange to rotate the elements in-place.
        // 1. Determine the split index where the list should be divided using data.Count - amount.
        // 2. Extract the last amount elements from the list using the GetRange method.
        // 3. This will create a temporary list containing the elements that will move to the front.
        // 4. Remove these last amount elements from the original list using RemoveRange.
        // 5. Insert the extracted elements at the beginning index 0 of the original list using InsertRange.
        // 6. This will rotates the list to the right by the specified amount in place.

        int splitIndex = data.Count - amount;

        // Getting slice of the list that needs to be moved to the front
        List<int> endPart = data.GetRange(splitIndex, amount);

        // Removing the slice from its original position at the end
        data.RemoveRange(splitIndex, amount);

        // Inserting the slice at the beginning of the list
        data.InsertRange(0, endPart);
    }
}
