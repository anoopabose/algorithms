using System;

public static class HackerRank
{

    /**

There is a sequence of words in CamelCase as a string of letters, , having the following properties:

It is a concatenation of one or more words consisting of English letters.
All letters in the first word are lowercase.
For each of the subsequent words, the first letter is uppercase and rest of the letters are lowercase.
Given , determine the number of words in .

Example

There are  words in the string: 'one', 'Two', 'Three'.

*/
    public static int camelcase(string s)
    {
        int result = 1;
        foreach (char c in s)
        {
            if (char.IsUpper(c))
            {
                result++;
            }
        }

        return result;
    }

    /***
    Louise joined a social networking site to stay in touch with her friends. The signup page required her to input a name and a password. However, the password must be strong. The website considers a password to be strong if it satisfies the following criteria:

    Its length is at least .
    It contains at least one digit.
    It contains at least one lowercase English character.
    It contains at least one uppercase English character.
    It contains at least one special character. The special characters are: !@#$%^&*()-+
    She typed a random string of length  in the password field but wasn't sure if it was strong. Given the string she typed, can you find the minimum number of characters she must add to make her password strong?

    Note: Here's the set of types of characters in a form you can paste in your solution:

    numbers = "0123456789"
    lower_case = "abcdefghijklmnopqrstuvwxyz"
    upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    special_characters = "!@#$%^&*()-+"
    **/
    public static int minimumNumber(int n, string password)
    {
        var numbers = "0123456789";
        var lower_case = "abcdefghijklmnopqrstuvwxyz";
        var upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var special_characters = "!@#$%^&*()-+";
        // Return the minimum number of characters to make the password strong

        int result = 0;

        bool hasNumber = password.IndexOfAny(numbers.ToCharArray()) >= 0;
        bool hasLowerCase = password.IndexOfAny(lower_case.ToCharArray()) >= 0;
        bool hasUpperCase = password.IndexOfAny(upper_case.ToCharArray()) >= 0;
        bool hasSpecialCharacter = password.IndexOfAny(special_characters.ToCharArray()) >= 0;

        if (!hasNumber)
        {
            result++;
        }

        if (!hasLowerCase)
        {
            result++;
        }

        if (!hasUpperCase)
        {
            result++;
        }

        if (!hasSpecialCharacter)
        {
            result++;
        }

        // Length requirement 
        if (6 - n > 0 && result < 6 - n)
        {
            result = 6 - n;
        }


        return result;
    }

    /*
    Given a string, remove characters until the string is made up of any two alternating characters. 
    When you choose a character to remove, all instances of that character must be removed. Determine the longest string possible that contains just two alternating letters.
    Example
    Delete a, to leave bcdbd. Now, remove the character c to leave the valid string bdbd with a length of 4. Removing either b or d at any point would not result in a valid string. Return .
    Given a string , convert it to the longest possible string  made up only of alternating characters. Return the length of string . If no string  can be formed, return .
    Function Description
    Complete the alternate function in the editor below.
    alternate has the following parameter(s):
    string s: a string
    Returns.
    int: the length of the longest valid string, or  if there are none
    */
    public static int alternate(string s)
    {
        List<string> comb = new List<string>();
        char[] chars = s.ToCharArray();
        int result = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            Console.WriteLine($"i = {i} CHARS[i] : {chars[i]}");
            for (int j = i + 1; j < chars.Length; j++)
            {
                Console.WriteLine($"\tj = {j} CHARS[j] : {chars[j]}");
                if (chars[i] == chars[j])
                {
                    continue;
                }

                int count = 0;
                char lastChar = ' ';
                string combimation = "";
                for (int k = 0; k < chars.Length; k++)
                {
                    Console.WriteLine($"\t\tchars[k] : {chars[k]}");
                    Console.WriteLine($"\t\tchars[k]: {chars[k]} == chars[i]: {chars[i]} || chars[k]: {chars[k]} == chars[j]:{chars[j]}");
                    if (chars[k] == chars[i] || chars[k] == chars[j])
                    {
                        Console.WriteLine($"\t\t\tchars[k]: {chars[k]} == lastChar: {lastChar}");
                        if (chars[k] == lastChar)
                        {
                            count = 0;
                            Console.WriteLine($"\t\t\t** count = {count}");
                            combimation = "";
                            break;
                        }

                        lastChar = chars[k];
                        combimation += lastChar;
                        count++;
                        Console.WriteLine($"\t\t\t* count = {count}");
                        Console.WriteLine($"\t\t\t*COMBIMATION = {combimation}");


                    }
                    Console.WriteLine();
                }
                if (combimation.Length > 0)
                {
                    comb.Add(combimation);
                    Console.WriteLine($"\tCOMBIMATION = {combimation}");
                }


                if (count > result)
                {
                    result = count;
                }

                Console.WriteLine($"\t\tCOUNT = {count}");
                Console.WriteLine();
            }


        }

        foreach (var item in comb)
        {
            Console.WriteLine($"COMBINATION: {item}");
        }

        return result;

    }



}