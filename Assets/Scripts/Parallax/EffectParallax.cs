using UnityEngine;

public class EffectParallax : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetString("Start") == "start")
        {
            if (!PlayerController.isWall)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(-0.55f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.position += new Vector3(0.55f * Time.deltaTime, 0, 0);
                }
            }
        }
    }
}
