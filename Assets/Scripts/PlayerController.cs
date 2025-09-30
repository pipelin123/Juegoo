using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //variable para guardar la velocidad
    public int score = 0;
    public bool hasKey = false;
    public bool hasSpike = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //leer las teclas WASD o las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //creamos un vector para direccion del movimiento
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

    }
    //funcion especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo //trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Print("prueba");
        if (other.CompareTag("collectable"))
        {
            score = score + 1;
            

            Destroy(other.gameObject);
            Debug.Log("Collected!!!");
            Debug.Log("Score: " + score);

        }
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("has recolectado la llave!");
            Destroy(other.gameObject);
            
        }
        if (other.CompareTag("Spike"))
        {
            hasSpike = true;
            Debug.Log("has recolectado la llave!");
            Destroy(gameObject);
        }
        
        
        //codicion de victoria
        if (score >= 3 || hasKey && !hasSpike)  //solo en un booleano si se pregunta sin nada es verdadero, y con un signo de admiracion al principio es falso
        {
            Debug.Log("Has ganado. Tienes suficientes puntos, la llave y no has tocado los pinchos");
            
        }
    }
}