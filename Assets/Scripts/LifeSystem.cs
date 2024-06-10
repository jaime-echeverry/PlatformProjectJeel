using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private float lifes;

    public void ReceiveDamage(float damage) {
        lifes -= damage;

        if (lifes <= 0) { 
            Destroy(this.gameObject);
            if (this.gameObject.CompareTag("PlayerHitBox")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Start is called before the first frame update
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
