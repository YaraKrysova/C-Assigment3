using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAssigment3
{
    public partial class AddRequestPage : ContentPage
    {
        public AddRequestPage()
        {
            InitializeComponent();
        }

        private void OnSubmitRequestClicked(object sender, EventArgs e)
        {
            try
            {
                // In a real scenario, you'd pick the selected room from the previous page or a dropdown
                // For demonstration, let's assume a default room number:
                string roomNumber = "A102";

                string requestedBy = RequestedByEntry.Text;
                string description = DescriptionEditor.Text;
                DateTime meetingDate = MeetingDatePicker.Date;
                TimeSpan startTime = StartTimePicker.Time;
                TimeSpan endTime = EndTimePicker.Time;
                int participantCount = int.Parse(ParticipantCountEntry.Text);

                // Use your ReservationRequestManager to create the request
                var request = App.ReservationRequestManager.AddReservationRequest(
                    roomNumber,
                    requestedBy,
                    description,
                    meetingDate,
                    startTime,
                    endTime,
                    participantCount
                );

                DisplayAlert("Success", $"Request #{request.RequestID} submitted.", "OK");
                Navigation.PopAsync(); // Go back to the previous page
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}