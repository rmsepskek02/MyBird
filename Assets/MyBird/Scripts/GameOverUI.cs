using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyBird
{
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI score;
        public TextMeshProUGUI newText;

        [SerializeField] private string loadToScene = "TitleScene";
        #endregion

        private void OnEnable()
        {
            //게임 데이터 저장
            GameManager.BestScore = PlayerPrefs.GetInt("BestScore", 0); //저장된 데이터 가져오기
            //Debug.Log($"load BestScore: {GameManager.BestScore}");

            if (GameManager.Score > GameManager.BestScore) //저장된 데이터와 비교하기
            {
                GameManager.BestScore = GameManager.Score;
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                newText.text = "NEW";
                //Debug.Log($"Save BestScore: {GameManager.BestScore}");
            }
            else if (GameManager.Score == GameManager.BestScore)
            {
                newText.text = "SAME";
            }
            else
            {
                newText.text = "";
            }

            //UI 연결
            bestScore.text = GameManager.BestScore.ToString();
            score.text = GameManager.Score.ToString();
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            SceneManager.LoadScene(loadToScene);
        }
    }
}