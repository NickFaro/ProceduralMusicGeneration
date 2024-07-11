using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public GameObject blockA;
    public GameObject blockB;
    private string[] statesPoll;
    private string chosenState;
    private Vector3 targetPosition;
    private bool isMoving;

    void Start()
    {
        FillStatesPoll();
        isMoving = false;
    }

    void FillStatesPoll()
    {
        statesPoll = new string[100];
        for (int i = 0; i < 50; i++)
        {
            statesPoll[i] = "BlockA";
        }
        for (int i = 50; i < 100; i++)
        {
            statesPoll[i] = "BlockB";
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            chosenState = ChooseRandomState();
            targetPosition = chosenState == "BlockA" ? blockA.transform.position : blockB.transform.position;
            isMoving = true;
        }

        if (isMoving)
        {
            MoveBall();
        }
    }

    string ChooseRandomState()
    {
        int randomIndex = Random.Range(0, statesPoll.Length);
        return statesPoll[randomIndex];
    }

    void MoveBall()
    {
        float step = 5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            isMoving = false;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Choose Direction"))
        {
            chosenState = ChooseRandomState();
            targetPosition = chosenState == "BlockA" ? blockA.transform.position : blockB.transform.position;
            isMoving = true;
        }
    }
}
