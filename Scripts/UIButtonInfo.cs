using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonInfo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsDown { get; private set; }

    [SerializeField] private GameObject _playerPig;
    [SerializeField] private GameObject _state;

    private CircleCollider2D _circleCollider;
    private SpriteRenderer _spriteRenderer;

    public void OnPointerDown(PointerEventData eventData)
    {
        IsDown = true;

        ChangeState();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsDown = false;
    }

    public void ChangeState()
    {
        _circleCollider = _playerPig.GetComponent<CircleCollider2D>();
        _spriteRenderer = _playerPig.GetComponent<SpriteRenderer>();

        _circleCollider.offset = _state.GetComponent<CircleCollider2D>().offset;

        _spriteRenderer.sprite = _state.GetComponent<SpriteRenderer>().sprite;
    }
}