using System.Collections;
using UnityEngine;

public class PointGridScript : MonoBehaviour
{
	[SerializeField] private Sprite _fireSprite;
	[SerializeField] private GameObject[] _unitsColiders;

	private bool _timerGoing;
	private float _elapsedTime;

	public int RowIndex { get; set; }
	public int ColIndex { get; set; }

	public bool IsStone { get; set; }

	public void ExplosionPoint()
	{
		InsertFireBlast();

		_timerGoing = true;
		StartCoroutine(UpdateTimer());
	}

	private IEnumerator UpdateTimer()
	{
		while (_timerGoing)
		{
			_elapsedTime += Time.deltaTime;

			if (_elapsedTime >= 1f) //1f - seconds to explosion
			{
				KillUnits();
				RemoveFireBlast();

				_timerGoing = false;
			}

			yield return null;
		}
	}

	private void InsertFireBlast()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = _fireSprite;
	}

	private void RemoveFireBlast()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = null;
	}

	private void KillUnits()
	{
		foreach (var unit in _unitsColiders)
		{
			if (unit != null)
			{
				if (gameObject.GetComponent<CircleCollider2D>().IsTouching(unit.GetComponent<CircleCollider2D>()))
				{
					Destroy(unit);
				}
			}
		}
	}
}
