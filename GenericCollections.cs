using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        private string songGenre;

        public string SongGenre
        {
            get { return songGenre; }
            set
            {
                var validGenres = new List<string>
                { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };
                if (validGenres.Contains(value))
                    songGenre = value;
                else
                    throw new ArgumentException("Invalid genre. Valid genres are: Pop, HipHop, Soul Music, Jazz, Rock, Disco, Melody, Classic");
            }
        }

        public override string ToString()
        {
            return $"SongId: {SongId}, SongName: {SongName}, SongGenre: {SongGenre}";
        }
    }

    // Step 2: Interface
    public interface IPlaylist
    {
        void Add(Song song);
        void Remove(int songId);
        Song GetSongById(int songId);
        Song GetSongByName(string songName);
        List<Song> GetAllSongs();
    }

    // Step 3: MyPlayList class implementing IPlaylist
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private readonly int capacity = 20;

        public MyPlayList() { }

        public void Add(Song song)
        {
            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Cannot add more songs. Playlist is full (max 20).");
                return;
            }

            if (myPlayList.Any(s => s.SongId == song.SongId))
            {
                Console.WriteLine("A song with the same SongId already exists.");
                return;
            }

            myPlayList.Add(song);
            Console.WriteLine("Song added successfully.");
        }

        public void Remove(int songId)
        {
            var song = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (song != null)
            {
                myPlayList.Remove(song);
                Console.WriteLine("Song removed successfully.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.FirstOrDefault(s => s.SongId == songId);
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetAllSongs()
        {
            return myPlayList;
        }
    }

    // Step 4: Program class with Main method
    class Program
    {
        static void Main(string[] args)
        {
            MyPlayList playlist = new MyPlayList();

            while (true)
            {
                Console.WriteLine("\nEnter:\n1: Add Song\n2: Remove Song by Id\n3: Get Song by Id\n4: Get Song by Name\n5: Get All Songs\n6: Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Song newSong = new Song();
                            Console.Write("Enter Song Id: ");
                            newSong.SongId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Song Name: ");
                            newSong.SongName = Console.ReadLine();
                            Console.Write("Enter Song Genre: ");
                            newSong.SongGenre = Console.ReadLine();

                            playlist.Add(newSong);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Song Id to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        playlist.Remove(removeId);
                        break;

                    case "3":
                        Console.Write("Enter Song Id: ");
                        int searchId = int.Parse(Console.ReadLine());
                        var songById = playlist.GetSongById(searchId);
                        Console.WriteLine(songById != null ? songById.ToString() : "Song not found.");
                        break;

                    case "4":
                        Console.Write("Enter Song Name: ");
                        string searchName = Console.ReadLine();
                        var songByName = playlist.GetSongByName(searchName);
                        Console.WriteLine(songByName != null ? songByName.ToString() : "Song not found.");
                        break;

                    case "5":
                        var allSongs = playlist.GetAllSongs();
                        if (allSongs.Count == 0)
                        {
                            Console.WriteLine("Playlist is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Songs in Playlist:");
                            foreach (var song in allSongs)
                            {
                                Console.WriteLine(song.ToString());
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
