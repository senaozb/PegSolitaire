using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateBoard : MonoBehaviour
{
	public static Cell[,] arr;
	public static GameObject[,] pegs;
	public static int row = 7; //Default values
	public static int col = 7; //Default values
	public static int chosenType = 1;
	public static int gameType = 1;
	public static int fileType = 0;
	public Text title;
	public Transform conT;
	public GameObject Model1;
	public GameObject Model2;
	public GameObject Model3;
	public GameObject Model4;
	public GameObject Model5;
	public GameObject ModelPeg;
	public Material newMaterial;
	public Button button;

	public static char[] userIn = new char[4];
	public static int counter = 0;
	
	// Add save button onto game scene and create array and board
	void Start()
    {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		if (fileType == 0)
			createArr();
        else
        {
			switch (chosenType)
			{
				//Change the title
				case 1:
					title.text = "Type: 1";
					break;
				case 2:
					title.text = "Type: 2";
					break;
				case 3:
					title.text = "Type: 3";
					break;
				case 4:
					title.text = "Type: 4";
					break;
				case 5:
					title.text = "Type: 5";
					break;
			}
		}
		board();
		createPegs();
    }

	void TaskOnClick()
	{
		fileType = 0;
		FileOp.WriteFile();
		SceneManager.LoadScene("Input", LoadSceneMode.Single);
	}

	// Cell is an inner class and is used to store the info of each cell such as coordinates and type 
	public class Cell
	{
		// Variable showing the type of cell (empty, peg, out) 
		public char type;
		// Variable showing the row index 
		public int coorR;
		// Variable showing the column index 
		public int coorC;

		public Cell()
		{
			coorR = -1;
			coorC = -1;
			type = 'x';
		}

		public Cell(int a, int b, char t)
		{
			coorR = a;
			coorC = b;
			type = t;
		}
	}

	//These are the methods to create the array 
	private void type1()
	{
		Cell[,] temp = {{new Cell(0, 0,  'o'), new Cell(0, 1,  'o'), new Cell(0, 2,  'p'), new Cell(0, 3,  'p'), new Cell(0, 4,  'p'), new Cell(0, 5,  'o'), new Cell(0, 6,  'o')},
						{new Cell(1, 0,  'o'), new Cell(1, 1,  'p'), new Cell(1, 2,  'p'), new Cell(1, 3,  'p'), new Cell(1, 4,  'p'), new Cell(1, 5,  'p'), new Cell(1, 6,  'o')},
						{new Cell(2, 0,  'p'), new Cell(2, 1,  'p'), new Cell(2, 2,  'p'), new Cell(2, 3,  'e'), new Cell(2, 4,  'p'), new Cell(2, 5,  'p'), new Cell(2, 6,  'p')},
						{new Cell(3, 0,  'p'), new Cell(3, 1,  'p'), new Cell(3, 2,  'p'), new Cell(3, 3,  'p'), new Cell(3, 4,  'p'), new Cell(3, 5,  'p'), new Cell(3, 6,  'p')},
						{new Cell(4, 0,  'p'), new Cell(4, 1,  'p'), new Cell(4, 2,  'p'), new Cell(4, 3,  'p'), new Cell(4, 4,  'p'), new Cell(4, 5,  'p'), new Cell(4, 6,  'p')},
						{new Cell(5, 0,  'o'), new Cell(5, 1,  'p'), new Cell(5, 2,  'p'), new Cell(5, 3,  'p'), new Cell(5, 4,  'p'), new Cell(5, 5,  'p'), new Cell(5, 6,  'o')},
						{new Cell(6, 0,  'o'), new Cell(6, 1,  'o'), new Cell(6, 2,  'p'), new Cell(6, 3,  'p'), new Cell(6, 4,  'p'), new Cell(6, 5,  'o'), new Cell(6, 6,  'o')}};

		arr = temp;
		col = arr.GetLength(1);
		row = arr.GetLength(0);
	}
	private void type2()
	{
		Cell[,] temp = {{new Cell(0, 0,  'o'), new Cell(0, 1,  'o'), new Cell(0, 2,  'o'), new Cell(0, 3,  'p'), new Cell(0, 4,  'p'), new Cell(0, 5,  'p'), new Cell(0, 6,  'o'), new Cell(0, 7,  'o'), new Cell(0, 8,  'o')},
						{new Cell(1, 0,  'o'), new Cell(1, 1,  'o'), new Cell(1, 2,  'o'), new Cell(1, 3,  'p'), new Cell(1, 4,  'p'), new Cell(1, 5,  'p'), new Cell(1, 6,  'o'), new Cell(1, 7,  'o'), new Cell(1, 8,  'o')},
						{new Cell(2, 0,  'o'), new Cell(2, 1,  'o'), new Cell(2, 2,  'o'), new Cell(2, 3,  'p'), new Cell(2, 4,  'p'), new Cell(2, 5,  'p'), new Cell(2, 6,  'o'), new Cell(2, 7,  'o'), new Cell(2, 8,  'o')},
						{new Cell(3, 0,  'p'), new Cell(3, 1,  'p'), new Cell(3, 2,  'p'), new Cell(3, 3,  'p'), new Cell(3, 4,  'p'), new Cell(3, 5,  'p'), new Cell(3, 6,  'p'), new Cell(3, 7,  'p'), new Cell(3, 8,  'p')},
						{new Cell(4, 0,  'p'), new Cell(4, 1,  'p'), new Cell(4, 2,  'p'), new Cell(4, 3,  'p'), new Cell(4, 4,  'e'), new Cell(4, 5,  'p'), new Cell(4, 6,  'p'), new Cell(4, 7,  'p'), new Cell(4, 8,  'p')},
						{new Cell(5, 0,  'p'), new Cell(5, 1,  'p'), new Cell(5, 2,  'p'), new Cell(5, 3,  'p'), new Cell(5, 4,  'p'), new Cell(5, 5,  'p'), new Cell(5, 6,  'p'), new Cell(5, 7,  'p'), new Cell(5, 8,  'p')},
						{new Cell(6, 0,  'o'), new Cell(6, 1,  'o'), new Cell(6, 2,  'o'), new Cell(6, 3,  'p'), new Cell(6, 4,  'p'), new Cell(6, 5,  'p'), new Cell(6, 6,  'o'), new Cell(6, 7,  'o'), new Cell(6, 8,  'o')},
						{new Cell(7, 0,  'o'), new Cell(7, 1,  'o'), new Cell(7, 2,  'o'), new Cell(7, 3,  'p'), new Cell(7, 4,  'p'), new Cell(7, 5,  'p'), new Cell(7, 6,  'o'), new Cell(7, 7,  'o'), new Cell(7, 8,  'o')},
						{new Cell(8, 0,  'o'), new Cell(8, 1,  'o'), new Cell(8, 2,  'o'), new Cell(8, 3,  'p'), new Cell(8, 4,  'p'), new Cell(8, 5,  'p'), new Cell(8, 6,  'o'), new Cell(8, 7,  'o'), new Cell(8, 8,  'o')}};

		arr = temp;
		col = arr.GetLength(1);
		row = arr.GetLength(0);
	}
	private void type3()
	{
		Cell[,] temp = {{new Cell(0, 0,  'o'), new Cell(0, 1,  'o'), new Cell(0, 2,  'p'), new Cell(0, 3,  'p'), new Cell(0, 4,  'p'), new Cell(0, 5,  'o'), new Cell(0, 6,  'o'), new Cell(0, 7,  'o')},
						{new Cell(1, 0,  'o'), new Cell(1, 1,  'o'), new Cell(1, 2,  'p'), new Cell(1, 3,  'p'), new Cell(1, 4,  'p'), new Cell(1, 5,  'o'), new Cell(1, 6,  'o'), new Cell(1, 7,  'o')},
						{new Cell(2, 0,  'o'), new Cell(2, 1,  'o'), new Cell(2, 2,  'p'), new Cell(2, 3,  'p'), new Cell(2, 4,  'p'), new Cell(2, 5,  'o'), new Cell(2, 6,  'o'), new Cell(2, 7,  'o')},
						{new Cell(3, 0,  'p'), new Cell(3, 1,  'p'), new Cell(3, 2,  'p'), new Cell(3, 3,  'p'), new Cell(3, 4,  'p'), new Cell(3, 5,  'p'), new Cell(3, 6,  'p'), new Cell(3, 7,  'p')},
						{new Cell(4, 0,  'p'), new Cell(4, 1,  'p'), new Cell(4, 2,  'p'), new Cell(4, 3,  'e'), new Cell(4, 4,  'p'), new Cell(4, 5,  'p'), new Cell(4, 6,  'p'), new Cell(4, 7,  'p')},
						{new Cell(5, 0,  'p'), new Cell(5, 1,  'p'), new Cell(5, 2,  'p'), new Cell(5, 3,  'p'), new Cell(5, 4,  'p'), new Cell(5, 5,  'p'), new Cell(5, 6,  'p'), new Cell(5, 7,  'p')},
						{new Cell(6, 0,  'o'), new Cell(6, 1,  'o'), new Cell(6, 2,  'p'), new Cell(6, 3,  'p'), new Cell(6, 4,  'p'), new Cell(6, 5,  'o'), new Cell(6, 6,  'o'), new Cell(6, 7,  'o')},
						{new Cell(7, 0,  'o'), new Cell(7, 1,  'o'), new Cell(7, 2,  'p'), new Cell(7, 3,  'p'), new Cell(7, 4,  'p'), new Cell(7, 5,  'o'), new Cell(7, 6,  'o'), new Cell(7, 7,  'o')}};

		arr = temp;
		col = arr.GetLength(1);
		row = arr.GetLength(0);
	}
	private void type4()
	{
		Cell[,] temp = {{new Cell(0, 0,  'o'), new Cell(0, 1,  'o'), new Cell(0, 2,  'p'), new Cell(0, 3,  'p'), new Cell(0, 4,  'p'), new Cell(0, 5,  'o'), new Cell(0, 6,  'o')},
						{new Cell(1, 0,  'o'), new Cell(1, 1,  'o'), new Cell(1, 2,  'p'), new Cell(1, 3,  'p'), new Cell(1, 4,  'p'), new Cell(1, 5,  'o'), new Cell(1, 6,  'o')},
						{new Cell(2, 0,  'p'), new Cell(2, 1,  'p'), new Cell(2, 2,  'p'), new Cell(2, 3,  'p'), new Cell(2, 4,  'p'), new Cell(2, 5,  'p'), new Cell(2, 6,  'p')},
						{new Cell(3, 0,  'p'), new Cell(3, 1,  'p'), new Cell(3, 2,  'p'), new Cell(3, 3,  'e'), new Cell(3, 4,  'p'), new Cell(3, 5,  'p'), new Cell(3, 6,  'p')},
						{new Cell(4, 0,  'p'), new Cell(4, 1,  'p'), new Cell(4, 2,  'p'), new Cell(4, 3,  'p'), new Cell(4, 4,  'p'), new Cell(4, 5,  'p'), new Cell(4, 6,  'p')},
						{new Cell(5, 0,  'o'), new Cell(5, 1,  'o'), new Cell(5, 2,  'p'), new Cell(5, 3,  'p'), new Cell(5, 4,  'p'), new Cell(5, 5,  'o'), new Cell(5, 6,  'o')},
						{new Cell(6, 0,  'o'), new Cell(6, 1,  'o'), new Cell(6, 2,  'p'), new Cell(6, 3,  'p'), new Cell(6, 4,  'p'), new Cell(6, 5,  'o'), new Cell(6, 6,  'o')}};

		arr = temp;
		col = arr.GetLength(1);
		row = arr.GetLength(0);
	}
	private void type5()
	{
		Cell[,] temp = {{new Cell(0, 0,  'o'), new Cell(0, 1,  'o'), new Cell(0, 2,  'o'), new Cell(0, 3,  'o'), new Cell(0, 4,  'p'), new Cell(0, 5,  'o'), new Cell(0, 6,  'o'), new Cell(0, 7,  'o'), new Cell(0, 8,  'o')},
						{new Cell(1, 0,  'o'), new Cell(1, 1,  'o'), new Cell(1, 2,  'o'), new Cell(1, 3,  'p'), new Cell(1, 4,  'p'), new Cell(1, 5,  'p'), new Cell(1, 6,  'o'), new Cell(1, 7,  'o'), new Cell(1, 8,  'o')},
						{new Cell(2, 0,  'o'), new Cell(2, 1,  'o'), new Cell(2, 2,  'p'), new Cell(2, 3,  'p'), new Cell(2, 4,  'p'), new Cell(2, 5,  'p'), new Cell(2, 6,  'p'), new Cell(2, 7,  'o'), new Cell(2, 8,  'o')},
						{new Cell(3, 0,  'o'), new Cell(3, 1,  'p'), new Cell(3, 2,  'p'), new Cell(3, 3,  'p'), new Cell(3, 4,  'p'), new Cell(3, 5,  'p'), new Cell(3, 6,  'p'), new Cell(3, 7,  'p'), new Cell(3, 8,  'o')},
						{new Cell(4, 0,  'p'), new Cell(4, 1,  'p'), new Cell(4, 2,  'p'), new Cell(4, 3,  'p'), new Cell(4, 4,  'e'), new Cell(4, 5,  'p'), new Cell(4, 6,  'p'), new Cell(4, 7,  'p'), new Cell(4, 8,  'p')},
						{new Cell(5, 0,  'o'), new Cell(5, 1,  'p'), new Cell(5, 2,  'p'), new Cell(5, 3,  'p'), new Cell(5, 4,  'p'), new Cell(5, 5,  'p'), new Cell(5, 6,  'p'), new Cell(5, 7,  'p'), new Cell(5, 8,  'o')},
						{new Cell(6, 0,  'o'), new Cell(6, 1,  'o'), new Cell(6, 2,  'p'), new Cell(6, 3,  'p'), new Cell(6, 4,  'p'), new Cell(6, 5,  'p'), new Cell(6, 6,  'p'), new Cell(6, 7,  'o'), new Cell(6, 8,  'o')},
						{new Cell(7, 0,  'o'), new Cell(7, 1,  'o'), new Cell(7, 2,  'o'), new Cell(7, 3,  'p'), new Cell(7, 4,  'p'), new Cell(7, 5,  'p'), new Cell(7, 6,  'o'), new Cell(7, 7,  'o'), new Cell(7, 8,  'o')},
						{new Cell(8, 0,  'o'), new Cell(8, 1,  'o'), new Cell(8, 2,  'o'), new Cell(8, 3,  'o'), new Cell(8, 4,  'p'), new Cell(8, 5,  'o'), new Cell(8, 6,  'o'), new Cell(8, 7,  'o'), new Cell(8, 8,  'o')}};

		arr = temp;
		col = arr.GetLength(1);
		row = arr.GetLength(0);
	}

	// This calls the right method to create an array 
	private void createArr()
	{
		switch (chosenType)
		{
			//Create the game board array
			case 1:
				type1();
				title.text = "Type: 1";
				break;
			case 2:
				type2();
				title.text = "Type: 2";
				break;
			case 3:
				type3();
				title.text = "Type: 3";
				break;
			case 4:
				type4();
				title.text = "Type: 4";
				break;
			case 5:
				type5();
				title.text = "Type: 5";
				break;
		}
	}
	
	private void board()
    {
		switch (chosenType)
		{
			//Create the game board itself
			case 1:
				GameObject board1 = Instantiate(Model1);
				board1.transform.SetParent(conT);
				board1.transform.position = new Vector3(row - 1, 0 ,col - 1);
				board1.transform.localScale += new Vector3(1f, 1f, 0);
				board1.GetComponent<Renderer>().material = newMaterial;
				break;
			case 2:
				GameObject board2 = Instantiate(Model2);
				board2.transform.SetParent(conT);
				board2.transform.position = new Vector3(row - 1, 0, col - 1);
				board2.transform.localScale += new Vector3(1f, 1f, 0);
				board2.GetComponent<Renderer>().material = newMaterial;
				break;
			case 3:
				GameObject board3 = Instantiate(Model3);
				board3.transform.SetParent(conT);
				board3.transform.position = new Vector3(row - 0.5f, 0, col - 1.5f);
				board3.transform.localScale += new Vector3(1f, 1f, 0);
				board3.GetComponent<Renderer>().material = newMaterial;
				board3.transform.Rotate(0, -90f, 0, Space.World);
				break;
			case 4:
				GameObject board4 = Instantiate(Model4);
				board4.transform.SetParent(conT);
				board4.transform.position = new Vector3(row - 1, 0, col - 1);
				board4.transform.localScale += new Vector3(1f, 1f, 0);
				board4.GetComponent<Renderer>().material = newMaterial;
				break;
			case 5:
				GameObject board5 = Instantiate(Model5);
				board5.transform.SetParent(conT);
				board5.transform.position = new Vector3(row - 1, 0, col - 1);
				board5.transform.localScale += new Vector3(1f, 1f, 0);
				board5.GetComponent<Renderer>().material = newMaterial;
				break;
		}
	}

	//Create pegs on the board and locate them
	private void createPegs()
    {
		pegs = new GameObject[row, col];
		int tempx = 0, tempy = 0, fl = 0;

		for (int i = 0; i < row; i++)
        {
			for (int j = 0; j < col; j++)
            {
				GameObject peg = Instantiate(ModelPeg);
				pegs[i, j] = peg;
				peg.transform.SetParent(conT);
				peg.transform.position = new Vector3(2 * i, 0.3f, 2 * j);
				peg.transform.localScale += new Vector3(1f, 1f, 1f);
				BoxCollider boxCollider = peg.AddComponent<BoxCollider>();
				if (arr[i,j].type == 'p' || arr[i,j].type == 'e')
                {
					if(fl == 0)
                    {
						tempx = i;
						tempy = j;
						fl = 1;
                    }
					peg.AddComponent<UserPlay>();
					peg.AddComponent<ComputerPlay>();
				}
                else
                {
					peg.GetComponent<Renderer>().enabled = false;
				}
			}
        }

		if (gameType == 1)
			pegs[tempx,tempy].GetComponent<UserPlay>().addPegsMethod();
		else
			pegs[tempx,tempy].GetComponent<ComputerPlay>().addPegsMethod();
	}

}
