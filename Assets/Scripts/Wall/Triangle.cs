using EasyTextEffects;
using System.Collections;
using TMPro;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private TextMeshProUGUI text;
    private TextEffect effect;
    private Coroutine effectCoroutine;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        effect = GetComponentInChildren<TextEffect>();
        canvas.SetActive(false);
    }
    private IEnumerator ShowEffectCoroutine()
    {
        canvas.SetActive(true);
        ShowText();
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
    }
    private void ShowText()
    {
        text.text = "+10";
        effect.StartManualEffects();
    }
    [SerializeField] private float force = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.collider.GetComponent<Rigidbody>();
            if (ballRb != null && collision.contactCount > 0)
            {
                Vector3 normal = collision.contacts[0].normal;
                ballRb.AddForce(-normal * force, ForceMode.Impulse);
            }
            if (effectCoroutine != null)
                StopCoroutine(effectCoroutine);

            effectCoroutine = StartCoroutine(ShowEffectCoroutine());
        }
    }
}
