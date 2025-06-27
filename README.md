

## Overview

Summary of My Design
In this implementation (WordFindSearch), I created a simple, memory-efficient, and fast solution for scanning a matrix of characters to find matches from a given word stream. I precompute rows and columns from the matrix, and then check each word using a brute-force string.Contains across both dimensions.

I use a dictionary to track frequency of matched words and return the top 10 by count. The code avoids unnecessary allocations and favors readability and testability. For simplicity, I do not include reverse, diagonal, or regex-based matches.

It's a brute-force substring search using optimized C# built-in functions (Any, Includes, ToArray, getting the columns and rows on the pre/process). It works well within the 64x64 restriction(i didn't try with a large matrix) and could be further improved through parallelization if the word stream becomes extremely large.

Also I've created a new project for unit test, and I added the DI for the instance of the service class. 