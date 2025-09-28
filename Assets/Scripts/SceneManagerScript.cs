using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] RayCastKill rayCastKill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rayCastKill.raycastHit == "Player")
        {
            SceneManager.LoadScene("LostScene");
        }
    }
}
