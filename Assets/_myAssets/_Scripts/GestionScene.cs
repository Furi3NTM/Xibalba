using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{

    [SerializeField] private GameObject menuInstruction = default;
    private bool _voirInstruction = false;

    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

    public void OuvrirInstruction()
    {
        if (!_voirInstruction)
        {
            menuInstruction.SetActive(true);
            _voirInstruction = true;
        }
    }

    public void FermerInstruction()
    {
        if (_voirInstruction)
        {
            menuInstruction.SetActive(false);
            _voirInstruction = false;
        }
    }
}
