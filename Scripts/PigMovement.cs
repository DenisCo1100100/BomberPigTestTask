using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] private UIButtonInfo _uIButtonUP;
    [SerializeField] private UIButtonInfo _uIButtonDown;
    [SerializeField] private UIButtonInfo _uIButtonLeft;
    [SerializeField] private UIButtonInfo _uIButtonRigth;

    private Rigidbody2D _rb;
    public Vector2 MoveVector;
    public float speed = 3f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        WalkHorizontal();
        WalkVertical();
    }

    private void WalkHorizontal() 
    {
        MoveVector.x = GetHorizontalAxis();
        _rb.velocity = new Vector2(MoveVector.x * speed, _rb.velocity.y);
    }

    private void WalkVertical()
    {
        MoveVector.y = GetVerticalAxis();
        _rb.velocity = new Vector2(_rb.velocity.x, MoveVector.y * speed);
    }

    private int GetHorizontalAxis() 
    {
        if (_uIButtonRigth.IsDown)
        {
            return 1;
        }
        else if (_uIButtonLeft.IsDown)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    private int GetVerticalAxis()
    {
        if (_uIButtonUP.IsDown)
        {
            return 1;
        }
        else if (_uIButtonDown.IsDown)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
