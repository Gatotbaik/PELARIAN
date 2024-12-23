using UnityEngine;

public class Enemy_UpDown : MonoBehaviour
{
    [SerializeField] private float movementDistance; // Jarak gerakan atas-bawah
    [SerializeField] private float speed; // Kecepatan gerakan
    [SerializeField] private float damage; // Damage yang diberikan ke Player
    private bool movingDown; // Arah gerakan, true jika ke bawah
    private float bottomEdge; // Batas bawah gerakan
    private float topEdge; // Batas atas gerakan

    private void Awake()
    {
        // Hitung batas atas dan bawah berdasarkan posisi awal
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (movingDown)
        {
            // Jika belum mencapai batas bawah, terus bergerak ke bawah
            if (transform.position.y > bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                // Ubah arah ke atas
                movingDown = false;
            }
        }
        else
        {
            // Jika belum mencapai batas atas, terus bergerak ke atas
            if (transform.position.y < topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                // Ubah arah ke bawah
                movingDown = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika bertabrakan dengan Player, kurangi HP Player
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
