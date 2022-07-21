using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeg : MonoBehaviour
{
    public void movePeg()
    {
		//Update the array in terms of the given movement
		int row = CreateBoard.userIn[1] - 48;
		int col = CreateBoard.userIn[0] - 48;
		char dir = CreateBoard.userIn[3];

		switch (dir)
		{
			case 'R':
				CreateBoard.arr[row,col].type = 'e';
				CreateBoard.arr[row,col + 1].type = 'e';
				CreateBoard.arr[row,col + 2].type = 'p';
				break;
			case 'L':
				CreateBoard.arr[row,col].type = 'e';
				CreateBoard.arr[row,col - 1].type = 'e';
				CreateBoard.arr[row,col - 2].type = 'p';
				break;
			case 'U':
				CreateBoard.arr[row,col].type = 'e';
				CreateBoard.arr[row - 1,col].type = 'e';
				CreateBoard.arr[row - 2,col].type = 'p';
				break;
			case 'D':
				CreateBoard.arr[row,col].type = 'e';
				CreateBoard.arr[row + 1,col].type = 'e';
				CreateBoard.arr[row + 2,col].type = 'p';
				break;
		}
		movementAnimation();
		gameObject.GetComponent<CheckGame>().checkGame();
	}


	//Change the location of pegs on the board using renderer component
	private void movementAnimation()
    {
		CreateBoard.pegs[(int)Validation.firstX, (int)Validation.firstY].GetComponent<Renderer>().enabled = false;
		CreateBoard.pegs[(int)Validation.secondX, (int)Validation.secondY].GetComponent<Renderer>().enabled = true;

		switch (CreateBoard.userIn[3])
		{
			case 'R':
				CreateBoard.pegs[(int)Validation.firstX, (int)Validation.firstY+1].GetComponent<Renderer>().enabled = false;
				break;
			case 'L':
				CreateBoard.pegs[(int)Validation.firstX, (int)Validation.firstY-1].GetComponent<Renderer>().enabled = false;
				break;
			case 'U':
				CreateBoard.pegs[(int)Validation.firstX-1, (int)Validation.firstY].GetComponent<Renderer>().enabled = false;
				break;
			case 'D':
				CreateBoard.pegs[(int)Validation.firstX+1, (int)Validation.firstY].GetComponent<Renderer>().enabled = false;
				break;
		}
	}
}
