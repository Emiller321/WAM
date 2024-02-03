using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;


namespace Bluetooth_connect_Findall
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AudioPlayer : Page
    {
        /// <summary>
        ///MediaPlayBack for downloaded media files
        /// </summary>

        private MediaPlayer mediaplayer;

        public AudioPlayer()
        {
            this.InitializeComponent();

            playButton.IsEnabled = false;
            resumeButton.IsEnabled = false;
            pauseButton.IsEnabled = false;

            mediaplayer = new MediaPlayer();

            mediaplayerElement.SetMediaPlayer(mediaplayer);

        }
        private async void mediapicker()
        {
            var mediaPicker = new FileOpenPicker();

            mediaPicker.FileTypeFilter.Add(".mp3");

            mediaPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;

            StorageFile mediaFile = await mediaPicker.PickSingleFileAsync();

            mediaplayer.Source = MediaSource.CreateFromStorageFile(mediaFile);

            try
            {
                mediaplayer.Source = MediaSource.CreateFromStorageFile(mediaFile);
                playButton.IsEnabled = true;
            }
            catch
            {

            }

        }

        /// <summary>
        /// Load Video Button
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediapicker();
        }

        /// <summary>
        /// Play Button
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pauseButton.IsEnabled = true;
            playButton.IsEnabled = false;
            mediaplayer.PlaybackSession.Position = new TimeSpan(0);
            mediaplayer.Play();
        }

        /// <summary>
        /// Pause Button
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pauseButton.IsEnabled = false;
            resumeButton.IsEnabled = true;
            mediaplayer.Pause();
        }

        /// <summary>
        /// Resume Button
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mediaplayer.Play();
            pauseButton.IsEnabled = true;
            resumeButton.IsEnabled = false;
        }

        /// <summary>
        /// Exit Button
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }

}

