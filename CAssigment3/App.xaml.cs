namespace CAssigment3;

public partial class App : Application
{
    public static ReservationRequestManager ReservationRequestManager { get; private set; }

    public App()
    {
        InitializeComponent();

        ReservationRequestManager = new ReservationRequestManager();

        if (!ReservationRequestManager.MeetingRooms.Any())
        {
            ReservationRequestManager.AddMeetingRoom("A101", 20, RoomLayoutType.HollowSquare, "HollowSquare.png");
            ReservationRequestManager.AddMeetingRoom("B102", 25, RoomLayoutType.UShape, "UShape.png");
            ReservationRequestManager.AddMeetingRoom("C103", 30, RoomLayoutType.Classroom, "Classroom.png");
            ReservationRequestManager.AddMeetingRoom("D104", 50, RoomLayoutType.Auditorium, "Auditorium.png");
        }
        
        MainPage = new NavigationPage(new PickRoomPage());
    }
}
}