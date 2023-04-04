using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
    [SerializeField]
    private GameObject _explosionPrefeb;
    private SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is NULL");
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotateSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(_explosionPrefeb, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 2.38f);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject);
        }
    }
}
