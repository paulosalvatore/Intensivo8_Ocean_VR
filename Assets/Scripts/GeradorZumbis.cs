using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    [Range(0.01f, 10f)]
    public float delay = 1f;

    [Range(1f, 20f)]
    public float area = 5f;

    public float areaMinima = 1f;

    public GameObject zumbiPrefab;

    public Transform jogador;

    private void Start()
    {
        InvokeRepeating(nameof(GerarZumbi), delay, delay);
    }

    private void GerarZumbi()
    {
        var posicaoAleatoria = Random.insideUnitCircle * area;

        var distancia = Vector3.Distance(jogador.position, posicaoAleatoria);

        if (distancia >= areaMinima)
        {
            var zumbi = Instantiate(zumbiPrefab);

            zumbi.transform.position = new Vector3(
                posicaoAleatoria.x,
                zumbi.transform.position.y,
                posicaoAleatoria.y
            );
        }
        else
        {
            GerarZumbi();
        }
    }
}
