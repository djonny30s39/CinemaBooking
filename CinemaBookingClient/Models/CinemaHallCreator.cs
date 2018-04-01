using System.Collections.Generic;
using System.Linq;
using CinemaBookingClient.HardCode;
using CinemaBookingClient.Services;
using CinemaBookingClient.ViewModels;

namespace CinemaBookingClient.Models
{
    // todo Make CinemaSeatPlanViewModel live during the entire user's session
    // todo seats not implemented
    public class CinemaHallCreator
    { 
        public static CinemaSeatPlanViewModel GetCinemaHallViewModel(ICinemaSeatPlanWS seatPlan, 
            ICinemaDataService dataSevice, string userID, int? seanceId)
        {
            var cinemaHallModel = dataSevice.GetCinemaHall(HardCodeValues.cinemaId, HardCodeValues.cinemaHallId);
            if (cinemaHallModel == null)
                return null;
            IEnumerable<Ticket> tickets;
            if (seanceId.HasValue)
                tickets = dataSevice.GetSeanceTickets(seanceId.Value);
            else
                tickets = null;
            float unitW = (float)HardCodeValues.cinemaHallWidth / 100;
            float unitH = (float)HardCodeValues.cinemaHallHeight / 100;
            var cinemaHall = seatPlan.GetCinemaSeatPlanAsync().Result;
            var vm = new CinemaSeatPlanViewModel();
            vm.CinemaHallBox.Height = HardCodeValues.cinemaHallHeight;
            vm.CinemaHallBox.Width = HardCodeValues.cinemaHallWidth;
            vm.BoundaryPos.Left = (int)(cinemaHall.SeatLayoutData.BoundaryLeft * unitW);
            vm.BoundaryPos.Top = (int)(cinemaHall.SeatLayoutData.BoundaryTop * unitH);
            vm.ScreenBox.Height = HardCodeValues.screenHeight;
            vm.ScreenBox.Width = (int)(cinemaHall.SeatLayoutData.ScreenWidth * unitW);
            vm.ScreenPos.Left = (int)(cinemaHall.SeatLayoutData.ScreenStart * unitW);
            vm.ScreenPos.Top = 0;

            // CreateAreas 
            foreach (var a in cinemaHall.SeatLayoutData.Areas.OrderBy(z => z.Top))
            {
                VMArea area = new VMArea()
                {
                    Description = a.Description,
                    NumberOfSeats = a.NumberOfSeats,
                    Number = a.Number,
                    ColumnCount = a.ColumnCount,
                    RowCount = a.RowCount, 
                    AreaCategoryCode = a.AreaCategoryCode
                    //Rows = new List<AreaRow>(a.Rows)
                };
                area.AreaBox.Height = (int)(a.Height * unitH);
                area.AreaBox.Width = (int)(a.Width * unitW);
                area.AreaPos.Left = (int)(a.Left * unitW);
                area.AreaPos.Top = (int)(a.Top * unitH);

                area.RowBox.Height =(int)( (float)area.AreaBox.Height / (float)area.RowCount);
                area.RowBox.Width = area.AreaBox.Width;
                area.SeatBox.Height = area.RowBox.Height;
                area.SeatBox.Width = area.RowBox.Width / area.ColumnCount;
                int rowCnt = 0;
                foreach (var r in a.Rows)
                {
                    var row = new VMAreaRow();
                    row.RowPos.Left = 0;
                    row.RowPos.Top = area.RowBox.Height * rowCnt++;
                     
                    foreach (var s in r.Seats)
                    {
                        var seat = new VMSeat();
                        seat.Id = s.Id;
                        seat.Position = new VMPosition { AreaNumber = s.Position.AreaNumber, ColumnIndex = s.Position.ColumnIndex, RowIndex = s.Position.RowIndex };
                        seat.SeatPos.Left = area.SeatBox.Width * seat.Position.ColumnIndex;
                        seat.SeatPos.Top = 0;
                        // booked?
                        var ticket = tickets.FirstOrDefault(t => t.AreaNumber == seat.Position.AreaNumber && 
                            t.ColumnIndex == seat.Position.ColumnIndex && t.RowIndex == seat.Position.RowIndex);
                        if (ticket != null)
                        {
                            seat.Booked = true;
                            if (ticket.Order.Customer.AspNetUsersId == userID)
                                //if (ticket.Order.Customer.Id == userID)
                                    seat.CustomerBooked = true;
                        }
                        row.Seats.Add(seat);
                    }
                        area.Rows.Add(row);
                }
               
                vm.Areas.Add(area);
            }
            return vm;

        }        
    }



}
