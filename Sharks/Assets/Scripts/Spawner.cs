using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float posX;
    float posY;
    float rot;
    public GameObject korobka; // коробка
    public GameObject prefab; // объект который должен быть в коробке
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject currentTower = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);

        }
        
    }

    

}
