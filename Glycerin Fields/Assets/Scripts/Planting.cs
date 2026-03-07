using Unity.VisualScripting;
using UnityEngine;

public class Planting : MonoBehaviour
{
    [SerializeField] GameObject plant;
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject interactive;

    bool clicked = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
            Debug.Log(raycastHit);
        }
        
    }

    void planting()
    {
            Instantiate(plant);
    }

}
