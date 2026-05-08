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
        // Plan:
        // 1. Create an array of doubles with the size of 'length'
        // 2. Loop from 1 to 'length' (inclusive)
        // 3. At each iteration i, store (number * i) in the array at index (i - 1)
        // 4. Return filled array

        double[] result = new double[length]; // Step 1

        for (int i = 1; i <= length; i++) // Step 2
        {
            result[i - 1] = number * i; // Step 3
        }


        return result; // Step 4
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
        // Plan:
        // "Rotate right by amount" means the last 'amount' elements move to the front.
        // Example: {1,2,3,4,5,6,7,8,9}, amount=3 {7,8,9,1,2,3,4,5,6}
        // The last 3 elements {7,8,9} become the new front.

        // Using GetRange to slice the list into two parts:
        // "tail": the last 'amount' elements
        // starts at index (data.Count - amount), length = amount
        // "head": everything before the tail
        // starts at index 0, length = (data.Count - amount)
        
        // Steps:
        // 1. Slice out the tail using GetRange(data.Count - amount, amount)
        // 2. Slice out the head using GetRange(0, data.Count - amount)
        // 3. Clear the original list (or remove all elements)
        // 4. Add the tail first (it becomes the new front)
        // 5. Add the head after (it becomes the new back)

        List<int> tail = data.GetRange(data.Count - amount, amount); // Step 1
        List<int> head = data.GetRange(0, data.Count - amount); // Step 2

        data.Clear(); // Step 3
        data.AddRange(tail); // Step 4
        data.AddRange(head); // Step 5  


    }
}
