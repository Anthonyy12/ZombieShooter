using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar escenas
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos; // Puntaje del jugador
    private float highScore; // High Score del nivel
    private string currentLevel; // Nombre del nivel actual

    [SerializeField] private TextMeshProUGUI textMesh; // Texto para el puntaje actual
    [SerializeField] private TextMeshProUGUI highScoreText; // Texto para el High Score

    private void Start()
    {
        // Obtén el nombre del nivel actual
        currentLevel = SceneManager.GetActiveScene().name;

        // Carga el High Score guardado para el nivel actual
        highScore = PlayerPrefs.GetFloat("HighScore_" + currentLevel, 0);

        // Asegúrate de que los textos estén asignados
        if (textMesh == null)
            textMesh = GameObject.Find("Puntaje")?.GetComponent<TextMeshProUGUI>();

        if (highScoreText == null)
            highScoreText = GameObject.Find("HighScoreText")?.GetComponent<TextMeshProUGUI>();

        if (textMesh == null || highScoreText == null)
        {
            Debug.LogError("Faltan componentes de texto en el script Puntaje.");
            return;
        }

        ActualizarTextoPuntaje();
        ActualizarTextoHighScore();
    }

    // Método para sumar puntos desde otros scripts
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        ActualizarTextoPuntaje();

        // Verifica si el nuevo puntaje supera el High Score
        if (puntos > highScore)
        {
            highScore = puntos;
            PlayerPrefs.SetFloat("HighScore_" + currentLevel, highScore); // Guarda el nuevo High Score
            ActualizarTextoHighScore();
        }
    }

    // Actualiza el texto del puntaje actual
    private void ActualizarTextoPuntaje()
    {
        textMesh.text = puntos.ToString("0") + " points";
    }

    // Actualiza el texto del High Score
    private void ActualizarTextoHighScore()
    {
        highScoreText.text = "High Score: " + highScore.ToString("0");
    }
}
