using System.Collections.Generic;

namespace CinemaBookingClient.ViewModels
{
    /// <summary>
    /// All coordinates are in pixels!!!
    /// </summary>
    public class CinemaSeatPlanViewModel
    {
        public List<VMArea> Areas { get; internal set; } = new List<VMArea>();
        public VMBoxPx CinemaHallBox { get; internal set; } = new VMBoxPx();
        public VMPosPx BoundaryPos { get; internal set; } = new VMPosPx();
        public VMBoxPx ScreenBox { get; internal set; } = new VMBoxPx();
        public VMPosPx ScreenPos { get; internal set; } = new VMPosPx();
    } 
     
    public class VMArea
    {
        public int AreaCategoryCode { get; set; }
        //number of places along the Х axis
        public int ColumnCount { get; set; }
        public string Description { get; set; }
        public string DescriptionAlt { get; set; }
        public bool HasSofaSeatingEnabled { get; set; }        
        public bool IsAllocatedSeating { get; set; }         
        public int Number { get; set; }
        //general quantity of seats in area
        public int NumberOfSeats { get; set; }
        //rows quantity
        public int RowCount { get; set; }
        //object with rows list in borders of area
        public List<VMAreaRow> Rows { get; set; } = new List<VMAreaRow>();
        public VMBoxPx AreaBox { get; internal set; } = new VMBoxPx();
        public VMPosPx AreaPos { get; internal set; } = new VMPosPx();
        public VMBoxPx RowBox { get; internal set; } = new VMBoxPx();
        public VMBoxPx SeatBox { get; internal set; } = new VMBoxPx();
    } 
    
    public class VMAreaRow
    {
        //number of row
        public int PhysicalName { get; set; }
        //object with rows list in borders of row
        public List<VMSeat> Seats { get; set; } = new List<VMSeat>();
        public VMPosPx RowPos { get; internal set; } = new VMPosPx(); 
    } 
     
    public class VMSeat
    {
        //number of row
        public int Id { get; set; }
        public byte OriginalStatus { get; set; }
        public VMPosition Position { get; set; }
        public byte Priority { get; set; }
        public int SeatStyle { get; set; }
        public int? SeatsInGroup { get; set; }
        //seat status. 0 - free. 1 - busy.
        public byte Status { get; set; }
        public VMPosPx SeatPos { get; internal set; } = new VMPosPx();
        public bool Booked { get; set; } = false;
        public bool CustomerBooked { get; set; } = false;
    }

    public class VMPosition
    { 
        public int AreaNumber { get; set; } 
        public int ColumnIndex { get; set; } 
        public int RowIndex { get; set; }
    }

    public class VMBoxPx
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class VMPosPx
    { 
        public int Left { get; set; }
        public int Top { get; set; }
    }
}
