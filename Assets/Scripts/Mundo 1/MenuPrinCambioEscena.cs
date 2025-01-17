using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrinCambioEscena : MonoBehaviour
{

    public static MenuPrinCambioEscena instance;

    public AudioSource audioSource; // Referencia al AudioSource que reproducir� el sonido
    public AudioClip sonido; // Variable para almacenar el audio a reproducir

    // Esta funci�n se llama cuando se instancian los scripts
    void Awake()
    {
        // Inicializaci�n de variables o referencias aqu�
        // Garantiza que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }


    // M�todo que se ejecuta al presionar el bot�n
    public void ReproducirSonido2()
    {
        audioSource.PlayOneShot(sonido); // Reproducir el sonido una vez
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void CambiarEscena2()
    {
        int receivedVariableUltimaEscena = PlayerPrefs.GetInt("VariableUltimaEscena");
        Debug.Log("La �ltima variable recibida es: "+receivedVariableUltimaEscena);
        int siguienteEscena = receivedVariableUltimaEscena + 1;
        SceneManager.LoadScene(siguienteEscena);
    }

    public void FuncionCerrarJuego()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        // Obtiene el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena actual, lo que reinicia la escena
        SceneManager.LoadScene(currentSceneIndex);
    }

  
    /* Ensayo En env�o de datos*/
    public void GurdarGame_State()
    {
        GameStateDto gameStateDto = new GameStateDto();
        //llenamos lo que tenga en la base de datos
        gameStateDto.idAvatar = 2;
        gameStateDto.idUser = UserApi.getUser().id;
        gameStateDto.idLevelChallengeDescription = 1;



        GameStateApi.save(gameStateDto);
    }

    public void CrearGenero()
    {
        GenderDto genderDto = new GenderDto();

        genderDto.gender = "Inmobiliario";
        GenderApi.save(genderDto);
    }

    public void CrearAvatar()
    {
        AvatarDto avatarDto = new AvatarDto();

        avatarDto.avatar = "Ang";
        avatarDto.idGender = 3;
        AvatarApi.save(avatarDto);
    }


    /* Fin Ensayo*/

}
