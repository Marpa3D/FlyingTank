using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    // ќсновной класс от ¬€чеслава Ўарова

    [SerializeField] private int _maxHealth = 40;
    [SerializeField] protected float _moveSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 7f;
    protected Rigidbody2D _rigitbody;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _rigitbody = GetComponent<Rigidbody2D>();

    }

    // урон
    public void Damage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Move();
    
    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0f, angleZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed);
    }
}
