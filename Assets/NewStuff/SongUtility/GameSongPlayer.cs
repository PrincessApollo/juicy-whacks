﻿using UnityEngine;
using UnityEngine.SceneManagement;


namespace AudioUtilities
{

    public class GameSongPlayer : MonoBehaviour
    {
        public static GameSongPlayer Instance { get; private set; } = null;

        [SerializeField] bool playFirstSongOnStart = false;

        SongPlayer player = null;
        new AudioSource audio = null;
        public static bool IsDone { get; private set; } = false;

        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null) Instance = this; else Destroy(this);
        }
        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (SongImporter.Ready && player == null && playFirstSongOnStart) Play(song: SongImporter.Songs[0]); // REMOVE!!! THIS IS FOR TESTING ONLY
            if (SongImporter.Ready && player == null && SongSelection.selection != null) Play(song: SongSelection.selection);
            if(!(player == null) && player.BeatIndex != 0)
            {
                foreach (GameObject hole in Holes.holes)
                {
                    hole.GetComponent<Hole>().beatIndex = player.BeatIndex-1;
                }
            }
            if(!(player == null) && !player.IsPlaying)
            {
                audio.Stop();
                if (player.IsDone)
                {
                    IsDone = true;
                }
            }


            //harriets if the "ShoulPause" Variable is true - then the Pause function should start
            if (MenuScripts.ShouldPause)
            {
                Pause();

            }
            //harriets if the "shouldPause" Variable is false - then the UnPause function should start
            if (MenuScripts.ShouldPause == false)
            {
                Pause();
                //UnPause();
            }

        }


        public void Play(Song song)
        {
            player = new SongPlayer();
            player.Play(song);
            audio.PlayOneShot(song.clip);
            for (int i = 0; i < Holes.holes.Length; i++)
            {
                //Debug.Log($"Filling hole {i}");
                Holes.holes[i].GetComponent<Hole>().queue = song.GetIntArray(i);
            }
        }
        public void Pause()
        {
            audio.Pause();
            player.Pause();
        }

        //Harriet gör saker för hon är trött och vill få detta donw with
        public void UnPause()
        {
            audio.UnPause();
        //NÅGOT MED PLAYER?
        }

    }
}
