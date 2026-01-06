<Query Kind="Program" />

void Main()
{
	var twoDArray = new[] { new[] { '1', '2', '.', '.', '3', '.', '.', '.', '.' }, new[] { '4', '.', '.', '5', '.', '.', '.', '.', '.' }, new[] { '.', '9', '8', '.', '.', '.', '.', '.', '3' }, new[] { '5', '.', '.', '.', '6', '.', '.', '.', '4' }, new[] { '.', '.', '.', '8', '.', '3', '.', '.', '5' }, new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' }, new[] { '.', '.', '.', '.', '.', '.', '2', '.', '.' }, new[] { '.', '.', '.', '4', '1', '9', '.', '.', '8' }, new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }};
 	var result = IsValidSudoku(twoDArray);
	result.Dump();

}

/*
   You are given a 9 x 9 Sudoku board board. A Sudoku board is valid if the following rules are followed:

    Each row must contain the digits 1-9 without duplicates.
    Each column must contain the digits 1-9 without duplicates.
    Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without duplicates.

*/

/*
Learnings
1. HashSet<int>.Add returns a boolean result, if the addition was succesful or the element already exists
2. Remember to initialize the new Column and Grid HashSet, if they don't already exist
3. FindGridIndex was a most critical function.
*/
// r=0,c=0 ->grid=0
// r=0,c=5 ->grid=1
// r=4,c=8 ->grid=5
// r=8,c=8 ->grid=8;
int FindGridHashSetIndex(int r, int c)
{
	int gridIndex = (r / 3) * 3 + (c / 3);
	return gridIndex;
}

public bool IsValidSudoku(char[][] board)
{
	if (board == null)
	{
		return false;
	}

	// if row count is not 9, it is not a valid board
	if (board.Length != 9)
	{
		return false;
	}

	// create hashset for Each row and Each column and each 9 square
	// traverse once the complete board and break if there is a conflict.
	var rowHashSets = new Dictionary<int, HashSet<int>>();
	var colHashSets = new Dictionary<int, HashSet<int>>();
	var gridHashSets = new Dictionary<int, HashSet<int>>();
	for (int r = 0; r < 9; r++)
	{
		if (board[r].Length != 9)
		{
			// it is not a valid sudoku board;
			return false;
		}
		rowHashSets[r] = new HashSet<int>();
		for (int c = 0; c < 9; c++)
		{
			// add to rowHashSet
			var rowCheck = this.TryAddInHashSet(board[r][c], rowHashSets[r]);
			if (!rowCheck)
			{
				// addition in row hashSets failed
				return false;
			}

			// column hashSet;
			if (colHashSets.ContainsKey(c))
			{
				var colCheck = this.TryAddInHashSet(board[r][c], colHashSets[c]);
				if (!colCheck)
				{
					// addition to a column HashSet failed
					return false;
				}
			}
			else
			{
				colHashSets[c] = new HashSet<int>();
				colHashSets[c].Add(board[r][c]);
			}

			// grid hashSet;
			var gridIndex = FindGridHashSetIndex(r, c);
			if (gridHashSets.ContainsKey(gridIndex))
			{
				var gridResult = this.TryAddInHashSet(board[r][c], gridHashSets[gridIndex]);
				if (!gridResult)
				{
					// failed addition in grid
					return false;
				}
			}
			else
			{
				gridHashSets[gridIndex] = new HashSet<int>();
				gridHashSets[gridIndex].Add(board[r][c]);
			}
		}
	}

	// it passed all checks
	return true;
}

bool TryAddInHashSet(char digit, HashSet<int> dupe)
{
	if (!Char.IsDigit(digit))
	{
		// We treat all non-digit characters the same and ignore it.
		return true;
	}
	if (digit == '0')
	{
		// found a non valid digit in the board;
		return false;
	}

	var addResult = dupe.Add(digit);
	return addResult;
}



