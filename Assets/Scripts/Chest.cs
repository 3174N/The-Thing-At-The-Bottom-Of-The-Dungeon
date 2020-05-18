using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject openButton;

    public Material highlight, defult;
    public Sprite opennedSprite;

    bool isOpen;

    SpriteRenderer sRenderer;
    RoomLocker room;

    /// <summary>
    /// Called at the first frame
    /// </summary>
    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        room = GetComponentInParent<RoomLocker>();

        isOpen = false;

        openButton.SetActive(false);
    }

    /// <summary>
    /// Called with trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();

        if (player != null && room.getIsOpen())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Open();
            }

        }

        if (!isOpen && room.getIsOpen())
        {
            sRenderer.material = highlight;

            openButton.SetActive(true);
        }
        else
        {
            sRenderer.material = defult;

            openButton.SetActive(false);
        }
    }

    /// <summary>
    /// Called once object left collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        playerMovement player = other.GetComponent<playerMovement>();

        if (player != null)
        {
            sRenderer.material = defult;

            openButton.SetActive(false);
        }
    }

    /// <summary>
    /// Open the chest
    /// </summary>
    public void Open()
    {
        Debug.Log("hi");
        if (!isOpen)
        {
            sRenderer.sprite = opennedSprite;
            sRenderer.material = defult;

            openButton.SetActive(false);

            Vector2 newPos = new Vector2(transform.position.x + Random.Range(0, 2),
                transform.position.y + Random.Range(0,2));
            Instantiate(objects[Random.Range(0, objects.Length)],
                newPos, Quaternion.identity);

            isOpen = true;

            // GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().ChangeHealth(15);
        }
    }
}
