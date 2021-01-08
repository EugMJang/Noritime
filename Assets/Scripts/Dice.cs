using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(1, 625);

            // Set sprite to upper face of dice from array according to random value
            if (randomDiceSide >= 1 && randomDiceSide <= 72) {
                rend.sprite = diceSides[0];
            }
            else if (randomDiceSide >= 73 && randomDiceSide <= 288) {
                rend.sprite = diceSides[1];
            }
            else if (randomDiceSide >= 289 && randomDiceSide <= 504) {
                rend.sprite = diceSides[2];
            }
            else if (randomDiceSide >= 505 && randomDiceSide <= 585) {
                rend.sprite = diceSides[3];
            }
            else if (randomDiceSide >= 586 && randomDiceSide <= 601) {
                rend.sprite = diceSides[4];
            }
            else if (randomDiceSide >= 602 && randomDiceSide <= 625) {
                rend.sprite = diceSides[5];
            }
            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        // Show final dice value in Console
        Debug.Log(finalSide);
    }
}
