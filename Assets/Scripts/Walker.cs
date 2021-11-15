using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Transform RayStart;
    public float Speed = 3f;
    public float StopTime = 1f;
    public UnityEvent ReachRightTargetEvent;
    public UnityEvent ReachLeftTargetEvent;



    private bool _isStopped;
    private Direction _currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStopped) {
            return;
        }

        if (_currentDirection == Direction.Left) {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);

            if (transform.position.x < LeftTarget.position.x) {
                _currentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                ReachLeftTargetEvent.Invoke();
            }
        } else {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);

            if (transform.position.x > RightTarget.position.x) {
                _currentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                ReachRightTargetEvent.Invoke();
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(RayStart.position, Vector3.down, out hit)) {
            transform.position = hit.point;
        }
    }

    public void ContinueWalk() {
        _isStopped = false;
    }
}
