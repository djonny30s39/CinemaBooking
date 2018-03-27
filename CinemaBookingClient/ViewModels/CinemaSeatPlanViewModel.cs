using CinemaBookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingClient.ViewModels
{
    public class CinemaSeatPlanViewModel
    {
        private CinemaSeatPlan cinemaSeatPlan;
        public int CinemaHallHeight { get; internal set; }
        public int CinemaHallWidth { get; internal set; }
        public List<Area> Areas { get; private set; } = new List<Area>();
        public int BoundaryLeft { get; private set; }
        public int BoundaryRight { get; private set; }
        public int BoundaryTop { get; private set; }
        public int ScreenStart { get; private set; }
        public int ScreenWidth { get; private set; }

        public CinemaSeatPlanViewModel(CinemaSeatPlan cinemaSeatPlan)
        {
            this.cinemaSeatPlan = cinemaSeatPlan;
        }

        public void CalculateRealCinemaHall()
        {
            BoundaryTop = CinemaHallHeight - cinemaSeatPlan.SeatLayoutData.BoundaryTop * CinemaHallHeight / 100;
            BoundaryRight = CinemaHallWidth - cinemaSeatPlan.SeatLayoutData.BoundaryRight * CinemaHallWidth / 100;
            BoundaryLeft = cinemaSeatPlan.SeatLayoutData.BoundaryLeft * CinemaHallWidth / 100;
            GetAreas();
        }

        private void GetAreas()
        {            
            foreach (var a in cinemaSeatPlan.SeatLayoutData.Areas)
            {
                Area area = new Area
                {
                    Left = (a.Left - cinemaSeatPlan.SeatLayoutData.ScreenStart) * CinemaHallWidth / 100,
                    Top = (CinemaHallHeight - (cinemaSeatPlan.SeatLayoutData.BoundaryTop * CinemaHallHeight / 100)) - (CinemaHallHeight - (a.Top * CinemaHallHeight) / 100),
                    Description = a.Description,
                    NumberOfSeats = a.NumberOfSeats,
                    Number = a.Number,
                    ColumnCount = a.ColumnCount,
                    RowCount = a.RowCount,
                    Rows = new List<AreaRow>(),
                    Height = a.Height * CinemaHallHeight / 100
                };
                area.Width = a.Width * CinemaHallWidth / 100;
                    
                area.Rows = a.Rows;
                Areas.Add(area);
            }
        }

        private void GetSeats(List<AreaRow> areaRows, int rowCount, int columnCount)
        {
            foreach(var seat in areaRows)
            {

            }
        }
    }
}
