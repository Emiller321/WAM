using System;
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
using Windows.Devices;
using Windows.Devices.Enumeration;
using System.Collections.ObjectModel;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using System.Drawing;
using Windows.Media.Core;
using Windows.Media.Playback;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Bluetooth_connect_Findall
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<DeviceInformation> PairedDevices { get; private set; } = new ObservableCollection<DeviceInformation>();
        public MainPage()
        {
            this.InitializeComponent();
            LoadPairedDevicesAsync();
        }
        private async void LoadPairedDevicesAsync()
        {
            PairedDevices.Clear();
            var devices = await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());
            foreach (var device in devices)
            {
                PairedDevices.Add(device);
            }

            // Notify the UI that the collection has changed
            PairedDevicesListView.ItemsSource = null;
            PairedDevicesListView.ItemsSource = PairedDevices;
        }
        private void LoadPairedDevicesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPairedDevicesAsync();
        }

    }
}