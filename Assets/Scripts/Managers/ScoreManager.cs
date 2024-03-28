using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Score.Manager{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public Text scoretext;
        public Text highScoretext;

        public static int ScoreCount;
        public static int HighScore;

        void Update(){
            scoretext.text = "Score: " + Mathf.Round(ScoreCount);
            if (ScoreCount > HighScore) {
                HighScore = ScoreCount;
                SaveHighScore();
            }

            highScoretext.text = "High Score: " + Mathf.Round(HighScore);
        }
        

        public void AddScore(int points) {
            ScoreCount += points;
        }

        void LoadHighScore() {
            HighScore = PlayerPrefs.GetInt("HighScore", 0);
        }

        void SaveHighScore() {
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }
    
}
    
