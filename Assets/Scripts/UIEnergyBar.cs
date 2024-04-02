using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyBar : MonoBehaviour
{
    [SerializeField]
    private APlayerAttack _playerAttack;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Color _baseColor;
    [SerializeField]
    private Color _filledColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = _playerAttack.CurrentEnergy / _playerAttack.EnergyNeeded;

        //TODO Just for debug, can be heavily optimized.
        if(_playerAttack.CanAttack)
        {
            _image.color = _filledColor;
        }
        else
        {
            _image.color = _baseColor;
        }
    }
}
