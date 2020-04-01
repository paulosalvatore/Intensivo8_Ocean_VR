using UnityEngine;

public class Jogador : MonoBehaviour
{
    public GameObject projetilPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        Instantiate(projetilPrefab, transform.position, Camera.main.transform.rotation);
    }
}
