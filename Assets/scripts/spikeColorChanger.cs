using UnityEngine;
using System.Collections;

public class spikeColorChanger : MonoBehaviour
{
 
    Mesh mesh;
    Color[] meshColors;

    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        meshColors = new Color[mesh.vertices.Length];
    }

    // Update is called once per frame
    void Update() {

        float offset = transform.position.magnitude / 3;

        float r = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad  + offset));
        float g = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad * 5.15f + offset));
        float b = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad * 5.8f + offset));
        Color newColor = new Color(100,0,0);
        for (int i=0; i<meshColors.Length; ++i) {
            meshColors [i] = newColor;
        }
        mesh.colors = meshColors;

    }
    
}