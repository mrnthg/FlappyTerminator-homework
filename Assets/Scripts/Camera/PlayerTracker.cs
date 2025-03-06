using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xPositionOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _xPositionOffset;
        transform.position = position;
    }
}
