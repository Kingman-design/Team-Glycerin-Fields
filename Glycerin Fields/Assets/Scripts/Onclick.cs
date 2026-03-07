using Unity.VisualScripting;
using UnityEngine;

public class Onclick : MonoBehaviour
{
    public Planting plants;
    [SerializeField] GameObject plane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            plants.clickTrue();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Un-clicked");
        }
    }
}
