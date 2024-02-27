using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(
            new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 
                        0, 
                        Input.GetAxis("Vertical") * speed * Time.deltaTime));
        Vector3 direction = Camera.main.ScreenToWorldPoint(
                             Input.mousePosition + 
                             new Vector3(0, 0, Camera.main.transform.position.y)) -
                             transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
