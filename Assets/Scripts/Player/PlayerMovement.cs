using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject lateralMovementObject;
    [SerializeField] private GameObject continueScreen;
    [SerializeField] private GameObject levelControl;
    [SerializeField] private GameObject coinCostDisplay;

    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float speed = 2.0f;

    private int temp = 0;

    public static bool canMove = false;
    public static bool isPaused = false;

    private bool isJumping;
    private bool comingDown;

    private Vector2 startTouchPosition, endTouchPosition;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (canMove)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Check if touch has just started
                if (touch.phase == TouchPhase.Began)
                {
                    startTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    endTouchPosition = touch.position;

                    // Check if horizontal movement is greater than vertical movement (indicating a swipe)
                    if (Mathf.Abs(endTouchPosition.x - startTouchPosition.x) > Mathf.Abs(endTouchPosition.y - startTouchPosition.y))
                    {
                        // Check if the swipe was to the right
                        if (endTouchPosition.x > startTouchPosition.x && this.gameObject.transform.position.x < LevelBoundary.rightSide)
                        {
                            float targetX = Mathf.Min(transform.position.x + 2, LevelBoundary.rightSide);

                            Vector3 targetPosition = targetX > 0 && targetX < 2 ? new Vector3(0, lateralMovementObject.transform.position.y, lateralMovementObject.transform.position.z) : new Vector3(targetX, lateralMovementObject.transform.position.y, lateralMovementObject.transform.position.z);

                            StartCoroutine(MoveToPosition(lateralMovementObject.transform, targetPosition, speed));
                        }

                        // Check if the swipe was to the left
                        else if (endTouchPosition.x < startTouchPosition.x && this.gameObject.transform.position.x > LevelBoundary.leftSide)
                        {
                            float targetX = Mathf.Max(transform.position.x - 2, LevelBoundary.leftSide);

                            Vector3 targetPosition = targetX < 0 && targetX > -2 ? new Vector3(0, lateralMovementObject.transform.position.y, lateralMovementObject.transform.position.z) : new Vector3(targetX, lateralMovementObject.transform.position.y, lateralMovementObject.transform.position.z);

                            StartCoroutine(MoveToPosition(lateralMovementObject.transform, targetPosition, speed));
                        }
                    }

                    // Check if vertical movement is greater than horizontal movement (indicating a swipe)
                    if (Mathf.Abs(endTouchPosition.x - startTouchPosition.x) < Mathf.Abs(endTouchPosition.y - startTouchPosition.y))
                    {
                        if (endTouchPosition.y > startTouchPosition.y)
                        {
                            if (!isJumping)
                            {
                                isJumping = true;

                                playerObject.GetComponent<Animator>().Play("Jump");

                                StartCoroutine(JumpSequence());
                            }
                        }
                        else if (endTouchPosition.y < startTouchPosition.y && transform.position.y != 1.5f)
                        {
                            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);

                            playerObject.GetComponent<Animator>().Play("Falling To Landing");

                            StartCoroutine(FallSequemce());
                        }
                    }
                }
            }

            if (!isJumping && transform.position.y != 1.5f)
            {
                transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            }
            else if (transform.position.y == 1.5f && !isJumping)
            {
                playerObject.GetComponent<Animator>().Play("Drunk Run Forward");
            }
        }

        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6.5f, Space.World);
            }
            if (comingDown && transform.position.y > 1.5f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.5f, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!ContinueRunSequence.invisible)
            {
                ContinueRunSequence.coins += temp;
                temp = ContinueRunSequence.coins;
            }

            if (ContinueRunSequence.coins > CollectableControl.coinCount && !ContinueRunSequence.invisible)
            {
                levelControl.GetComponent<EndRunSequence>().enabled = true;
            }

            else if (ContinueRunSequence.coins < CollectableControl.coinCount && !ContinueRunSequence.invisible)
            {
                isPaused = true;

                if (isPaused)
                {
                    levelControl.GetComponent <GenerateLevel>().enabled = false;
                    levelControl.GetComponent <Destroyer>().enabled = false;
                }

                coinCostDisplay.GetComponent<Text>().text = "" + ContinueRunSequence.coins;

                StartCoroutine(ContinueSequence());
            }
        }
    }

    IEnumerator ContinueSequence()
    {
        yield return new WaitForSeconds(2f);

        continueScreen.SetActive(true);
    }


    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            moveSpeed += .35f;
        }
    }


    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(.28f);

        comingDown = true;

        yield return new WaitForSeconds(.28f);

        isJumping = false;
        comingDown = false;
    }


    IEnumerator FallSequemce()
    {
        yield return new WaitForSeconds(.15f);

        playerObject.GetComponent<Animator>().Play("Drunk Run Forward");
    }


    IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)        //timeToMove is a variable that represents the total time you want the movement to take.
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
                                                    //"t" is a variable that’s being incremented by Time.deltaTime / timeToMove each frame.
                                                    //This means "t" represents the proportion of timeToMove that has elapsed since the movement started.
                                                    //This line of code that updates "t" each frame to reflect the proportion of the total movement
                                                    //time that has passed. When "t" reaches 1, it means the total time to move has elapsed.
            
            transform.position = Vector3.Lerp(currentPos, position, t);     //The formula for Vector3.Lerp is Lerp(a, b, t) = a + (b−a)*t
            transform.parent.position = new Vector3(transform.position.x, transform.parent.position.y, transform.parent.position.z);

            yield return null;
        }
    }
}