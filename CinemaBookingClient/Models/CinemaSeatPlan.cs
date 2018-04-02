using System.Collections.Generic;

namespace CinemaBookingClient.Models
{
    public class CinemaSeatPlan
    {
        public string ErrorDescription { get; set; }
        //a sign of success in obtaining data: 0 - OK, 1 - Error.
        public int ResponseCode { get; set; }        
        public SeatLayoutData SeatLayoutData { get; set; }
    }

    /// <summary>
    ///object with cinema hall.
    ///there are provide a field 100 Х 100 for the cinema hall.
    ///All specitied coordinates at hall scheme are in borders of the field.   
    /// </summary>
    public class SeatLayoutData
    {
        //public List<AreaCategory> AreaCategories { get; set; }
        public List<Area> Areas { get; set; }
        public int BoundaryLeft { get; set; }
        public int BoundaryRight { get; set; }
        public int BoundaryTop { get; set; }
        public int ScreenStart { get; set; }
        public int ScreenWidth { get; set; }        
    }

    /// <summary>
    /// object with list of hall areas.
    /// Each area is rectangular object, there are places inside of it    
    /// </summary>
    public class Area
    {
        public int AreaCategoryCode { get; set; }
        //quantity of places along the Х axis
        public int ColumnCount { get; set; }
        public string Description { get; set; }
        public string DescriptionAlt { get; set; }
        public bool HasSofaSeatingEnabled { get; set; }
        //area height
        public int Height { get; set; }
        public bool IsAllocatedSeating { get; set; }
        //left coordinate of area
        public int Left { get; set; }
        public int Number { get; set; }
        //general quantity of seats in area
        public int NumberOfSeats { get; set; }
        //rows quantity
        public int RowCount { get; set; }
        //object with rows list in borders of area
        public List<AreaRow> Rows { get; set; }
        //top coordinate of area
        public int Top { get; set; }
        //area width
        public int Width { get; set; }
    }

    /// <summary>
    /// object with list of rows in borders of area
    /// </summary>
    public class AreaRow
    {
        //number of row
        public int PhysicalName { get; set; }
        //object with list of places in borders of the row
        public List<Seat> Seats { get; set; }
    }

    /// <summary>
    /// object with list of seats in borders of the row
    /// </summary>
    public class Seat
    {
        //number of place
        public int Id { get; set; }
        public byte OriginalStatus { get; set; }        
        public Position Position { get; set; }
        public byte Priority { get; set; }
        public int SeatStyle { get; set; }
        public int? SeatsInGroup { get; set; }
        //place status. 0 - free. 1 - busy.
        public byte Status { get; set; }
    }

    /// <summary>
    /// object with place data. Those data should be saved to DB when order case   
    /// </summary>
    public class Position
    {
        //number of area
        public int AreaNumber { get; set; }
        //system number of place
        public int ColumnIndex { get; set; }
        //system number of row
        public int RowIndex { get; set; }
    }
}
