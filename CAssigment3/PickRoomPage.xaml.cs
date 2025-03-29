namespace CAssigment3
{
    public partial class PickRoomPage : ContentPage
    {
        public PickRoomPage()
        {
            InitializeComponent();
            RoomsListView.ItemsSource = App.ReservationRequestManager.MeetingRooms;
        }

        private void OnAddRequestClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRequestPage());
        }

        private void OnViewRequestsClicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new ViewRequestsPage());
        }
    }
}
