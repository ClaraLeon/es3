using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class internetManager : MonoBehaviour
{
	public Text checkInternet;
    
    //conexion BD TADEO
    //private string urlData = "http:/tadeolabhack.com:8081/test/Datos/estresPhp/conexion.php";

	//conexion CASA
    private string urlData = "http://localhost:8888/estresPhp/conexion.php";

    //conexion U BD
    //private string urlData ="http://tadeolabhack.com:8081/test/Datos/estresPhp/conexion.php";
    

    void Start()
    {
        StartCoroutine(_checkInternet());
    }

    public IEnumerator _checkInternet()
    {
    	//www se usa para acceder a una pagina web, retornando datos de tipo www object
    	WWW getData= new WWW(urlData);
    	yield return getData;

    	print(getData.text);

    	//si hay conexión envie el siguiente mensaje
    	if(getData.text == "ConexionEstablecida - ")
    	{
    		checkInternet.text = ".. Conexión establecida ..";
    	}
    	else
    	{
    		checkInternet.text = " .. Sin conexión .. ";
    	}
    }
}
