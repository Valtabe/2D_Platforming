using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radiusCheck;

    public bool IsGround()
    {
        Collider2D[] includedColliders = Physics2D.OverlapCircleAll(transform.position, _radiusCheck);

        foreach (Collider2D collider in includedColliders)
        {
            if (collider.TryGetComponent<Ground>(out _))
                return true;
        }

        return false;
    }
}
