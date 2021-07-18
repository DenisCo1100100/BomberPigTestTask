using UnityEngine;

public class CreateBombScript : MonoBehaviour
{
	[SerializeField] private GameObject _bomb;

	private int _rowIndex;
	private int _colIndex;

	private Vector3 _bombPosition;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<PointGridScript>())
		{
			_rowIndex = collision.GetComponent<PointGridScript>().RowIndex;
			_colIndex = collision.GetComponent<PointGridScript>().ColIndex;

			_bombPosition = collision.GetComponent<Transform>().position;
		}
	}

	public void CreateBomb()
	{ 
		BombHandlerScript bomb = Instantiate(_bomb, _bombPosition, new Quaternion(0f, 0f, 0f, 0f)).GetComponent<BombHandlerScript>();

		bomb.RowIndex = _rowIndex;
		bomb.ColIndex = _colIndex;
	}
}