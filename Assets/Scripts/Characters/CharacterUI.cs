using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField]private Slider hp_slider;
    private CharacterHealth characterHealth;
    private Camera mainCamera;
    private RectTransform healthBarRectTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        healthBarRectTransform = GetComponent<RectTransform>();
        characterHealth = GetComponentInParent<CharacterHealth>();
        NameText.text = transform.parent.name;
    }

    private void Update()
    {
        if (characterHealth != null)
        {
            int currentHP = characterHealth.health;
            hp_slider.value = characterHealth.UpdateHealthRatio();
            healthText.text = "HP: " + currentHP.ToString();

            Vector3 direction = (mainCamera.transform.position - healthBarRectTransform.position).normalized;
            healthBarRectTransform.rotation = Quaternion.LookRotation(-direction);
        }
    }
}
