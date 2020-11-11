using UnityEditorInternal;
using UnityEngine;
using TMPro;
public class FloatingText : MonoBehaviour
{
    Rigidbody2D rb;
    TMP_Text text;
    public bool hasFaded;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        text = GetComponent<TMP_Text>();
        text.canvasRenderer.SetAlpha(1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 50);
        FadeOut();

        if (hasFaded)
        {
            time += Time.deltaTime;
            if(time >= 0.1)
            {
                Destroy(this);
                hasFaded = false;
                time = 0;
            }
        }
        
    }
    
    public void FadeOut()
    {
        text.CrossFadeAlpha(0, 1, false);
        hasFaded = true;
       
    }

}
