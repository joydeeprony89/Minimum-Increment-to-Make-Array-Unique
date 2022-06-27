using System;
using System.Collections.Generic;

namespace Minimum_Increment_to_Make_Array_Unique
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 3, 2, 1, 2, 1, 7 };
      Solution s = new Solution();
      var answer = s.MinIncrementForUnique(nums);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MinIncrementForUnique_Set(int[] nums)
    {
      int count = 0;
      Array.Sort(nums);
      HashSet<int> visited = new HashSet<int>();
      foreach (int n in nums)
      {
        int t = n;
        while (!visited.Add(t))
        {
          t++;
          count++;
        }
      }

      return count;
    }
    public int MinIncrementForUnique(int[] nums)
    {
      // Algo - We need to sort the array
      // After sort all the equal elements will be one after
      // we need to make this no as unique, a equal no can became non unique if we increse it to one
      // current no always should be atleast 1 + prev no or greater
      // if it is greater than the prev no need to increase
      // prev + 1 = expect, but if cur is same as expect then
      // expect - cur = no of increment we have to do to satisfy the ques need
      // after that we need to update the prev, prev = math.max(expect, cur);

      // Sort the Array
      Array.Sort(nums);
      int count = 0;
      int prev = nums[0];

      for (int i = 1; i < nums.Length; i++)
      {
        int expect = prev + 1;
        if (nums[i] > expect)
        {
          count += 0;
        }
        else
        {
          count += expect - nums[i];
        }
        prev = Math.Max(expect, nums[i]);
      }
      return count;
    }
  }
}
