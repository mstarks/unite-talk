using UnityEngine;
using System.Collections.Generic;
using Scripts.Utils;


public class MazeCreatorZBehaviour : MonoBehaviour
{
	[SerializeField]
	MazeCellZBehaviour _mazeCell;

	[SerializeField]
	int _numberOfCellsNorth;

	[SerializeField]
	int _numberOfCellsEast;

	[SerializeField]
	XoroshireRandomNumberGeneratorBehaviour _rng;

	List<MazeCellZBehaviour> _mazeCells;
	MazeShaperZ _mazeShaper;

	void Awake()
	{
		_mazeCells = new List<MazeCellZBehaviour>();
		_mazeShaper = new MazeShaperZ(_numberOfCellsNorth, _numberOfCellsEast);
	}

	void Start()
	{
		BuildMaze();
	}

	public void BuildMaze()
	{
		const float mazeCellSize = 4.0f;
		for (int i = 0; i < _numberOfCellsEast; ++i)
		{
			for (int j = 0; j < _numberOfCellsNorth; ++j)
			{
				Vector3 position = new Vector3(mazeCellSize * i, 0, mazeCellSize * j);
				Quaternion rotation = new Quaternion();
				MazeCellZBehaviour mazeCell = Instantiate(_mazeCell, position, rotation) as MazeCellZBehaviour;

				_mazeCells.Add(mazeCell);
			}
		}

		SetOuterWalls();

		RemoveWall(0, WallIndex.SouthWall);
		RemoveWall(_mazeCells.Count - 1, WallIndex.NorthWall);
		RemoveTwoRandomWallsFromEachCell();
	}

	void SetOuterWalls()
	{
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			// West
			if (_mazeShaper.IsWestBorderCell(i))
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.WestWall);
			}

			// South
			if (_mazeShaper.IsSouthBorderCell(i))
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.SouthWall);
			}

			// East
			if (_mazeShaper.IsEastBorderCell(i))
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.EastWall);
			}

			// North
			if (_mazeShaper.IsNorthBorderCell(i))
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.NorthWall);
			}

		}

	}

	public void RemoveTwoRandomWallsFromEachCell()
	{
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			RemoveRandomWallFromCell(i);
			RemoveRandomWallFromCell(i);
		}
	}

	public void RemoveRandomWallFromCell(int cellIndex)
	{
		// TODO: if wall is already gone, try again?
		ulong randomRoll = _rng.RandomDice(4, 0);
		if (_mazeShaper.IsBorderCell(cellIndex))
		{
			// TODO: Make sure we are removing a removable wall
		}
		RemoveWall(cellIndex, (WallIndex)randomRoll);
		RemoveOtherSideOfWall(cellIndex, (WallIndex)randomRoll);
	}

	public void RemoveAllInsideWalls()
	{
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			RemoveWall(i, WallIndex.NorthWall);
			RemoveWall(i, WallIndex.EastWall);
			RemoveWall(i, WallIndex.SouthWall);
			RemoveWall(i, WallIndex.WestWall);
		}
	}

	public void RemoveWall(int cellIndex, WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeCells.Count)
		{
			_mazeCells[cellIndex].RemoveWall(wallIndex);
		}
	}

	public void RemoveOtherSideOfWall(int cellIndex, WallIndex wallIndex)
	{
		int oppositeCellIndex = _mazeShaper.FindAdjacentCellIndex(cellIndex, wallIndex);
		if (oppositeCellIndex < 0 || oppositeCellIndex >= _mazeCells.Count)
		{
			return;
		}

		WallIndex oppositeDirection = FindOppositeDirection(wallIndex);
		if ((int)oppositeDirection >= 0 && (int)oppositeDirection < _mazeCells.Count)
		{
			if (_mazeCells[oppositeCellIndex].DoesWallExist(oppositeDirection))
			{
				_mazeCells[oppositeCellIndex].RemoveWall(oppositeDirection);
			}
		}
	}

	public bool DoesWallExist(int cellIndex, WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeCells.Count)
		{
			return _mazeCells[cellIndex].DoesWallExist(wallIndex);
		}
		return false;
	}

	WallIndex FindOppositeDirection(WallIndex wallIndex)
	{
		WallIndex oppositeDirection = WallIndex.NorthWall;
		switch ((int)wallIndex)
		{
			case 0:
				{
					oppositeDirection = WallIndex.SouthWall;
					break;
				}
			case 1:
				{
					oppositeDirection = WallIndex.WestWall;
					break;
				}
			case 2:
				{
					oppositeDirection = WallIndex.NorthWall;
					break;
				}
			case 3:
				{
					oppositeDirection = WallIndex.EastWall;
					break;
				}
		}

		return oppositeDirection;
	}

}


public enum WallIndex
{
	NorthWall = 0,
	EastWall,
	SouthWall,
	WestWall
}
