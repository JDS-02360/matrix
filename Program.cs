using System.Text;

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

int[][] MatrixGet()
{
    Start:
    List<int[]> output = new List<int[]>();

    Console.WriteLine("Enter each row of the matrix, each on a new line (an empty string finishes the matrix):");

    try
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            string[] splitInput = input.Split(' ');
            int[] row = new int[splitInput.Length];

            for (int i = 0; i < splitInput.Length; i++)
            {
                if (int.TryParse(splitInput[i], out int value))
                {
                    row[i] = value;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again: {0}", splitInput[i]);
                    goto Start;
                }
            }

            output.Add(row);
        }
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }

    return output.ToArray();;
}

void MatrixWrite(int[][] m)
{
    try
    {
        string[][] output = new string[m.Length][];
        string[][] columns = new string[m.Length][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = new string[m[i].Length];
            columns[i] = new string[m[i].Length];
        }

        for (int i = 0; i < m.Length; i++)
        {
            for (int j = 0; j < m[i].Length; j++)
            {
                output[i][j] = m[i][j].ToString();
            }
        }

        for (int i = 0; i < output.Length; i++)
        {
            for (int j = 0; j < output[i].Length; j++)
            {
                for (int k = 0; k < output.Length; k++)
                {
                    columns[k][j] = output[j][k];
                }
            }
        }

        string[] longest = new string[columns.Length];

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                longest[i] = columns[i].OrderByDescending(s => s.Length).First();
            }
        }

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                StringBuilder stringBuilder = new(columns[i][j]);

                while (columns[i][j].Length < longest[i].Length)
                {
                    columns[i][j] = stringBuilder.Insert(0, "0").ToString();
                }
            }
        }

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                for (int k = 0; k < columns.Length; k++)
                {
                    output[k][j] = columns[j][k];
                }
            }
        }

        foreach (string[] row in output)
        {
            foreach (string str in row)
            {
                Console.Write($"{str} ");
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

int[][] m1 = MatrixGet();
int[][] m2 = MatrixGet();

int[][] m3 = MatrixMultiply(m1, m2);
int[][] m4 = MatrixAdd(m1, m2);

Console.WriteLine("Matrix 1 * Matrix 2:");
MatrixWrite(m3);

Console.WriteLine("Matrix 1 + Matrix 2:");
MatrixWrite(m4);
