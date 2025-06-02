using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField]private Slider sliderVida;
    [SerializeField]private int vidaActual = 100;
    [SerializeField]private int vidaMaxima = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderVida = GetComponent<Slider>();
        sliderVida.maxValue = vidaMaxima;
        sliderVida.value = vidaActual;
    }
    public void ActualizaVida(int cantidad)
    {
        vidaActual = cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        sliderVida.value = vidaActual;
    }
}
