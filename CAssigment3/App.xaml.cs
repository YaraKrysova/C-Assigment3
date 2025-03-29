namespace CAssigment3;

public partial class App : Application
{
    public static ReservationRequestManager ReservationRequestManager { get; private set; }

    public App()
    {
        InitializeComponent();
        ReservationRequestManager = new ReservationRequestManager();
        ReservationRequestManager.AddMeetingRoom("A102", 20, RoomLayoutType.hollowSquare, "hollowSquare_icon.svg");
        ReservationRequestManager.AddMeetingRoom("B103", 25, RoomLayoutType.ushape, "ushape_icon.svg");
        ReservationRequestManager.AddMeetingRoom("C202", 40, RoomLayoutType.classroom, "classroom_icon.svg");
        ReservationRequestManager.AddMeetingRoom("C105", 200, RoomLayoutType.auditorium, "auditorium_icon.svg");
        MainPage = new NavigationPage(new PickRoomPage());
    }
}