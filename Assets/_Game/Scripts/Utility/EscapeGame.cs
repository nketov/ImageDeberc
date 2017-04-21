using UnityEngine;
using System.Collections;

public class EscapeGame : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (target == null)
            {
                Application.Quit();
				Debug.Log ("Exit game");
            }
            else
            {
				Debug.Log ("Close window");
            }          
        }
        
                   
	}
}
