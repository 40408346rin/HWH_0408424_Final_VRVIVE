using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class GM : MonoBehaviour
{
    [Header("鐵罐數量")]
    public Text textBallCount;
    [Header("鐵罐分數")]
    public Text textScore;
    [Header("鐵罐音效")]
    public AudioClip sound;


    private AudioSource aud;
    private int jarCount = 10;
    private int score;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    public void Usejar (GameObject jar)
    {
        Destroy(jar.GetComponent<Throwable>());
        Destroy(jar.GetComponent<Interactable>());

        jarCount--;
        textBallCount.text = "鐵罐數量 " + jarCount + "  /10";
    }

    private void OnTriggerEnter(Collider other)
    {
        score += 1;
        textScore.text = "分數 " + score;
        aud.PlayOneShot(sound);
    }

    public void Replay()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
        SceneManager.LoadScene("VR 場景");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
