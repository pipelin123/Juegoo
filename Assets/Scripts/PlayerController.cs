using TMPro; //libreria para usar textos
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //variable para guardar la velocidad
    public int rabano = 0;
    public int remolacha = 0;
    public int score = 0;
    public bool hasKey = false;
    public bool hasSpike = false;
    public TextMeshProUGUI textRabano;
    public TextMeshProUGUI textRemolacha;
    public TextMeshProUGUI textScore;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTextRabano();
        UpdateTextRemolacha();
        UpdateTextScore();
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
        if (other.CompareTag("rabano"))
        {
            rabano = rabano + 1;
            UpdateTextRabano();

            Destroy(other.gameObject);
            Debug.Log("Collected!!!");
            Debug.Log("Score: " + rabano);
            score = score + 100;
            UpdateTextScore();

        }
        if (other.CompareTag("remolacha"))
        {
            remolacha = remolacha + 2;
            UpdateTextRemolacha();

            Destroy(other.gameObject);
            Debug.Log("Collected!!!");
            Debug.Log("Score: " + remolacha);
            score = score + 200;
            UpdateTextScore();

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
            Debug.Log("has muerto!");
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        
        //codicion de victoria
        if (rabano + remolacha >= 30 || hasKey && !hasSpike)  //solo en un booleano si se pregunta sin nada es verdadero, y con un signo de admiracion al principio es falso
        {
            Debug.Log("Has ganado. Tienes suficientes puntos, la llave y no has tocado los pinchos");
            VictoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void UpdateTextRabano()
    {
        textRabano.text = rabano +"/10";
    }

    void UpdateTextRemolacha()
    {
        textRemolacha.text = remolacha +"/20";
    }

    void UpdateTextScore()
    {
        textScore.text = score +"";
    }
}
