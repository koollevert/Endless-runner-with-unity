using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxButtons : MonoBehaviour
{
    public AudioSource beep;
    public AudioSource bang;
    public AudioSource ding;
    public AudioSource buttonpress;

    public void bangPlay()
    {
        bang.Play();
    }
    public void beepPlay()
    {
        beep.Play();
    }
    public void dingPlay()
    {
        ding.Play();
    }
    public void Buttonpress()
    {
        buttonpress.Play();
    }

}
