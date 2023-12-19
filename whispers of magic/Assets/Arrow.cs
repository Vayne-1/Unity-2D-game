using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.localScale = player.localScale;
    }

}