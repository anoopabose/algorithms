using System;


public static class LeetCode
{


    /// <summary>
    /// 7. Reverse Integer
    /// Given a signed 32-bit integer x, return x with its digits reversed. 
    /// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
    /// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static int Reverse(int x)
    {
        long result = 0;
        while (x != 0)
        {
            result = result * 10 + x % 10;
            x /= 10;
        }

        return (result > int.MaxValue || result < int.MinValue) ? 0 : (int)result;
    }

    // 29. Divide Two Integers
    /* Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
    The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.
    Return the quotient after dividing dividend by divisor.
    Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. 
    For this problem, if the quotient is strictly greater than 231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.
    */
    public static int Divide(int dividend, int divisor)
    {
        int result = 1;
        bool negativeNumber = false;
        if (divisor < 0 || dividend < 0)
        {
           result = -1;
            negativeNumber = true;
        }
        while (result != 0)
        {
            if (negativeNumber)
            {
                dividend += divisor;
                result--;
                if (dividend + divisor <= divisor)
                {
                    result++;
                    break;
                }
            }
            else
            {
                dividend -= divisor;
                result++;
            }

        }
        return result;
    }

}