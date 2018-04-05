using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public bool isCollided = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {               
    }

    private void OnCollisionEnter(Collision collision)
    {     
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Floor")
        {
            isCollided = true;
            Debug.Log(isCollided);
        }        
    }
}
