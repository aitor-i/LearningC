using System;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
    public class ParkingService :BaseService, IParkingService
    {
        public ParkingService(DataContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public async Task<ServiceQueryResponse<ParkingViewModel>> GetAllParkings()
        {
            ServiceQueryResponse<ParkingViewModel> response = new ServiceQueryResponse<ParkingViewModel>();
            response.IsSuccess = false;

            try
            {
                var parkingsCollection = await _ctx.Parkings.Include(parking => parking.User).ToListAsync();
                var mappedParkingsCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
                response.IsSuccess = true;
                response.Data = mappedParkingsCollection;

            }
            catch (Exception ex)
            {

            }
            return response;
            
        }
    }
}

