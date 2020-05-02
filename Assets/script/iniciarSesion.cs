using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class iniciarSesion : MonoBehaviour
{
	//conexion CASA
    private string urlData = "http://localhost:8888/estresPhp/iniciarSesion.php";

    //conexion U BD
    //private string urlData ="http://tadeolabhack.com:8081/test/Datos/estresPhp/registro.php";

    private string email = " ";
    private string contrasena = " ";

    public InputField campoEmail;
    public InputField campoContrasena;
    public GameObject cajaAlerta;
    public Text alerta;


    public void enviarDatos()
    {
    	StartCoroutine(enviarDatosUsuario());
    }

    private IEnumerator enviarDatosUsuario()
    {
    	email = campoEmail.text;
    	contrasena = campoContrasena.text;

    	print(email + " " + contrasena);

    	if(email == "" || contrasena == "")
		{
			print("Todos los campos deben ser diligenciados");
			cajaAlerta.gameObject.SetActive(true);
	   		alerta.text= "Todos los campos deben ser diligenciados";
		}
		//Datos que seran enviados a PHP   
	   	WWWForm form = new WWWForm();
	   	form.AddField("ema", email);
	   	form.AddField("con", contrasena);

	   	//Envie a la url el empaquetado de datos PHP
	   	WWW retroalimentacion = new WWW(urlData, form);
		yield return retroalimentacion;

	   	//tome el mensaje de PHP e imprimalo en consola de unity
	   	print(retroalimentacion.text);

	   	if(retroalimentacion.text == "ConexionEstablecida - Error! Los datos son incorrectos")
	   	{	
	   		cajaAlerta.gameObject.SetActive(true);
	   		alerta.text= "Error! Los datos son incorrectos";
	   	}

		if(retroalimentacion.text == "ConexionEstablecida - inicia sesion")
	   	{
	   		SceneManager.LoadScene("principal");
	   	}
	   		
		
    }
}
