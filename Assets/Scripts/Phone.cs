using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator AnswerPhone()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<SoundManager>().PlayVA("Intro Voice Acting");
    }
}
