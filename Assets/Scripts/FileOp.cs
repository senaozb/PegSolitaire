using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileOp : MonoBehaviour
{
    //This class operates the file operations

    public static void WriteFile()
    {
        string path = "Assets/Resources/game.txt";
        StreamWriter writer = new StreamWriter(path, false);

        //Write the current array to the file converting every row into a string
        char[] temp = new char[CreateBoard.col];
        for (int i = 0; i < CreateBoard.row; i++)
        {
            for (int j = 0; j < CreateBoard.col; j++)
            {
                temp[j] = CreateBoard.arr[i, j].type;
            }

            string str = new string(temp);
            writer.WriteLine(str);
        }
        writer.WriteLine(CreateBoard.chosenType);
        writer.Close();
    }

    //File should include a defined type array and the number indicating the type
    public static void ReadFile()
    {
        CreateBoard.Cell[,] board = new CreateBoard.Cell[1, 1];
        int r = 0, c = 0, flag = 0;
        string path = "Assets/Resources/game.txt";
        StreamReader inp = new StreamReader(path);

        //Read the file and store the saved array
        int sz = 0;
        while (!inp.EndOfStream)
        {
            string inpLine = inp.ReadLine();
            char[] charArr = inpLine.ToCharArray();
            
            if(flag == 0)
            {
                //Create a convenient array first
                board = new CreateBoard.Cell[inpLine.Length, inpLine.Length];
                sz = inpLine.Length;
                CreateBoard.col = sz;
                CreateBoard.row = sz;
                flag = 1;
            }

            if(r < sz)
            {
                foreach (char ch in charArr)
                {
                    CreateBoard.Cell cell = new CreateBoard.Cell(r, c, ch);
                    board[r, c] = cell;
                    c++;
                }
                r++;
                c = 0;
            }
            else if(r == sz)
            {
                CreateBoard.chosenType = charArr[0] - '0';
                break;
            }
        }

        CreateBoard.arr = board;
        CreateBoard.fileType = 1;

        inp.Close();

    }
}
