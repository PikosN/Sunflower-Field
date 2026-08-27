using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public string GetInteractText();
    public void Interact();
}
public class Player : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpHeight = 1f;
    public float gravityValue = -9.81f;

    public Transform cameraTransform;
    public float mouseSensivity = 1f;
    private float xRotation = 0f;
    private float yRotation = 180f;


    public float interactRange = 1.5f;
    public Crosshair crosshair;
    public LayerMask interactionLayer;
    

    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference lookAction;
    public InputActionReference interactAction;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private IInteractable currentInteractable;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        lookAction.action.Enable();
        interactAction.action.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        lookAction.action.Disable();
        interactAction.action.Disable();
    }

    void Update ()
    {
        if (G.shopManager.IsOpen()) return;


    // движение камерой
        Vector2 mouseDelta = lookAction.action.ReadValue<Vector2>();

        yRotation += mouseDelta.x * mouseSensivity;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        xRotation -= mouseDelta.y * mouseSensivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    // движение игрока
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            if (playerVelocity.y < -2f) 
            {
                playerVelocity.y = -2f;
            }
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        move = Vector3.ClampMagnitude(move, 1f);

        if (isGrounded && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 finalMove = move * movementSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
        // взаимодействие
        IInteractable interactObject = CheckInteractable();
        if (interactObject != currentInteractable)
        {
            currentInteractable = interactObject;
            if (interactObject != null)
            {
                crosshair.SetInteractableUI(true, interactObject.GetInteractText());
            }
            else
            {
                crosshair.SetInteractableUI(false, string.Empty);
            }
        }
        if (currentInteractable != null && interactAction.action.WasPressedThisFrame())
        {
            interactObject.Interact();
            crosshair.SetInteractableUI(true, interactObject.GetInteractText());
        }

    }
    IInteractable CheckInteractable()
    {
        Ray r = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.SphereCast(r, 0.1f, out RaycastHit hitInfo, interactRange, interactionLayer))
        {
            return hitInfo.collider.GetComponentInParent<IInteractable>();
        }
        return null;
    }
}
