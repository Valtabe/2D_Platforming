using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroler _patroler;

    private void Update()
    {
        _patroler.Patrol();
    }
}
