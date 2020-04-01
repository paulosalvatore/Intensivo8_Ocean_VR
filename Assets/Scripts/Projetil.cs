using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float speed = 2f;

    public float delay = 10f;

    private void Start()
    {
        Destroy(gameObject, delay);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
