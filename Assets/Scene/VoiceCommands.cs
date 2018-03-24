using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour {
    private KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, Action>();

	// Use this for initialization
	void Start () {
		keywords.Add("reset blocks", () => {
            BroadcastMessage("OnResetBlock");
		});

        keywords.Add("shoot ball", () => {
            BroadcastMessage("OnShoot");
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnOnPhraseRecognized;
	    keywordRecognizer.Start();
	}

    private void KeywordRecognizerOnOnPhraseRecognized(PhraseRecognizedEventArgs args) {
        Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction)) {
            keywordAction.Invoke();
        }
    }

    // Update is called once per frame
	void Update () {
		
	}
}
