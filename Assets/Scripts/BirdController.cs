using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BirdController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Remet la vitesse verticale à zero avant de réappliquer l'impulsion (pour un saut réactif)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (animator != null)
        {
            animator.SetBool("isFlapping", rb.linearVelocity.y > 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameManager.instance.GameOver();
    }
}
