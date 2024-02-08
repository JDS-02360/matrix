/*

TODO:
    Implement multiplication - DONE
    Implement addition - DONE
    Split output matrix on arrays (m1[0], m1[1]) - DONE
    Write exceptions to log file - DONE
    Add zeroes to beginning of numbers, up to the longest number of digits in the coloumn
        05 21 048
        37 09 110
        02 70 006
    Get input matrices from user

*/

int[][] m1 = [
    [0, 1, 3],
    [4, 2, 5],
    [9, 6, 1]
];

int[][] m2 = [
    [8, 3, 4],
    [2, 5, 0],
    [1, 6, 7]
];

// Replace with wherever you want log.txt to go
string path = "./log.txt";

void ExceptionLog(Exception e)
{
    using (StreamWriter streamWriter = new(path, true))
    {
        streamWriter.WriteLine(e);
    }
}

int[][] MatrixMultiply(int[][] m1, int[][] m2)
{
    int[][] output = new int[m1.Length][];

    try
    {
        for (int idx = 0; idx < output.Length; idx++)
        {
            output[idx] = new int[m1[idx].Length];
        }

        int rowIdx = 0;
        
        foreach (int[] row in m1)
        {
            int colIdx = 0;
            
            foreach (int num in row)
            {
                int sum = 0;
                
                for (int idx = 0; idx < m1[0].Length; idx++)
                {
                    sum += m1[rowIdx][idx] * m2[idx][colIdx];
                }

                output[rowIdx][colIdx] = sum;

                colIdx++;
            }

            rowIdx++;
        }
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }

    return output;
}

int[][] MatrixAdd(int[][] m1, int[][] m2)
{
    int[][] output = new int[m1.Length][];

    try
    {
        for (int idx = 0; idx < output.Length; idx++)
        {
            output[idx] = new int[m1[idx].Length];
        }

        for (int i = 0; i < m1.Length; i++)
        {
            for (int j = 0; j < m1[i].Length; j++)
            {
                output[i][j] = m1[i][j] + m2[i][j];
            }
        }
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }

    return output;
}

void MatrixWrite(int[][] m)
{
    try
    {
        foreach (int[] row in m)
        {
            foreach (int num in row)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();
        }

        // So that there is a gap between output matrices
        Console.WriteLine();
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }
}

int[][] m3 = MatrixMultiply(m1, m2);
int[][] m4 = MatrixAdd(m1, m2);

MatrixWrite(m3);
MatrixWrite(m4);
