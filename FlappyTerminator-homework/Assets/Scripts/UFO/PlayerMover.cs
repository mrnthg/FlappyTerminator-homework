using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _palyerRigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _palyerRigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Start()
    {                   
        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _palyerRigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _palyerRigidbody.velocity = Vector2.zero;
    }
}
