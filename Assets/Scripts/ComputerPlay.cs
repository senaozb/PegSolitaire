using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlay : MonoBehaviour
{
    //Create pegs for computer play type, add convenient files and start the game
    public void addPegsMethod()
	{
		for (int i = 0; i < CreateBoard.row; i++)
		{
			for (int j = 0; j < CreateBoard.col; j++)
			{
				if (CreateBoard.arr[i, j].type == 'p')
				{
					CreateBoard.pegs[i, j].AddComponent<Validation>();
					CreateBoard.pegs[i, j].AddComponent<MovePeg>();
					CreateBoard.pegs[i, j].AddComponent<CheckGame>();
                }
				else if (CreateBoard.arr[i, j].type == 'e')
				{
					CreateBoard.pegs[i, j].AddComponent<Validation>();
					CreateBoard.pegs[i, j].AddComponent<MovePeg>();
					CreateBoard.pegs[i, j].AddComponent<CheckGame>();
                    CreateBoard.pegs[i, j].GetComponent<Renderer>().enabled = false;
				}
			}
		}

        playGame();
	}

    //Get the input randomly from this method and check validation
    private void getRandomInput()
    {
        bool res;
        do
        {
            int random1 = Random.Range(48, 48 + CreateBoard.col);
            int random2 = Random.Range(48, 48 + CreateBoard.row);
            int ranFlag = Random.Range(0, 4);
            char random = 'R';

            switch (ranFlag)
            {
                case 0:
                    random = 'R';
                    break;
                case 1:
                    random = 'L';
                    break;
                case 2:
                    random = 'U';
                    break;
                case 3:
                    random = 'D';
                    break;
            }

            CreateBoard.userIn[0] = (char)random1;
            CreateBoard.userIn[1] = (char)random2;
            CreateBoard.userIn[2] = '-';
            CreateBoard.userIn[3] = random;

            res = gameObject.GetComponent<Validation>().movementValid();

        } while (res == false);


        //Set the first and second pegs' coordinates
        Validation.firstY = CreateBoard.userIn[0] - '0';
        Validation.firstX = CreateBoard.userIn[1] - '0';

        switch (CreateBoard.userIn[3])
        {
            case 'R':
                Validation.secondY = CreateBoard.userIn[0] - '0' + 2;
                Validation.secondX = CreateBoard.userIn[1] - '0';
                break;
            case 'L':
                Validation.secondY = CreateBoard.userIn[0] - '0' - 2;
                Validation.secondX = CreateBoard.userIn[1] - '0';
                break;
            case 'U':
                Validation.secondY = CreateBoard.userIn[0] - '0';
                Validation.secondX = CreateBoard.userIn[1] - '0' - 2;
                break;
            case 'D':
                Validation.secondY = CreateBoard.userIn[0] - '0';
                Validation.secondX = CreateBoard.userIn[1] - '0' + 2;
                break;
        }
    }

    //Perform the movements with 1 second wait in a coroutine
    private void playGame()
    {
        CheckGame.result = 0;
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        do
        {
            getRandomInput();
            gameObject.GetComponent<MovePeg>().movePeg();
            yield return new WaitForSeconds(1);

        } while (CheckGame.result == 0);
    }
}
