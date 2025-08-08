using System.Collections.Generic;
using System.Collections;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<int> keyIDs = new List<int>();

    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CharacterController controller;

    private float xRotation = 0f;

    private Coroutine messageCoroutine;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        messageText.enabled = false;
    }
    void Update()
    {
        HandleMouseMovement();
        HandlePlayerMovement();


        
    }


    // Movement and looking around
    private void HandleMouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandlePlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = playerTransform.right * x + playerTransform.forward * z;

        controller.SimpleMove(move * speed);
    }


    // Key management
    public void LogKeys()
    {
        foreach (int keyID in keyIDs)
        {
            Debug.Log("Key ID: " + keyID);
        }
    }

    public bool HasKey(int keyID)
    {
        foreach (int id in keyIDs)
        {
            if (id == keyID)
            {
                return true;
            }
        }
        return false;
    }

    public void AddKey(int keyID)
    {
        if (!keyIDs.Contains(keyID))
        {
            keyIDs.Add(keyID);
            Debug.Log("Added key with ID: " + keyID);
        }
        else
        {
            Debug.Log("Key with ID: " + keyID + " is already in inventory.");
        }
    }


    // Show a message to the player,
    public void ShowPlayerMessage(string message, int seconds)
    {
        if (messageCoroutine != null)
            StopCoroutine(messageCoroutine);

        messageCoroutine = StartCoroutine(ShowMessageCoroutine(message, seconds));
    }

    private IEnumerator ShowMessageCoroutine(string message, int seconds)
    {
        messageText.text = message;
        messageText.enabled = true;

        yield return new WaitForSeconds(seconds);

        messageText.enabled = false;
        messageCoroutine = null;
    }

}
