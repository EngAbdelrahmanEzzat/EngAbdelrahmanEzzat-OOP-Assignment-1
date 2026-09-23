public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        Array.Sort(nums);
        int begin = 0;
        int end = nums.Length - 1;
        int count = 0;
        while (begin < end)
        {
            if (nums[begin] + nums[end] == k)
            {
                count++;
                begin++;
                end--;
            }
            else if (nums[begin] + nums[end] < k)
            {
                begin++;
            }
            else
            {
                end--;
            }
        }
        return count;


    }
}