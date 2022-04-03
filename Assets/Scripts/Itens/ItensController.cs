
using UnityEngine;

public class ItensController : MonoBehaviour
{
    public AudioSource audioC;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            audioC.Play();
            animator.SetBool("Pegou", true);
            Destroy(gameObject, 0.15f);
        }
    }
}
