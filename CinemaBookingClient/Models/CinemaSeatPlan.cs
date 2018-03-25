using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.Models
{
    public class CinemaSeatPlan
    {
        public string ErrorDescription { get; set; }
        //признак успешности получения данных. 0 - OK, иначе ошибка.
        public int ResponseCode { get; set; }        
        public SeatLayoutData SeatLayoutData { get; set; }
    }

    /// <summary>
    ///объект со схемой зала. Для схемы зала выделено поле 100 Х 100. Все координаты,
    ///которые указаны в схеме зала будут в рамках этого поля.
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
    /// объект со списком зон зала. Каждая зона являет собой прямоугольный объект,
    /// внутри которого расположены места.
    /// </summary>
    public class Area
    {
        public int AreaCategoryCode { get; set; }
        //количество мест по оси Х
        public byte ColumnCount { get; set; }
        public string Description { get; set; }
        public string DescriptionAlt { get; set; }
        public bool HasSofaSeatingEnabled { get; set; }
        //высота зоны
        public byte Height { get; set; }
        public bool IsAllocatedSeating { get; set; }
        //левая координата зоны
        public byte Left { get; set; }
        public byte Number { get; set; }
        //общее количество мест в зоне
        public int NumberOfSeats { get; set; }
        //количество рядов
        public byte RowCount { get; set; }
        //объект со списом рядов в рамках зоны
        public List<AreaRow> Rows { get; set; }
        //верхняя координата зоны
        public byte Top { get; set; }
        //ширина зоны
        public byte Width { get; set; }
    }

    /// <summary>
    /// объект со списом рядов в рамках зоны
    /// </summary>
    public class AreaRow
    {
        //номер ряда
        public int PhysicalName { get; set; }
        //объект со списком мест в рамках ряда
        public List<Seat> Seats { get; set; }
    }

    /// <summary>
    /// объект со списком мест в рамках ряда
    /// </summary>
    public class Seat
    {
        //номер места
        public int Id { get; set; }
        public byte OriginalStatus { get; set; }        
        public Position Position { get; set; }
        public byte Priority { get; set; }
        public int SeatStyle { get; set; }
        public int? SeatsInGroup { get; set; }
        //статус места. 0 - свободно. 1 - занято.
        public byte Status { get; set; }
    }

    /// <summary>
    /// объект с данными по месту. Эти данные надо сохранить в
    /// БД при заказе места
    /// </summary>
    public class Position
    {
        //номер зоны
        public int AreaNumber { get; set; }
        //системный номер места
        public int ColumnIndex { get; set; }
        //системный номер ряда
        public int RowIndex { get; set; }
    }
}
