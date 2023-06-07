using System;

public static class Extensions
{
    public static T[] RemoveAt<T>(this T[] source, int index)
    {
        return source.Where((_, i) => i != index).ToArray();
    }
}

public static class DuplicatesRemoval {
    public static int RemoveDuplicates(int[] nums) 
    {
        for(int i = 0; i < nums.Length - 1; i++)
        {
            if(nums[i] == nums[i + 1])
                nums = nums.RemoveAt(i);
        }
        return nums.Length;
    }
}
