using System;

public class MazeShaperZ
{
	int _sizeNorth;
	int _sizeEast;

	public MazeShaperZ(int numberOfCellsNorth, int numberOfCellsEast)
	{
		_sizeNorth = numberOfCellsNorth;
		_sizeEast = numberOfCellsEast;
	}

	public bool IsNorthBorderCell(int cellIndex)
	{
		if ((cellIndex % _sizeNorth) == (_sizeNorth - 1) &&
			cellIndex != (_sizeNorth * _sizeEast - 1))
		{
			return true;
		}
		return false;
	}

	public bool IsEastBorderCell(int cellIndex)
	{
		int eastTarget = _sizeNorth * (_sizeEast - 1);
		if (cellIndex >= eastTarget)
		{
			return true;
		}
		return false;
	}

	public bool IsSouthBorderCell(int cellIndex)
	{
		if ((cellIndex % _sizeNorth) == 0 && cellIndex != 0)
		{
			return true;
		}
		return false;
	}

	public bool IsWestBorderCell(int cellIndex)
	{
		if (cellIndex < _sizeNorth)
		{
			return true;
		}
		return false;
	}

	public bool IsBorderCell(int cellIndex)
	{
		if (IsNorthBorderCell(cellIndex) || IsEastBorderCell(cellIndex) ||
			IsSouthBorderCell(cellIndex) || IsWestBorderCell(cellIndex))
		{
			return true;
		}
		return false;
	}

	public int FindAdjacentCellIndex(int cellIndex, WallIndex wallIndexOfInterest)
	{
		int oppositeCellIndex = -1;

		switch ((int)wallIndexOfInterest)
		{
			case 0:
				{
					if (!IsNorthBorderCell(cellIndex))
					{
						oppositeCellIndex = cellIndex + 1;
					}
					break;
				}
			case 1:
				{
					if (!IsEastBorderCell(cellIndex))
					{
						oppositeCellIndex = cellIndex + _sizeNorth;
					}
					break;
				}
			case 2:
				{
					if (!IsSouthBorderCell(cellIndex))
					{
						oppositeCellIndex = cellIndex - 1;
					}
					break;
				}
			case 3:
				{
					if (!IsNorthBorderCell(cellIndex))
					{
						oppositeCellIndex = cellIndex - _sizeNorth;
					}
					break;
				}

		}

		return oppositeCellIndex;
	}


}

