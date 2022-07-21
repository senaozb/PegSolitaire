using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGame : MonoBehaviour
{
	//Check if the game is ended or not
	public static int result = 0;

	//Check if the pegs are stuck
    private int checkFull(int indR, int indC, int type, int locType)
	{
		//locType indicates the location of peg to prevent the memory errors(e.g. 1.column or the last row)
		int count = 0, fl = 0;

		for (int j = 0; j < CreateBoard.col; j++) //Full row control
		{
			if (CreateBoard.arr[indR,j].type == 'p')
				++count;
			else if (CreateBoard.arr[indR,j].type == 'e') //If there is an empty area then reset counter
			{
				count = 0;
				fl = 1;
				break;
			}
		}

		if (fl == 0)
		{
			//Checks if up and down rows are empty, if not so returns 0

			for (int k = 0; k < CreateBoard.col; k++)
			{
				if (locType == 0 || locType == 3 || locType == 4)
				{
					if (CreateBoard.arr[indR,k].type == 'p' && (CreateBoard.arr[indR - 1,k].type == 'p' || CreateBoard.arr[indR + 1,k].type == 'p'))
						return 0;
				}
				else if (locType == 1)
				{
					if (CreateBoard.arr[indR,k].type == 'p' && CreateBoard.arr[indR + 1,k].type == 'p')
						return 0;
				}
				else if (locType == 2)
				{
					if (CreateBoard.arr[indR,k].type == 'p' && CreateBoard.arr[indR - 1,k].type == 'p')
						return 0;
				}
			}
			return count;

		}

		count = 0;

		for (int i = 0; i < CreateBoard.row; i++) //Full column control
		{
			if (CreateBoard.arr[i,indC].type == 'p')
				++count;
			else if (CreateBoard.arr[i,indC].type == 'e')
				return 0;
		}
		for (int l = 0; l < CreateBoard.row; l++) //Checks if the right and left columns are empty
		{
			if (locType == 0 || locType == 1 || locType == 2)
			{
				if (CreateBoard.arr[l,indC].type == 'p' && (CreateBoard.arr[l,indC - 1].type == 'p' || CreateBoard.arr[l,indC + 1].type == 'p'))
					return 0;
			}
			else if (locType == 3)
			{
				if (CreateBoard.arr[l,indC].type == 'p' && CreateBoard.arr[l,indC + 1].type == 'p')
					return 0;
			}
			else if (locType == 4)
			{
				if (CreateBoard.arr[l,indC].type == 'p' && CreateBoard.arr[l,indC - 1].type == 'p')
					return 0;
			}

		}

		return count;
	}

	//Check if there is a peg around the pegs
	public void checkGame()
	{
		int rs = 0;
		int flag = 0;

		for (int i = 0; i < CreateBoard.row; i++)
		{
			if (flag == 1)
				break;

			for (int j = 0; j < CreateBoard.col; j++)
			{
				if (CreateBoard.arr[i,j].type == 'p') //Check around the peg if there are other pegs
				{
					if (i != 0 && j != 0 && i != CreateBoard.row - 1 && j != CreateBoard.col - 1)
					{
						if (!(CreateBoard.arr[i,j + 1].type != 'p' && CreateBoard.arr[i,j - 1].type != 'p'
							&& CreateBoard.arr[i + 1,j].type != 'p' && CreateBoard.arr[i - 1,j].type != 'p'))
						{
							if (checkFull(i, j, 0, 0) != 0)
								++rs;
							else
							{
								flag = 1;
								rs = 0;
								break;
							}
						}
						else
							++rs;
					}
					else if (i == 0)
					{
						if (!(CreateBoard.arr[i,j + 1].type != 'p' && CreateBoard.arr[i,j - 1].type != 'p'
							&& CreateBoard.arr[i + 1,j].type != 'p'))
						{
							if (checkFull(i, j, 0, 1) != 0)
								++rs;
                            else
                            {
								flag = 1;
								rs = 0;
								break;
                            }
						}
						else
							++rs;
					}
					else if (i == CreateBoard.row - 1)
					{
						if (!(CreateBoard.arr[i,j + 1].type != 'p' && CreateBoard.arr[i,j - 1].type != 'p'
							&& CreateBoard.arr[i - 1,j].type != 'p'))
						{
							if (checkFull(i, j, 0, 2) != 0)
								++rs;
							else
							{
								flag = 1;
								rs = 0;
								break;
							}
						}
						else
							++rs;
					}
					else if (j == 0)
					{
						if (!(CreateBoard.arr[i,j + 1].type != 'p' && CreateBoard.arr[i + 1,j].type != 'p'
							&& CreateBoard.arr[i - 1,j].type != 'p'))
						{
							if (checkFull(i, j, 0, 3) != 0)
								++rs;
							else
							{
								flag = 1;
								rs = 0;
								break;
							}
						}
						else
							++rs;
					}
					else if (j == CreateBoard.col - 1)
					{
						if (!(CreateBoard.arr[i,j - 1].type != 'p' && CreateBoard.arr[i + 1,j].type != 'p'
							&& CreateBoard.arr[i - 1,j].type != 'p'))
						{
							if (checkFull(i, j, 0, 4) != 0)
								++rs;
							else
							{
								flag = 1;
								rs = 0;
								break;
							}
						}
						else
							++rs;
					}
				}
			}
		}

		//End the game and change the scene
		if (rs != 0)
		{
			result = rs;
			CreateBoard.fileType = 0;
			SceneManager.LoadScene("Result", LoadSceneMode.Single);
		}
	}
}
