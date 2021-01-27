using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SK
{
    //class for input handler
    public class InputHandler : MonoBehaviour
{
  //need horizonatl, vertical, mouse, moves variables
  public float horizontal;
  public float vertical;
  public float moveAmount;
  public float mouseX;
  public float mouseY;

  PlayerControls inputActions;
  
  Vector2 movementInput;
  Vector2 cameraInput;
    //enable player movement and player camera
  public void OnEnable()
  {
      //if no input actions set to new object player controls
      if (inputActions == null)
      {
          inputActions == new PlayerControls();
          inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
          inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
      }
      inputActions.Enable();
  }
  //disable
  private void OnDisable()
  {
      inputActions.Disable()
  }
  //pass in delta movement to tick
  public void TickInput(float delta)
  {
      MoveInput(delta);
  }
  //get movement input
  private void MoveInput(float delta)
  {
      //set movement vals
      horizontal = movementInput.x;
      vertical = movementInput.y;
      movementAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
      mouseX = cameraInput.x;
      mouseY = cameraInput.y;
  }
}
}

