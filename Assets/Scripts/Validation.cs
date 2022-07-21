using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation : MonoBehaviour
{
	public static float firstX, firstY, secondX, secondY;
	private char[] inp = new char[4];

    //Check if it is a valid movement by checking the difference between coordinates
    public void validate()
	{
		//For left and right, the difference should be 2 between y coordinates 
		if ((firstX == secondX) && (Mathf.Abs(firstY - secondY) == 2))
		{
			if (firstY - secondY == 2)
				inp[3] = 'L';
			else
				inp[3] = 'R';

			inp[0] = (char)(firstY + '0');
			inp[1] = (char)(firstX + '0');
			inp[2] = '-';

			CreateBoard.userIn = inp;
			if (movementValid() == true)
			{
				gameObject.GetComponent<MovePeg>().movePeg();
			}
		}
		//For up and down, the difference should be 2 between x coordinates 
		else if ((firstY == secondY) && (Mathf.Abs(firstX - secondX) == 2))
		{
			if (firstX - secondX == 2)
				inp[3] = 'U';
			else
				inp[3] = 'D';

			inp[0] = (char)(firstY + '0');
			inp[1] = (char)(firstX + '0');
			inp[2] = '-';

			CreateBoard.userIn = inp;
			if (movementValid() == true)
			{
				gameObject.GetComponent<MovePeg>().movePeg();
			}
		}
	}

	//Check if this movement can be done 
	public bool movementValid()
	{
		int rowIn = CreateBoard.userIn[1] - 48;
		int colIn = CreateBoard.userIn[0] - 48;
		char dir = CreateBoard.userIn[3];
		int max_r = CreateBoard.row - 1;
		int max_c = CreateBoard.col - 1;

		if (CreateBoard.arr[rowIn,colIn].type == 'o' || CreateBoard.arr[rowIn,colIn].type == 'e')
			return false;

		//If there is no peg and empty cell after the chosen peg then return false
		if (dir == 'R')
		{
			if (max_c - colIn < 2)
				return false;
			if (!(CreateBoard.arr[rowIn,colIn + 1].type == 'p' && CreateBoard.arr[rowIn,colIn + 2].type == 'e'))
				return false;
		}
		else if (dir == 'L')
		{
			if (colIn < 2)
				return false;
			if (!(CreateBoard.arr[rowIn,colIn - 1].type == 'p' && CreateBoard.arr[rowIn,colIn - 2].type == 'e'))
				return false;
		}
		else if (dir == 'U')
		{
			if (rowIn < 2)
				return false;
			if (!(CreateBoard.arr[rowIn - 1,colIn].type == 'p' && CreateBoard.arr[rowIn - 2,colIn].type == 'e'))
				return false;
		}
		else if (dir == 'D')
		{
			if (max_r - rowIn < 2)
				return false;
			if (!(CreateBoard.arr[rowIn + 1,colIn].type == 'p' && CreateBoard.arr[rowIn + 2,colIn].type == 'e'))
				return false;
		}

		return true;
	}
}
