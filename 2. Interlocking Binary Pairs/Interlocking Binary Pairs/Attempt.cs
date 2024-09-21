namespace Interlocking_Binary_Pairs
{
    internal class Attempt
    {
        /*
            Write a function that checks if two non-negative integers make an "interlocking binary pair".
            
            Interlock
                numbers can be interlocked if their binary representations have no 1's in the same place
                comparisons are made by bit position, starting from right to left (see the examples below)
                when representations are of different lengths, the unmatched left-most bits are ignored

            Examples
                a = 9, b = 4
                    9 in binary = 1001
                    4 in binary =  100
                Here, no 1's chare any position, so the function returns true

                a = 3, b = 6
                    3 in binary =  11
                    6 in binary = 110
                Here, there is a 1 that shares a position, thus the function should return false
        */
        public bool Interlockable(int a, int b)
        {
            return false;
        }
    }
}
