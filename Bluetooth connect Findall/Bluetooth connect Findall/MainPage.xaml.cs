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
using Windows.Devices.Bluetooth.Rfcomm;
using System.Diagnostics;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.System;
using Bluetooth_connect_Findall;

namespace Bluetooth
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<DeviceInformation> PairedDevices { get; private set; } = new ObservableCollection<DeviceInformation>();
        //private BluetoothDevice _selectedDevice;
        private DeviceInformation _selectedDeviceInfo;
        private RfcommDeviceService _rfcommService;
        // private Guid generatedUUID = Guid.Empty;
        public MainPage()
        {
            this.InitializeComponent();
            LoadPairedDevicesAsync();

            //MyNavigationView.ItemInvoked += OnNavigationViewItemInvoked;
            //contentFrame.Navigate(typeof(MainPage));
        }

        private void OnNavigationViewItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // Handle settings navigation if needed
            }
            else
            {
                // Handle regular item navigation
                string tag = args.InvokedItemContainer.Tag.ToString();

                switch (tag)
                {
                    case "Home":
                        // Navigate to the main page
                        contentFrame.Navigate(typeof(MainPage));
                        break;
                    case "Audio Player Page":
                        // Navigate to the second page
                        contentFrame.Navigate(typeof(AudioPlayer));
                        break;
                }
            }
        }

        private Guid GetStoredUUID()
        {
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("StoredUUID", out object storedValue))
            {
                if (storedValue is string storedUUIDString && Guid.TryParse(storedUUIDString, out Guid storedUUID))
                {
                    return storedUUID;
                }
            }

            return Guid.Empty;
        }

        private void StoreUUID(Guid uuid)
        {
            ApplicationData.Current.LocalSettings.Values["StoredUUID"] = uuid.ToString();
        }

        private Guid GenerateOrRetrieveUUID()
        {
            Guid storedUUID = GetStoredUUID();
            if (storedUUID == Guid.Empty)
            {
                storedUUID = Guid.NewGuid();
                StoreUUID(storedUUID);
            }

            return storedUUID;
        }

        private async Task ConnectToDeviceAsync()
        {
            try
            {
                if (_selectedDeviceInfo != null)
                {
                    BluetoothDevice _selectedDevice = await BluetoothDevice.FromIdAsync(_selectedDeviceInfo.Id);
                    Guid uuidForConnection = GenerateOrRetrieveUUID();
                    if (_selectedDevice != null)
                    {
                        var services = await _selectedDevice.GetRfcommServicesForIdAsync(
                            RfcommServiceId.FromUuid(uuidForConnection),
                            BluetoothCacheMode.Uncached);

                        _rfcommService = services.Services.FirstOrDefault();


                        if (_rfcommService != null)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                            {
                                // Connect to the Rfcomm service
                                var socket = new Windows.Networking.Sockets.StreamSocket();
                                await socket.ConnectAsync(_rfcommService.ConnectionHostName, _rfcommService.ConnectionServiceName);

                                // Now you have a connected socket, and you can perform further operations as needed.
                            });
                        }
                        else
                        {
                            // Handle the case where the Rfcomm service is not found
                            ShowErrorMessage("Rfcomm service not found for the selected device.");
                        }
                    }
                    else
                    {
                        // Handle the case where the Bluetooth device is not accessible
                        ShowErrorMessage("Could not access the selected Bluetooth device.");
                    }
                }
                else
                {
                    // Handle the case where no device is selected
                    ShowErrorMessage("No device selected.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                // Handle other exceptions
                ShowErrorMessage($"Error: {ex.Message}");
            }
        }

        private async void ShowErrorMessage(string message)
        {
            Debug.WriteLine(message);
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
        private void PairedDevicesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PairedDevicesListView.SelectedItem != null)
                {
                    _selectedDeviceInfo = PairedDevicesListView.SelectedItem as DeviceInformation;
                    Debug.WriteLine($"Selected device: {_selectedDeviceInfo?.Name}");
                    //_selectedDevice = PairedDevicesListView.SelectedItem as DeviceInformation;
                    //Debug.WriteLine($"Selected device: {_selectedDevice?.Name}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in SelectionChanged event: {ex.Message}");
            }
        }
        private async void LoadPairedDevicesAsync()
        {
            PairedDevices.Clear();
            var devices = await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());
            PairedDevices = new ObservableCollection<DeviceInformation>(devices);

            // Notify the UI that the collection has changed
            PairedDevicesListView.ItemsSource = PairedDevices;
        }
        private async void LoadVirtualAudioCableAsync()
        {
            // Replace "externalAppFile.txt" with the file you want to open
            var file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("vrtaucbl.sys", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            // Launch the default app associated with the file
            var success = await Windows.System.Launcher.LaunchFileAsync(file);

            if (!success)
            {
                ShowErrorMessage("Could not access Virtual Audio Cable Software");
            }
        }

        private void LoadVirtualAudioCable_Click(object sender, RoutedEventArgs e)
        {
            LoadVirtualAudioCableAsync();
        }
        private void LoadPairedDevicesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPairedDevicesAsync();
        }
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            // Trigger the connection asynchronously
            await ConnectToDeviceAsync();
        }

    }
}