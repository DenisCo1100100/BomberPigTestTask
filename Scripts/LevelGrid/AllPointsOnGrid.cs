using UnityEngine;

public class AllPointsOnGrid : MonoBehaviour
{
	public GameObject[] _pointsOnGrid;
	public PointGridScript[] _pointGrid;

	private void Start()
	{
		InitializedPointGrid();
	}

	private void InitializedPointGrid()
	{
		int counter = 0;

		for (int i = 0; i < 9; i++) //9 rows count
		{
			for (int j = 0; j < 17; j++) // 17 col count
			{
				_pointGrid[counter].RowIndex = i;
				_pointGrid[counter].ColIndex = j;

				if (_pointsOnGrid[counter].tag == "Stone")
				{
					_pointGrid[counter].IsStone = true;
				}
				else 
				{
					_pointGrid[counter].IsStone = false;
				}
				
				counter++;
			}
		}
	}

	public PointGridScript[] GetPointGrid(int row, int col)
	{
		PointGridScript[] pointGridScripts = new PointGridScript[5];
		int counter = 0;

		foreach (var point in _pointGrid)
		{
			if (point.RowIndex == row && point.ColIndex == col)
			{
				pointGridScripts[counter] = point;
				counter++;

				continue;
			}

			if (point.RowIndex == row - 1 && point.ColIndex == col)
			{
				if (!point.IsStone)
				{
					pointGridScripts[counter] = point;
					counter++;

					continue;
				}
			}

			if (point.RowIndex == row + 1 && point.ColIndex == col)
			{
				if (!point.IsStone)
				{
					pointGridScripts[counter] = point;
					counter++;

					continue;
				}
			}

			if (point.RowIndex == row && point.ColIndex == col - 1)
			{
				if (!point.IsStone)
				{
					pointGridScripts[counter] = point;
					counter++;

					continue;
				}
			}

			if (point.RowIndex == row && point.ColIndex == col + 1)
			{
				if (!point.IsStone)
				{
					pointGridScripts[counter] = point;
					counter++;

					continue;
				}
			}
		}

		return pointGridScripts;
	}
}
