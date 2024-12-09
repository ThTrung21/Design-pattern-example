using System;

namespace MusicPlayerDemo
{
    // State Interface
    public interface IMusicPlayerState
    {
        void Play(MusicPlayer player);
        void Pause(MusicPlayer player);
        void Stop(MusicPlayer player);
    }

    // Concrete State: Playing
    public class PlayingState : IMusicPlayerState
    {
        public void Play(MusicPlayer player)
        {
            Console.WriteLine("The music is already playing.");
        }

        public void Pause(MusicPlayer player)
        {
            Console.WriteLine("Pausing the music.");
            player.SetState(new PausedState());
        }

        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("Stopping the music.");
            player.SetState(new StoppedState());
        }
    }

    // Concrete State: Paused
    public class PausedState : IMusicPlayerState
    {
        public void Play(MusicPlayer player)
        {
            Console.WriteLine("Resuming the music.");
            player.SetState(new PlayingState());
        }

        public void Pause(MusicPlayer player)
        {
            Console.WriteLine("The music is already paused.");
        }

        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("Stopping the music.");
            player.SetState(new StoppedState());
        }
    }

    // Concrete State: Stopped
    public class StoppedState : IMusicPlayerState
    {
        public void Play(MusicPlayer player)
        {
            Console.WriteLine("Starting the music.");
            player.SetState(new PlayingState());
        }

        public void Pause(MusicPlayer player)
        {
            Console.WriteLine("The music is already stopped.");
        }

        public void Stop(MusicPlayer player)
        {
            Console.WriteLine("The music is already stopped.");
        }
    }

    // Context: Music Player
    public class MusicPlayer
    {
        private IMusicPlayerState _currentState;

        public MusicPlayer()
        {
            // Initial state: Stopped
            _currentState = new StoppedState();
        }

        public void SetState(IMusicPlayerState state)
        {
            _currentState = state;
        }

        public void Play()
        {
            _currentState.Play(this);
        }

        public void Pause()
        {
            _currentState.Pause(this);
        }

        public void Stop()
        {
            _currentState.Stop(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var musicPlayer = new MusicPlayer();

            // Test Play, Pause, Stop behavior
            musicPlayer.Play();   // Starts the music
            musicPlayer.Pause();  // Pauses the music
            musicPlayer.Play();   // Resumes the music
            musicPlayer.Stop();   // Stops the music
            musicPlayer.Pause();  // Can't pause, already stopped
        }
    }
}
