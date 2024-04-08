using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector2 movementInput;

    private void Start()
    {
        myRBD2 = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {

        Vector2 movement = movementInput * velocityModifier * Time.deltaTime;
        myRBD2.MovePosition(myRBD2.position + movement);


        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CheckFlip(mouseInput.x);  
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Right Click");
        }else if(Input.GetMouseButtonDown(1)){
            Debug.Log("Left Click");
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
