using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	/// <summary>
	/// This variable is used to display text to the user in the game. 
	/// </summary>
	public Text userDisplay;
	/// <summary>
	/// This is the text that the user guesses
	/// </summary>
	public Text userGuessValueText;
	/// <summary>
	/// This value is used to display the letter that the user has guessed.
	/// </summary>
	public Text userLettersGuessedDisplay;
	/// <summary>
	/// This variable is used to display the number of chances remaining for the user (i.e., the number chances they have to guess the phrase).
	/// For now, this value will be 5.
	/// </summary>
	public Text numberOfChanceRemainingDisplay;
	/// <summary>
	/// This is the value that will be used to display the win or loose text.
	/// </summary>
	public Text winLoseDisplay;

	/// <summary>
	/// This is the phrase the was guessed by the user.
	/// </summary>
	public InputField phraseGuessInputField;
	/// <summary>
	/// This is letter value that was guessed by the user
	/// </summary>
	public InputField userInputField;

	/// <summary>
	/// This list is used to store the letters that are the answers.
	/// </summary>
	private List<string> answerCharacterList = new List<string>();
	/// <summary>
	/// This list is used to store the bool values of the letters that should be shown. 
	/// In other words, should the letter be shown (true of false)?
	/// </summary>
	private List<bool> showCharacter = new List<bool>();
	/// <summary>
	/// The value is used to keep track of the values that were already guessed.
	/// </summary>
	private List<string> userGuesses = new List<string> ();

	/// <summary>
	/// This is the character that will be used as a place holder for the character letters. 
	/// I reccommend this value be something other than a letter (e.g., "*", "#", etc.)
	/// </summary>
	private string letterPlaceHolder = "*";
	/// <summary>
	/// This is the text you want to display when the player wins
	/// </summary>
	private string winDisplayText = "You Won!";
	/// <summary>
	/// This is the text you want to display when the player does not win.
	/// </summary>
	private string loseDisplayText = "You Lost!";
	/// <summary>
	/// This variable will be used to store your phrase the players must guess. 
	/// Remember to ONLY include letters and no other characters (e.g., ".", "\", "'", etc.).
	/// </summary>
	private string phrase = "This is the first game I created"; //

	/// <summary>
	/// This is to store the number of wrong guesses the user has made.
	/// </summary>
	private int numberOfWrongUserGuesses = 0;
	/// <summary>
	/// This is to store the max number of guesses the user has. 
	/// For now, this value should be 5.
	/// </summary>
	private int maxNumberOfWrongGuesses;

	/// <summary>
	/// This is the goblin GameObject. 
	/// For now, you will not manipulate this value. 
	/// </summary>
	public GameObject goblin;

	void Start () {
		//Make every letter uppercase. This will make checking letters with the user input easier. (Hint: string have a method ToUpper)
		phrase = phrase.ToUpper();

		//Populate answerCharacterList with letter answers and add a corresponding boolean value to showCharacter that indicates the value should or should not be shown.  
		for (int i = 0; i < phrase.Length; i++) {
			//Debug.Log (i);
			answerCharacterList.Add (phrase [i].ToString());
			showCharacter.Add (false);

		}

		/* Your phrase will more than likely have space (i.e., " ") within it. 
		 * If there are spaces then we want to make sure we display those spaces and only hide the letters.
		 * If the answer is a space (i.e., " ") then set showCharacter value to show that character.
		*/
		for (int j = 0; j < answerCharacterList.Count; j++) {
			if (answerCharacterList[j] == " ") {
				showCharacter [j] = true;
			}
		}

		/* Generate a string value that will be shown to the user. 
		 * In other words, the string that will have the placeholder value.
		*/
		string displayString = "";
		for (int i = 0; i < showCharacter.Count; i++) {
			if (showCharacter [i]) {
				displayString += answerCharacterList [i];
			} else {
				displayString += letterPlaceHolder;
			}
		}

		//KEEP CODE - Display place holder text (i.e., place holder string)
		userDisplay.text = displayString;

		//KEEP CODE - Set the letters guessed display
		userLettersGuessedDisplay.text = "";

		//KEEP CODE - Count the total number of body parts and set that equal to the number max number of guesses. 
		maxNumberOfWrongGuesses = goblin.transform.childCount;
		numberOfChanceRemainingDisplay.text = maxNumberOfWrongGuesses.ToString ();

		//KEEP CODE - "Turn off" each boddy part (i.e., hide each body part).
		int numberOfGoblinChildren = goblin.transform.childCount;
		for (int t = 0; t < numberOfGoblinChildren; t++) {
			//Locate the child
			GameObject currentChild = goblin.transform.GetChild (t).gameObject;
			//Turn the child off
			currentChild.SetActive (false);
		}
	}

	public void CheckGuessUpdateGame(){
		//KEEP CODE - Get the user's guess
		string currentUserGuess = "";
		currentUserGuess = userGuessValueText.text;

		//KEEP CODE - Specificaaly the if branch - Need to check and make sure the user actually input a guess. If the user did not put in a guess, then do nothing
		if(currentUserGuess != "" && currentUserGuess != " " && numberOfWrongUserGuesses != maxNumberOfWrongGuesses && !userGuesses.Contains(currentUserGuess) && showCharacter.Contains(false)){ 
			/*
			 * The user must put in a guess (i.e., not "" or " "), 
			not have the number of wrong guesses equal to the max number of guesses, 
			the current letter must not have been guessed previously,
			at least one letter must be hidden
			*/
			//Does the phrase contain the letter that was guessed? 
			if(answerCharacterList.Contains(userGuessValueText.text)){
				//If so, then display the letters that were guessed correctly

				//Need to just the bool to true in order to show the correct letters
				for (int j = 0; j < answerCharacterList.Count; j++) {
					if (answerCharacterList[j] == currentUserGuess) {
						showCharacter [j] = true;
					}
				}

				//Display the new letters
				string displayString = "";
				for (int i = 0; i < showCharacter.Count; i++) {
					if (showCharacter [i]) {
						displayString += answerCharacterList [i];
					} else {
						displayString += letterPlaceHolder;
					}

				}
				userDisplay.text = displayString;

				//KEEP CODE - Clear the letter that was recently guessed.
				userInputField.text = "";

				//If no letters are hidden then that means the player wins!
				if(!showCharacter.Contains(false)){
					winLoseDisplay.gameObject.SetActive(true);
					winLoseDisplay.text = winDisplayText;
				}

			} else {
				//If it does not contain that text, then show a goblin body part because theis means that the guess was wrong. The game variables need to be updated. 
				//Increase the number of wrong guess by 1
				numberOfWrongUserGuesses += 1;

				//If the number of wrong guess is greater than or equal to the max number of guesses, then the game is over
				if (numberOfWrongUserGuesses < maxNumberOfWrongGuesses) {
					//Turn on one of the children
					goblin.transform.GetChild(numberOfWrongUserGuesses - 1).gameObject.SetActive(true);

					//Display the number of chances remaining
					numberOfChanceRemainingDisplay.text = (maxNumberOfWrongGuesses - numberOfWrongUserGuesses).ToString();
				} else {
					//Turn on the last child and end game.
					goblin.transform.GetChild(numberOfWrongUserGuesses - 1).gameObject.SetActive(true);

					//Display the number of chances remaining
					numberOfChanceRemainingDisplay.text = (maxNumberOfWrongGuesses - numberOfWrongUserGuesses).ToString();

					//Display the text for when a player lost.
					winLoseDisplay.gameObject.SetActive(true);
					winLoseDisplay.text = loseDisplayText;
				}
			}

			//Update the list that the user guessed. HINT: used userGuesses List
			userGuesses.Add(currentUserGuess);

			//Build a string that has a list of the user's guesses
			string currerntUserPastGuesses = "";
			foreach(string letter in userGuesses){
				//Space added after to letter to make it readable. 
				currerntUserPastGuesses += letter + " ";
			}
			//KEEP CODE - Display the string that was built
			userLettersGuessedDisplay.text = currerntUserPastGuesses;

			//KEEP CODE - Rest user input text
			userGuessValueText.text = "";
		}

		//KEEP CODE - This is used to keep the "focuse" on the input field.
		userInputField.ActivateInputField ();
	}

	public void CheckPhraseUpdateGame(){
		//Check the phrase guess given by the user
		//KEEP CODE - Get the phrase given by the user
		string userPhraseInput = phraseGuessInputField.text;

		/*
		 * The user may accidently enter extra spaces and may throw off string comparison.
		 * To remove the posibility of extra spaces, we need to remove all spaces in the user's guess.
		 * However, there will also be spaces in the phrase answer as well. 
		 * We will need to remove all spaces in the phrase as well.
		 * Also, the user my have different caps as well (e.g., A vs. a).
		 * To remove this difference, we will need to make the user's guess and the answer, all caps as well (note: the answer should already be in all caps).
		*/

		//KEEP CODE - Remove spaces from users guess and actual answer.
		userPhraseInput = userPhraseInput.Replace(" ", "");
		phrase = phrase.Replace (" ", "");

		//Make each letter uppercase
		userPhraseInput = userPhraseInput.ToUpper();
		phrase = phrase.ToUpper ();

		//Dide the user guess the phrase correctly?
		if (userPhraseInput.Equals (phrase)) {
			//This means that the user guessed the phrase correctly and they win!

			//Display the answer!
			for(int q = 0; q < showCharacter.Count; q++){
				showCharacter [q] = true;
			}

			string answerStringBuild = "";
			for (int i = 0; i < answerCharacterList.Count; i++) {
				
				if (showCharacter[i]) {
					answerStringBuild += answerCharacterList [i];
				}
			}

			//Display answer
			userDisplay.text = answerStringBuild;

			//Let the user know they have won!
			winLoseDisplay.gameObject.SetActive(true); //Turn it on first.
			winLoseDisplay.text = winDisplayText;
		} else {
			//This means that the user did not get the phrase correctly and they loose!
			//Increase the number of wrong guess by 1
			numberOfWrongUserGuesses += 1;

			//If the number of wrong guess is greater than or equal to the max number of guesses, then the game is over
			if (numberOfWrongUserGuesses < maxNumberOfWrongGuesses) {
				//Turn on one of the children
				goblin.transform.GetChild(numberOfWrongUserGuesses - 1).gameObject.SetActive(true);

				//Display the number of chances remaining
				numberOfChanceRemainingDisplay.text = (maxNumberOfWrongGuesses - numberOfWrongUserGuesses).ToString();
			} else {
				//Turn on the last child and end game.
				goblin.transform.GetChild(numberOfWrongUserGuesses - 1).gameObject.SetActive(true);

				//Display the number of chances remaining
				numberOfChanceRemainingDisplay.text = (maxNumberOfWrongGuesses - numberOfWrongUserGuesses).ToString();

				//Display the text for when a player lost.
				winLoseDisplay.gameObject.SetActive(true);
				winLoseDisplay.text = loseDisplayText;
			}
		}
	}
}
