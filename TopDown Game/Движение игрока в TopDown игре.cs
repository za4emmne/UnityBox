using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovenment : MonoBehaviour
{
    private const string AnimationNameRun = "Run";
    private const string AnimationNameIdle = "Idle";

    [SerializeField] private float _speed = 3;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float _horizontalMove;
    private float _verticalMove;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed; //горизонтальное движение
        _verticalMove = Input.GetAxisRaw("Vertical") * _speed; //движение по вертикали

        _rigidbody2D.velocity = new Vector2(_horizontalMove, _verticalMove);

        if (_horizontalMove < 0) //поворот персонажа
        {
            _spriteRenderer.flipX = true;
        }
        if (_horizontalMove > 0)
        {
            _spriteRenderer.flipX = false;
        }

        _animator.SetFloat(AnimationNameRun, Mathf.Abs(_verticalMove + _horizontalMove)); //анимация
    }
}
