namespace CAssigment3
{
    public partial class PickRoomPage : ContentPage
    {
        public PickRoomPage()
        {
            InitializeComponent();

            // Bind the meeting rooms to the ListView.
            RoomsListView.ItemsSource = App.ReservationRequestManager.MeetingRooms;
            RoomsListView.ItemSelected += RoomsListView_ItemSelected;
        }

        /// <summary>
        /// Updates the displayed room image when the user selects a room.
        /// </summary>
        private void RoomsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var selectedRoom = e.SelectedItem as MeetingRoom;
                if (selectedRoom != null)
                {
                    RoomImage.Source = selectedRoom.RoomImageFileName;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error updating room image: {ex.Message}", "OK");
            }
        }


        private async void OnAddRequestClicked(object sender, EventArgs e)
        {
            try
            {
                if (RoomsListView.SelectedItem is MeetingRoom selectedRoom)
                {
                    await Navigation.PushAsync(new AddRequestPage(selectedRoom));
                }
                else
                {
                    await DisplayAlert("Error", "Please select a room first.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
            }
        }
        
        private async void OnViewRequestsClicked(object sender, EventArgs e)
        {
            try
            {
                if (RoomsListView.SelectedItem is MeetingRoom selectedRoom)
                {
                    await Navigation.PushAsync(new ViewRequestsPage(selectedRoom));
                }
                else
                {
                    await DisplayAlert("Error", "Please select a room first.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
            }
        }
    }
}