using UnityEngine;
using UnityEngine.SceneManagement;

public class Zumbi : MonoBehaviour
{
    public Animator anim;

    public Rigidbody rb;

    public Collider coll;

    private Transform jogador;

    public float delay = 1f;

    public float delayDamage = 1f;

    private bool andando = false;

    private bool vivo = true;

    public float speed = 0.35f;

    public int hp = 2;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        transform.LookAt(jogador);

        transform.eulerAngles = new Vector3(
            0,
            transform.eulerAngles.y,
            0
        );

        Invoke(nameof(Andar), delay);
    }

    private void Andar()
    {
        andando = true;
    }

    public void Update()
    {
        if (andando)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (vivo && other.CompareTag("Projétil"))
        {
            AplicarDano();

            Destroy(other.gameObject);
        }
    }

    private void AplicarDano()
    {
        hp--;

        if (hp <= 0)
        {
            Morrer();
        }
        else
        {
            anim.SetTrigger("Damage");
            andando = false;
            Invoke(nameof(Andar), delayDamage);
        }
    }

    private void Morrer()
    {
        rb.isKinematic = true;
        coll.enabled = false;

        andando = false;
        vivo = false;

        anim.SetTrigger("Die");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
