using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bg;
    [SerializeField] private Sprite newBg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            onDeath();
            bg.GetComponent<SpriteRenderer>().sprite = newBg;
        }
    }

    public void onDeath() { Destroy(gameObject); }
}
