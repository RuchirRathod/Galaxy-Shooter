using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    [SerializeField]
    private float _upperBound = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);

        if (transform.position.y > _upperBound)
        {
            if(transform.parent != null) 
            { 
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
