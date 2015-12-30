<Query Kind="Program" />

/*
Write a program to solve a Sudoku puzzle by filling the empty cells.

Empty cells are indicated by the character '.'.

You may assume that there will be only one unique solution.

*/
public void SolveSudoku(char[,] board) 
{
	if(board == null || board.GetLength(0) == 0)
	{
		return;
	}
	
	solve(board);
}

public bool solve(char[,] board)
{
   for(int i = 0; i < board.GetLength(0); i++)
   {
       for(int j = 0; j < board.GetLength(1); j++)
       {
           if(board[i,j] == '.')
           {
               for(char c = '1'; c <= '9'; c++)
               {
                   //trial. Try 1 through 9 for each cell
                   if(isValid(board, i, j, c))
                   {
                       board[i,j] = c; //Put c for this cell

                       if(solve(board))
                       {
                           return true; //If it's the solution return true
                       }
                       else
                       {
                           board[i,j] = '.'; //Otherwise go back
                       }
                   }
               }
               
               return false;
           }
       }
   }
   
   return true;
}

public bool isValid(char[,] board, int i, int j, char c)
{
   //Check colum
   for(int row = 0; row < 9; row++)
   {
       if(board[row,j] == c)  return false;
   }

   //Check row
   for(int col = 0; col < 9; col++)
   {
       if(board[i, col] == c) return false;
   }

   //Check 3 x 3 block
   for(int row = (i / 3) * 3; row < (i / 3) * 3 + 3; row++)
   {
       for(int col = (j / 3) * 3; col < (j / 3) * 3 + 3; col++)
       {
           if(board[row, col] == c) return false;
       }
   }
   
   return true;
}
