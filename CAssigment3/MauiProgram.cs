using Microsoft.Extensions.Logging;

namespace CAssigment3
{

    public enum RoomLayoutType
    {
        HollowSquare,
        UShape,
        Classroom,
        Auditorium
    }


    public enum RequestStatus
    {
        Accepted,
        Rejected,
        Pending
    }
    
    public class MeetingRoom
    {
        private string _roomNumber;
        private int _seatingCapacity;
        private string _roomImageFileName;


        public MeetingRoom(string roomNumber, int seatingCapacity, RoomLayoutType roomLayout, string roomImageFileName)
        {
            RoomNumber = roomNumber;
            SeatingCapacity = seatingCapacity;
            RoomLayout = roomLayout;
            RoomImageFileName = roomImageFileName;
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Room number is required.");
                _roomNumber = value;
            }
        }
        
        public int SeatingCapacity
        {
            get => _seatingCapacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Seating capacity must be greater than 0.");
                _seatingCapacity = value;
            }
        }

        public RoomLayoutType RoomLayout { get; set; }
        
        public string RoomImageFileName
        {
            get => _roomImageFileName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Room image file name is required.");
                _roomImageFileName = value;
            }
        }


        public string RoomTypeIcon
        {
            get => RoomLayout.ToString() + ".png";
        }
    }


    public class ReservationRequest
    {
        private int _participantCount;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private string _requestedBy;
        private string _description;


        public ReservationRequest(
            string requestedBy,
            string description,
            DateTime meetingDate,
            TimeSpan startTime,
            TimeSpan endTime,
            int participantCount,
            MeetingRoom meetingRoom)
        {
            RequestedBy = requestedBy;
            Description = description;
            MeetingDate = meetingDate;
            StartTime = startTime;
            EndTime = endTime;
            ParticipantCount = participantCount;
            RequestStatus = RequestStatus.Pending; 
            MeetingRoom = meetingRoom;
        }

        public int RequestID { get; set; }
        public string RequestedBy
        {
            get => _requestedBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("RequestedBy is required.");
                _requestedBy = value;
            }
        }


        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Description is required.");
                _description = value;
            }
        }


        public DateTime MeetingDate { get; set; }
        
        public TimeSpan StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }


        public TimeSpan EndTime
        {
            get => _endTime;
            set
            {
                if (value <= StartTime)
                    throw new ArgumentException("End time must be greater than start time.");
                _endTime = value;
            }
        }
        
        public int ParticipantCount
        {
            get => _participantCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Participant count must be greater than 0.");
                _participantCount = value;
            }
        }
        public RequestStatus RequestStatus { get; set; }

        
        public MeetingRoom MeetingRoom { get; set; }
    }
    
    public class ReservationRequestManager
    {
        private readonly List<MeetingRoom> _meetingRooms;
        private readonly List<ReservationRequest> _reservationRequests;
        private int _nextRequestId;

        
        public ReservationRequestManager()
        {
            _meetingRooms = new List<MeetingRoom>();
            _reservationRequests = new List<ReservationRequest>();
            _nextRequestId = 1; 
        }
        
        public bool AddMeetingRoom(
            string roomNumber,
            int seatingCapacity,
            RoomLayoutType roomLayout,
            string roomImageFileName)
        {

            bool duplicate = _meetingRooms.Any(r =>
                r.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase));

            if (duplicate)
            {

                return false;
            }

            var newRoom = new MeetingRoom(roomNumber, seatingCapacity, roomLayout, roomImageFileName);
            _meetingRooms.Add(newRoom);
            return true;
        }

        public ReservationRequest AddReservationRequest(
            string roomNumber,
            string requestedBy,
            string description,
            DateTime meetingDate,
            TimeSpan startTime,
            TimeSpan endTime,
            int participantCount)
        {
            var room = _meetingRooms.FirstOrDefault(r =>
                r.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase));

            if (room == null)
            {
                throw new ArgumentException("Meeting room not found.");
            }

            
            if (participantCount > room.SeatingCapacity)
            {
                throw new ArgumentException("Participant count exceeds the room's seating capacity.");
            }
            
            var request = new ReservationRequest(
                requestedBy,
                description,
                meetingDate,
                startTime,
                endTime,
                participantCount,
                room)
            {
                RequestID = _nextRequestId++
            };

            _reservationRequests.Add(request);
            return request;
        }


        public IReadOnlyList<MeetingRoom> MeetingRooms => _meetingRooms.AsReadOnly();
        public IReadOnlyList<ReservationRequest> ReservationRequests => _reservationRequests.AsReadOnly();
    }
}
