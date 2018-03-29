using CinemaBookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
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
        //количество мест по оси Х
        public int ColumnCount { get; set; }
        public string Description { get; set; }
        public string DescriptionAlt { get; set; }
        public bool HasSofaSeatingEnabled { get; set; }        
        public bool IsAllocatedSeating { get; set; }         
        public int Number { get; set; }
        //общее количество мест в зоне
        public int NumberOfSeats { get; set; }
        //количество рядов
        public int RowCount { get; set; }
        //объект со списом рядов в рамках зоны
        public List<VMAreaRow> Rows { get; set; } = new List<VMAreaRow>();
        public VMBoxPx AreaBox { get; internal set; } = new VMBoxPx();
        public VMPosPx AreaPos { get; internal set; } = new VMPosPx();
        public VMBoxPx RowBox { get; internal set; } = new VMBoxPx();
        public VMBoxPx SeatBox { get; internal set; } = new VMBoxPx();
    } 
    
    public class VMAreaRow
    {
        //номер ряда
        public int PhysicalName { get; set; }
        //объект со списком мест в рамках ряда
        public List<VMSeat> Seats { get; set; } = new List<VMSeat>();
        public VMPosPx RowPos { get; internal set; } = new VMPosPx(); 
    } 
     
    public class VMSeat
    {
        //номер места
        public int Id { get; set; }
        public byte OriginalStatus { get; set; }
        public VMPosition Position { get; set; }
        public byte Priority { get; set; }
        public int SeatStyle { get; set; }
        public int? SeatsInGroup { get; set; }
        //статус места. 0 - свободно. 1 - занято.
        public byte Status { get; set; }
        public VMPosPx SeatPos { get; internal set; } = new VMPosPx();
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
