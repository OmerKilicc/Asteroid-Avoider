using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] public TMP_Text TextMeshPro;
    [SerializeField] private float scoreMultiplier = 5f;
    public float score = 0;
    public bool isCounting;

    // Update is called once per frame

    private void Start()
    {
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            score += Time.deltaTime * scoreMultiplier;
            TextMeshPro.text = Mathf.FloorToInt(score).ToString();
        }

    }
}
