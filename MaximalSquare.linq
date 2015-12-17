<Query Kind="Program" />

void Main()
{
	char[,] matrix = new char[,] {{'0', '1'}};
	
	MaximalSquare(matrix);
}

// Define other methods and classes here
	public int MaximalSquare(char[,] matrix) {
        
        if (matrix == null)
        {
            return 0;
        }
        
        int rowLength = matrix.GetLength(0);
        int columnLength = matrix.GetLength(1);
        
        int maxLength = rowLength > columnLength ? rowLength : columnLength;
        
        int maxSize = 0;
        for (int i = 1; i <= maxLength;i++)
        {
			bool foundSquare = false;
            // keep analyzing squares of this size (i) starting from index 0
			for (int row = 0; row < rowLength && !foundSquare; row++)
			{
				for (int j=0; j <= columnLength - i; j++)
				{               
					if(DetermineSquare(matrix, row, row+i, j, j+i))
					{
						int size = i * i;
						if(size > maxSize)
						{
							maxSize = size;
							foundSquare = true;
						}
					}               
				}
			}
        }
        
        return maxSize;
    }
    
    bool DetermineSquare(char[,] matrix, int rowstart, int rowEnd, int colstart, int colEnd)
    {
		int rowLen = matrix.GetLength(0);
		int colLen = matrix.GetLength(1);
        for(int i = rowstart; i < rowEnd; i++)
        {
            for (int j = colstart; j < colEnd; j++)
            {
                if(i >= rowLen || j >= colLen || matrix[i,j] != '1')
                {
                    return false;
                }
            }
        }
        
        return true;
    }
