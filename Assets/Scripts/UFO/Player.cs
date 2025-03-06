using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(CollisionHandler))]
public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerGun _gun;

    private PlayerMover _playerMover;
    private CollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<CollisionHandler>();

        OffGun();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Obstacle || interactable is EnemyBullet || interactable is Enemy)
        {
            _gun.ReloadGun();
            OffGun();
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {     
        _playerMover.Reset();
        OnGun();
    } 

    private void OffGun()
    {
        _gun.gameObject.SetActive(false);    
    }

    private void OnGun()
    {
        _gun.gameObject.SetActive(true);
    }
}
