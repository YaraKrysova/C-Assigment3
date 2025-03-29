using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAssigment3
{
    public partial class ViewRequestsPage : ContentPage
    {
        private MeetingRoom _selectedRoom;

        public ViewRequestsPage(MeetingRoom room)
        {
            InitializeComponent();
            _selectedRoom = room;
            
            SelectedRoomLabel.Text = $"Reservations for Room: {_selectedRoom.RoomNumber}";
            
            var requestsForRoom = App.ReservationRequestManager.ReservationRequests
                .Where(r => r.MeetingRoom.RoomNumber.Equals(_selectedRoom.RoomNumber, StringComparison.OrdinalIgnoreCase))
                .ToList();
            RequestsListView.ItemsSource = requestsForRoom;
        }
        
        private async void OnBackToRoomsClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
            }
        }
    }
}