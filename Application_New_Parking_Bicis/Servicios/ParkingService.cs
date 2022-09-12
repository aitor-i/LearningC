using System;
using Application_Parking_Bicis.Interfaces;
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

        public async Task<IEnumerable<ParkingViewModel>> GetAllParkings()
        {
            var parkingsCollection = await _ctx.Parkings.Include(parking => parking.User).ToListAsync();
            var mappedParkingsCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
            return mappedParkingsCollection;
            
        }
    }
}

