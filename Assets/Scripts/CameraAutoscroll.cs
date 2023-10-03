using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraAutoscroll : MonoBehaviour
{
    public Transform playerTr;
    public Vector3 lossPosition;
    public GameObject deathMessage;

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x + 0.002f, transform.position.y, transform.position.z);
        if(transform.position.x >= lossPosition.x)
        {
            deathMessage.SetActive(true);
            Invoke("Reset", 1.5f);
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
