using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAssigment3
{
    public partial class AddRequestPage : ContentPage
    {
        private MeetingRoom _selectedRoom;

        public AddRequestPage(MeetingRoom room)
        {
            InitializeComponent();
            _selectedRoom = room;

            // Bind the selected room details.
            RoomDetailsLabel.Text = $"Room: {_selectedRoom.RoomNumber} | Capacity: {_selectedRoom.SeatingCapacity} | Layout: {_selectedRoom.RoomLayout}";
            MeetingDatePicker.Date = DateTime.Today;
        }

        private async void OnAddRequestClicked(object sender, EventArgs e)
        {
            try
            {
                string requestedBy = NameEntry.Text;
                string description = DescriptionEditor.Text;
                DateTime meetingDate = MeetingDatePicker.Date;
                TimeSpan startTime = StartTimePicker.Time;
                TimeSpan endTime = EndTimePicker.Time;
                int participantCount = int.Parse(ParticipantCountEntry.Text);
                
                var request = App.ReservationRequestManager.AddReservationRequest(
                    _selectedRoom.RoomNumber,
                    requestedBy,
                    description,
                    meetingDate,
                    startTime,
                    endTime,
                    participantCount);

                await DisplayAlert("Success", $"Reservation Request #{request.RequestID} added successfully.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error adding reservation request: {ex.Message}", "OK");
            }
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
}}