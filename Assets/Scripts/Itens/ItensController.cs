
using UnityEngine;

public class ItensController : MonoBehaviour
{

    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            animator.SetBool("Pegou", true);
            Destroy(gameObject, 0.15f);
        }
    }
}
