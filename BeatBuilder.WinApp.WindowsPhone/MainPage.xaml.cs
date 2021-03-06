﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BeatBuilder.Audio;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BeatBuilder.WinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        AudioRenderer renderer;
        DrumPad drumPad;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.renderer = await AudioRenderer.CreateAsync();
            this.renderer.Start();

            var rootPath = Windows.ApplicationModel.Package.Current.InstalledLocation.Path + "\\Sounds\\";
            this.drumPad = new DrumPad();
            this.drumPad.SetDrumSound(DrumKind.Bass, rootPath + "Drum-Bass.wav");
            this.drumPad.SetDrumSound(DrumKind.Snare, rootPath + "Drum-Snare.wav");
            this.drumPad.SetDrumSound(DrumKind.Shaker, rootPath + "Drum-Shaker.wav");
            this.drumPad.SetDrumSound(DrumKind.ClosedHiHat, rootPath + "Drum-Closed-Hi-Hat.wav");
            this.drumPad.SetDrumSound(DrumKind.Cowbell, rootPath + "Cowbell.wav");
            this.drumPad.SetDrumSound(DrumKind.OpenHiHat, rootPath + "Drum-Open-Hi-Hat.wav");
            this.drumPad.SetDrumSound(DrumKind.RideCymbal, rootPath + "Drum-Ride-Cymbal.wav");
            this.drumPad.SetDrumSound(DrumKind.FloorTom, rootPath + "Drum-Floor-Tom.wav");
            this.drumPad.SetDrumSound(DrumKind.HighTom, rootPath + "Drum-High-Tom.wav");

            this.renderer.ListenTo(this.drumPad);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void BassButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.Bass);
        }

        private void SnareButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.Snare);
        }

        private void ShakerButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.Shaker);
        }

        private void ClosedHiHatButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.ClosedHiHat);
        }

        private void CowbellButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.Cowbell);
        }

        private void OpenHiHatButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.OpenHiHat);
        }

        private void RideCymbalButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.RideCymbal);
        }

        private void FloorTomButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.FloorTom);
        }

        private void HighTomButton_Click(object sender, RoutedEventArgs e)
        {
            this.drumPad.PlayDrum(DrumKind.HighTom);
        }
    }
}
