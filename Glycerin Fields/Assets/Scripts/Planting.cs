using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planting : MonoBehaviour
{
    [SerializeField] GameObject plant;
    [SerializeField] private Camera mainCamera;
    
    public bool clicked = false;
    bool Tilled = false;

    public Vector3 mouse_position;
    public Vector3 Worldposition;

    [SerializeField] List<GameObject> Items = new List<GameObject>();
    int plantListpos;

    [SerializeField] AudioSource aud;
    [SerializeField] AudioClip audPlant;
    [SerializeField] float audPlantvol;
    [SerializeField] AudioSource bg;
    [SerializeField] AudioClip bgclip;
    [SerializeField] float bgvol;
    //public LayerMask layerstohit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        bg.Play();
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
        selectPlant();
    }

    void planting()
    {
        Tilling();
        if (Tilled)
        {
            Instantiate(plant, transform.position, Quaternion.identity);
            aud.PlayOneShot(audPlant, audPlantvol);
        }
    }

    void changePlant()
    {
        plant = Items[plantListpos];
    }

    void selectPlant()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && plantListpos < Items.Count - 1)
        {
            plantListpos++;
            changePlant();
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && plantListpos > 0)
        {
            plantListpos--;
            changePlant();
        }
    }

    void Tilling()
    {
        if(plantListpos == 0)
        {
            Tilled = true;
        }
    }

    public void clickTrue()
    {
        clicked = true;
    }





}
