using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuNiveles;
    [SerializeField] private GameObject lvl1;
    [SerializeField] private GameObject lvl2;
    [SerializeField] private GameObject lvl3;
    [SerializeField] private GameObject lvl4;
    [SerializeField] private GameObject lvl5;
    [SerializeField] private GameObject lvl6;
    [SerializeField] private GameObject lvl7;

    public void Salir()
    {
        Application.Quit();
    }
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuNiveles.SetActive(false);
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void MenuNiveles()
    {
        menuPrincipal.SetActive(false);
        menuNiveles.SetActive(true);
    }
    public void Lvl1()
    {
        lvl1.SetActive(true);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void Lvl2()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(true);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void Lvl3()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(true);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void Lvl4()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(true);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void Lvl5()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(true);
        lvl6.SetActive(false);
        lvl7.SetActive(false);
    }
    public void Lvl6()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(true);
        lvl7.SetActive(false);
    }
    public void Lvl7()
    {
        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);
        lvl5.SetActive(false);
        lvl6.SetActive(false);
        lvl7.SetActive(true);
    }
}
