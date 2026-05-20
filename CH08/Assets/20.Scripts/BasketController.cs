using UnityEngine;
using UnityEngine.InputSystem;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    GameObject director;
    AudioSource aud;
    

    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("사과를 잡았다.");

            this.aud.PlayOneShot(this.appleSE);
            director.GetComponent<GameDirector>().GetApple();
        }
        else
        {
            Debug.Log("폭탄을 잡았다.");
            this.aud.PlayOneShot(this.bombSE);
            director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
