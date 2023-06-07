// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

var array = new[] {1, 1, 2, 2, 3, 4, 5, 6, 7};
var expectedNums = new[] {1, 2, 3, 4, 5, 6, 7}; // The expected answer with correct length

int k = DuplicatesRemoval.RemoveDuplicates(array); // Calls your implementation

Debug.Assert(k == expectedNums.Length);

for (int i = 0; i < k; i++)
{
   Debug.Assert(array[i] == expectedNums[i]);
}