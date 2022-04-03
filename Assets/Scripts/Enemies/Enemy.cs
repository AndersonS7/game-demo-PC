using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _obj;
    private float _speed, _jumpForce;
    private LayerMask _layerGround, _layerWall;
    private float _totalJump;
    private Animator _animator;
    private Rigidbody2D _rig;
    private Collider2D _coll2D;
    private bool _isJumping;

    public Enemy()
    {
        InitialObj();
    }

    public Enemy(GameObject obj, float speed)
    {
        _obj = obj;
        _speed = speed;

        InitialObj();
    }

    public Enemy(GameObject obj, float speed, float jumpForce, LayerMask layerGround, LayerMask layerWall)
    {
        _obj = obj;
        _speed = speed;
        _jumpForce = jumpForce;
        _layerGround = layerGround;
        _layerWall = layerWall;

        InitialObj();
    }
    public void IsDead()
    {
        _speed = 0;
        _jumpForce = 0;
        _animator.SetBool("TaMorto", true);
        Destroy(_obj, 0.5f);
    }
    public void Jump()
    {
        if (isGround() && !_isJumping)
        {
            if (_totalJump <= 1)
            {
                _rig.velocity = Vector2.up * _jumpForce;
                _totalJump++;
                _isJumping = true;
            }
        }
        if (isGround())
        {
            _isJumping = false;
            _totalJump = 0;
        }
    }
    public void AnimatorController()
    {
        if (isGround())
        {
            _animator.SetBool("TaPulando", false);
        }
        else
        {
            _animator.SetBool("TaPulando", true);
        }
    }
    public void Move(float direction)
    {
        if (direction > 0)
        {
            _obj.transform.localScale = new Vector2(-1, 1);
        }
        else if (direction < 0)
        {
            _obj.transform.localScale = new Vector2(1, 1);
        }
        _obj.transform.position += new Vector3(direction, 0, 0) * _speed * Time.deltaTime;
    }
    public bool isWall()
    {
        RaycastHit2D ground = Physics2D.BoxCast(_coll2D.bounds.center,
            _coll2D.bounds.size, 0, Vector2.right, 1, _layerWall);

        return ground.collider != null;
    }
    private bool isGround()
    {
        RaycastHit2D ground = Physics2D.BoxCast(_coll2D.bounds.center,
            _coll2D.bounds.size, 0, Vector2.down, 0.05f, _layerGround);

        return ground.collider != null;
    }
    private void InitialObj()
    {
        _isJumping = false;
        _rig = _obj.GetComponent<Rigidbody2D>();
        _coll2D = _obj.GetComponent<Collider2D>();
        _animator = _obj.GetComponent<Animator>();
    }
}
