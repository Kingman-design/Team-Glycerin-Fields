using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planting : MonoBehaviour
{
    [SerializeField] GameObject plant;
    [SerializeField] private Camera mainCamera;
    public bool clicked = false;

    public Vector3 mouse_position;
    public Vector3 Worldposition;

    public LayerMask layerstohit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_position = Input.mousePosition; 
        Ray ray = mainCamera.ScreenPointToRay(mouse_position);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //transform.position = raycastHit.point;
            Worldposition = raycastHit.point;
            //Debug.Log(raycastHit);
        }

        transform.position = Worldposition;

        if (clicked)
        {
            clicked = false;
            planting();
        }
    }

    void planting()
    {
            Instantiate(plant,transform.position, Quaternion.identity);
    }

    public void clickTrue()
    {
        clicked = true;
    }


}
