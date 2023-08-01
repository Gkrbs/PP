using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum State
    {
        Idle,
        KneelIdle,
        Run
    }
    public State currentState = State.Idle;
    Vector3 movePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoAnim();
    }
    void ChangeState(State state)
    {
        if (currentState == state) return;
        currentState = state;
    }
    public void MoveToward(Vector3 coordinate)
    {
        //Vector3 currentCoordinate = transform.position - new Vector3(0.5f, 0, 0.5f);
        //Vector3.zero - currentCoordinate.x
        movePos = coordinate + new Vector3(0.5f, 0, 0.5f);
        ChangeState(State.Run);
    }
    void Idle()
    {

    }
    void KneelIdle()
    {

    }
    void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos, 5f*Time.deltaTime);
        Quaternion rot = Quaternion.LookRotation(movePos - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 720f * Time.deltaTime);

        if ( transform.position == movePos)
        {
            ChangeState(State.Idle);
        }
    }
    void DoAnim()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.KneelIdle:
                KneelIdle();
                break;
            case State.Run:
                Run();
                break;
        }
    }
}
