using System.Collections;
using UnityEngine;

public class BombHandlerScript : MonoBehaviour
{
	private AllPointsOnGrid _allPointsOnGrid;

	private bool _timerGoing;
	private float _elapsedTime;

	public int RowIndex { get; set; }
	public int ColIndex { get; set; }

	void Start()
	{
		_timerGoing = true;
		StartCoroutine(UpdateTimer());
	}

	private IEnumerator UpdateTimer()
	{
		while (_timerGoing)
		{
			_elapsedTime += Time.deltaTime;

			if (_elapsedTime >= 3f) //3f - seconds to explosion
			{
				ExplosionBomb();
			}

			yield return null;
		}
	}

	private void ExplosionBomb()
	{
		_allPointsOnGrid = FindObjectOfType<AllPointsOnGrid>();
		_timerGoing = false;
		Destroy(gameObject);

		foreach (var point in _allPointsOnGrid.GetPointGrid(RowIndex, ColIndex))
		{
			if (point == null)
			{
				return;
			}

			point.ExplosionPoint();
		}
	}
}