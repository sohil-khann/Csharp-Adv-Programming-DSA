using System;

/* 
Scenario 2: Music Playlist Queue
Use Case: A music player plays songs one after another and can dynamically add/remove songs.
Why LinkedList? Dynamic addition/removal from both ends.
*/

// Node class representing a single song in the playlist
class SongNode
{
    public string SongTitle;
    public string Artist;
    public SongNode Next;

    public SongNode(string title, string artist)
    {
        SongTitle = title;
        Artist = artist;
        Next = null;
    }
}

// Base class for Media Players
abstract class MediaPlayer
{
    public abstract void PlayNext();
}

// MusicPlayer class inheriting from MediaPlayer (Polymorphism)
class MusicPlayer : MediaPlayer
{
    private SongNode head; // Encapsulation: Playlist data is secured (private)
    private SongNode currentPlaying;

    // Abstraction: Simple method to add a song
    public void AddSong(string title, string artist)
    {
        SongNode newSong = new SongNode(title, artist);
        if (head == null)
        {
            head = newSong;
        }
        else
        {
            SongNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newSong;
        }
        Console.WriteLine("Added song: " + title + " by " + artist);
    }

    // Abstraction: Simple method to remove a song by title
    public void RemoveSong(string title)
    {
        if (head == null) return;

        if (head.SongTitle == title)
        {
            head = head.Next;
            Console.WriteLine("Removed song: " + title);
            return;
        }

        SongNode temp = head;
        while (temp.Next != null && temp.Next.SongTitle != title)
        {
            temp = temp.Next;
        }

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Removed song: " + title);
        }
        else
        {
            Console.WriteLine("Song not found: " + title);
        }
    }

    // Implementation of PlayNext (Abstraction)
    public override void PlayNext()
    {
        if (currentPlaying == null)
        {
            currentPlaying = head;
        }
        else
        {
            currentPlaying = currentPlaying.Next;
        }

        if (currentPlaying != null)
        {
            Console.WriteLine("Now playing: " + currentPlaying.SongTitle + " by " + currentPlaying.Artist);
        }
        else
        {
            Console.WriteLine("End of playlist.");
            currentPlaying = null; // Reset for next time
        }
    }

    public void DisplayPlaylist()
    {
        Console.WriteLine("\n--- Current Playlist ---");
        SongNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("- " + temp.SongTitle + " (" + temp.Artist + ")");
            temp = temp.Next;
        }
        Console.WriteLine("------------------------\n");
    }
}

// Main class to demonstrate the Music Playlist
class MusicPlaylistDemo
{
    public static void Run()
    {
        MusicPlayer myPlayer = new MusicPlayer();

        myPlayer.AddSong("Shape of You", "Ed Sheeran");
        myPlayer.AddSong("Blinding Lights", "The Weeknd");
        myPlayer.AddSong("Stay", "Justin Bieber");

        myPlayer.DisplayPlaylist();

        myPlayer.PlayNext();
        myPlayer.PlayNext();

        myPlayer.RemoveSong("Blinding Lights");
        myPlayer.DisplayPlaylist();

        myPlayer.PlayNext();
    }
}
