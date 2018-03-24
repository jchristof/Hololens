
using UnityEngine;

public class CubeColor : MonoBehaviour {

    private Color originalColor;

    private Vector3 originalVector;

	// Use this for initialization
	void Start () {
		var newColor = new Color(Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0), Random.Range((float)0.0, (float)1.0));
	    GetComponent<Renderer>().material.color = newColor;
	    originalColor = newColor;
	    originalVector = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSelect() {
        var cube = GetComponent<Renderer>();
        cube.material.color = Color.magenta;
    }
    void OnReset() {
        var cube = GetComponent<Renderer>();
        cube.material.color = originalColor;
    }

    public void OnResetBlock() {
        transform.position = originalVector;
    }
}
