using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuestionario : MonoBehaviour
{

    private int numeroRam = 0;
    private  int contador = 4;
    public Text pregunta;

    //conexion CASA
    private string urlData = "http://localhost:8888/estresPhp/cuestionario.php";

    //conexion U BD
    //private string urlData ="http:/tadeolabhack.com:8081/test/Datos/estresPhp/cuestionario.php";

    

    public void btnRam()
    {
    			
		if(contador <= 4)
		{
			numeroRam = Random.Range(1,30);
			contador =contador -1;
    		print(contador + " = " + numeroRam);
		}
		
		if(contador <=0)
		{
			SceneManager.LoadScene("principal");
		}
    	
    }

    public void enviarDatos()
    {
    	StartCoroutine(enviarDatosPreguntas());
    }

    private IEnumerator enviarDatosPreguntas()
    {
    	WWWForm form = new WWWForm();
	   	form.AddField("idram", numeroRam);

	   	//Envie a la url el empaquetado de datos PHP
	   	WWW retroalimentacion = new WWW(urlData, form);
	   	yield return retroalimentacion;

        /*

	   	if(retroalimentacion != null)
	   	{
			pregunta.text=string.Parse(convertir);
	   	}*/

	   	//tome el mensaje de PHP e imprimalo en consola de unity
	   	print(retroalimentacion.text);
    }
    



}
