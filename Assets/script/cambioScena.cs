using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioScena : MonoBehaviour
{
    public void cambiarEscena(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }
}
