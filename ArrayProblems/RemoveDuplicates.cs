using System;

public static class DuplicatesRemoval {
    public static int RemoveDuplicates(int[] nums) 
    {
        var neatArray = nums.ToArray().Distinct();
        int size = 0;

        foreach(var num in neatArray)
        {
            nums[size++] = num;
        }

        return size;
    }
}
