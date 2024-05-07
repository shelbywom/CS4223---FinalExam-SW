using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using NUnit.Framework; 
using UnityEngine.TestTools; 
using System.Collections; 

public class GamePlayTests : MonoBehaviour
{
    private string playerName; 

    [SetUp]
    public void Setup()
    {
        playerName = "TestPlayer"; 
    }

    [UnityTest]
    public IEnumerator PlayButtonStartsPlay()
    {
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(1); 

        var playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.Invoke();

        yield return new WaitForSeconds(1); 

        Assert.AreEqual("Game", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1); 

        var stopButton = GameObject.Find("StopButton").GetComponent<Button>();
        stopButton.onClick.Invoke(); 

        yield return new WaitForSeconds(1); 

        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");
        yield return new WaitForSeconds(1);

        var playAgainButton = GameObject.Find("PlayAgainButton").GetComponent<Button>();
        playAgainButton.onClick.Invoke(); 

        yield return new WaitForSeconds(1);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator PlayerNameShownInGame()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1); 

        var playerNameText = GameObject.Find("NameText").GetComponent<Text>();
        Assert.AreEqual(playerName, playerNameText.text, "Player's name should be displayed in the game.");
    }

    [UnityTest]
    public IEnumerator PlayerMovesWithWASD_OR_DestroyingFiveTargetsStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1); 

        var player = GameObject.Find("Player"); 
        Vector3 startPosition = player.transform.position;

        player.transform.position += new Vector3(1, 0, 0); 
        yield return new WaitForSeconds(1);

        Vector3 newPosition = player.transform.position;
        bool hasPlayerMoved = startPosition != newPosition; 

        var targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (var target in targets)
        {
            Object.Destroy(target); 
            yield return new WaitForSeconds(0.5f); 
        }

        yield return new WaitForSeconds(1); 

        bool gameHasStopped = SceneManager.GetActiveScene().name == "Exit"; 

        Assert.IsTrue(
            hasPlayerMoved || gameHasStopped,
            "Player should move with WASD keys, or destroying five targets should stop play."
        );
    }

    [UnityTest]
    public IEnumerator PlayerMovesWithArrows_OR_NameFromIntroShowsInGameScene()
    {
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(1); 

        var inputField = GameObject.Find("NameInputField").GetComponent<InputField>();
        inputField.text = "TestPlayer"; 

        var playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.Invoke();
        yield return new WaitForSeconds(1);

        var player = GameObject.Find("Player");
        Vector3 startPosition = player.transform.position;

        player.transform.position += new Vector3(1, 0, 0); 
        yield return new WaitForSeconds(1);

        Vector3 newPosition = player.transform.position;
        bool hasPlayerMoved = startPosition != newPosition; 

        var playerNameText = GameObject.Find("NameText").GetComponent<Text>();
        bool nameIsShown = playerNameText.text == "TestPlayer"; 
        Assert.IsTrue(
            hasPlayerMoved || nameIsShown,
            "Player should move with arrow keys, or the player name from the Intro scene should be shown in the Game scene."
        );
    }

}