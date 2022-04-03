using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    private float direction, timeMove;
    private GameObject targetObj;
    public GameObject area;
    public LayerMask layerGround, layerWall;

    Enemy frog;

    void Start()
    {
        frog = new Enemy(gameObject, 1, 12, layerGround, layerWall);
        targetObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        frog.AnimatorController();
        if (targetObj != null)
        {
            if (Vector2.Distance(targetObj.transform.position, area.transform.position) < 4)
            {
                timeMove += Time.deltaTime;

                if (timeMove > 0.5f)
                {
                    direction = targetObj.transform.position.x - gameObject.transform.position.x;
                    frog.Move(direction);
                    frog.Jump();

                    if (timeMove >= 1)
                    {
                        timeMove = 0;
                    }
                }
            }
        }
    }
}
