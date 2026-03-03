using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class SnakeMovement : MonoBehaviour
{
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    //public float Speed = 0;
    private Vector2 _direction = Vector2.zero;
    public int initialSize = 4;
    public Gamemanager gamemanager;

    private void Start()
    {
        Reset();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down || Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up || Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right || Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left || Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;

        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
    private void Grow()
    {
        //gamemanager.IncreaseScore();
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void Reset()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);



        for (int i = 1; i < this.initialSize; i++)
        {
            Transform segment = Instantiate(this.segmentPrefab);
            segment.position = _segments[i - 1].position - new Vector3(1, 0, 0);
            _segments.Add(segment);
        }
        this.transform.position = Vector3.zero;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            Reset();
            //Debug.Log("Game Over");
        }
    }
    
}
