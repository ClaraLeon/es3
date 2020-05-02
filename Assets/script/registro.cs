using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class registro : MonoBehaviour
{
	//conexion CASA
    private string urlData = "http://localhost:8888/estresPhp/registro.php";

    //conexion U BD
    //private string urlData ="http://tadeolabhack.com:8081/test/Datos/estresPhp/registro.php";

    private string nombre = " ";
    private string email = " ";
    private string contrasena = " ";
    private	int nEstres = 0 ;

    public InputField campoNombre;
    public InputField campoEmail;
    public InputField campoContrasena;

    public void btnNivelEstres(int valor)
    {
    	nEstres = valor;
    }

    public void enviarDatos()
    {
    	StartCoroutine(enviarDatosUsuario());
    }

    private IEnumerator enviarDatosUsuario()
    {
    	//coja los datos de cada campo y metalos en las variables
    	nombre = campoNombre.text;
    	email = campoEmail.text;
    	contrasena = campoContrasena.text;


    	//imprima en la consola de unity los valores que acaban de ingresarse
   		print(nombre + " " + email + " " + contrasena + " " + nEstres);
		
		if(nombre == "" || email == "" || contrasena == "")
		{
			print("Todos los campos deben ser diligenciados");
		}

		if(nEstres == 0 )
		{
			print("Por favor, seleccione un nivel de estrés");
		
		}
		else
		{
			//Datos que seran enviados a PHP   
	   		WWWForm form = new WWWForm();
	   		form.AddField("nom", nombre);
	   		form.AddField("ema", email);
	   		form.AddField("cont", contrasena);
	   		form.AddField("nivel", nEstres);

	   		//Envie a la url el empaquetado de datos PHP
	   		WWW retroalimentacion = new WWW(urlData, form);
	   		yield return retroalimentacion;

	   		//tome el mensaje de PHP e imprimalo en consola de unity
	   		print(retroalimentacion.text);

	   		SceneManager.LoadScene("principal");
		}



		
    }
}
