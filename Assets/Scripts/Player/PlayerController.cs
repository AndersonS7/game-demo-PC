using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layerGround, layerWall;
    public GameObject mask, mask2, platform1, platform2, gameOverPanel, endPanel, btnMenu, isDeadEnemy;
    public Text gemTex;

    public static bool isWall, colliderEnemy;

    private int contGem;

    Player p;

    void Start()
    {
        contGem = 0;
        colliderEnemy = false;
        p = new Player(gameObject, 5, 23.5f, layerGround, layerWall);
        isWall = false;
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Start") == "start")
        {
            p.Jump();

            // mostra para o background quando o player bateu na parede
            if (p.isWall())
            {
                isWall = true;
            }
            else
            {
                isWall = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (PlayerPrefs.GetString("Start") == "start")
        {
            p.Move();
        }
    }
    private void EnemyDeadAnimator(Transform obj)
    {
        Instantiate(isDeadEnemy, obj.position, obj.rotation);
    }
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
    private void OnTriggerController(GameObject obj)
    {
        if (obj.CompareTag("FrontDoor"))
        {
            mask.SetActive(false);
        }
        else if (obj.CompareTag("ExitDoor"))
        {
            mask.SetActive(true);
        }
        else if (obj.CompareTag("FrontDoor2"))
        {
            mask2.SetActive(false);
        }
        else if (obj.CompareTag("Gem"))
        {
            IncrementGem();
        }
        else if (obj.CompareTag("Gem1"))
        {
            IncrementGem();
            platform1.SetActive(true);
        }
        else if (obj.CompareTag("Gem2"))
        {
            IncrementGem();
            platform2.SetActive(true);
        }
        else if (obj.CompareTag("End"))
        {
            btnMenu.SetActive(false);
            endPanel.SetActive(true);

            Time.timeScale = 0;
        }
    }
    private void OnColliderController(GameObject obj)
    {
        if (obj.CompareTag("Spikes"))
        {
            GameOver();
        }
        if (obj.CompareTag("Enemy"))
        {
            if (obj.transform.position.y + 1 >= gameObject.transform.position.y)
            {
                GameOver();
            }else if (obj.transform.position.y + 1 <= gameObject.transform.position.y)
            {
                p.Jump(15);
                EnemyDeadAnimator(obj.transform);
                Destroy(obj.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        OnTriggerController(coll.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        OnColliderController(coll.gameObject);
    }

    private void IncrementGem()
    {
        contGem++;
        gemTex.text = contGem.ToString("00");
    }
}
