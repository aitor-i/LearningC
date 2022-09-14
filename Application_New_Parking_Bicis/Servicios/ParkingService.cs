using System;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Data_Parking_Bicis.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
    public class ParkingService :BaseService, IParkingService
    {
        private readonly IParkingRepository _parkingRepository; 
        public ParkingService(DataContext ctx, IMapper mapper, IParkingRepository parkingRepository) : base(ctx, mapper)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task<ServiceQueryResponse<ParkingViewModel>> GetAllParkings()
        {
            ServiceQueryResponse<ParkingViewModel> response = new ServiceQueryResponse<ParkingViewModel>();
            response.IsSuccess = false;

            try
            {
                var parkingsCollection = await _parkingRepository.GetValues();
                var mappedParkingsCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
                response.IsSuccess = true;
                response.Data = mappedParkingsCollection;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
               
            }
            return response ;
            
        }
    }
}

