using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPlay : MonoBehaviour
{
	//Create pegs for user play type, add convenient files
	public void addPegsMethod()
	{
		for (int i = 0; i < CreateBoard.row; i++)
		{
			for (int j = 0; j < CreateBoard.col; j++)
			{
				if (CreateBoard.arr[i, j].type == 'p')
				{
					CreateBoard.pegs[i, j].AddComponent<GetMovement>();
					CreateBoard.pegs[i, j].AddComponent<Validation>();
					CreateBoard.pegs[i, j].AddComponent<MovePeg>();
					CreateBoard.pegs[i, j].AddComponent<CheckGame>();
				}
				else if (CreateBoard.arr[i, j].type == 'e')
				{
					CreateBoard.pegs[i, j].AddComponent<GetMovement>();
					CreateBoard.pegs[i, j].AddComponent<Validation>();
					CreateBoard.pegs[i, j].AddComponent<MovePeg>();
					CreateBoard.pegs[i, j].AddComponent<CheckGame>();
					CreateBoard.pegs[i, j].GetComponent<Renderer>().enabled = false;
				}
			}
		}
	}
}
