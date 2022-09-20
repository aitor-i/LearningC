using System;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.UOW;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using Data_Parking_Bicis.Model;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
    public class ParkingService :BaseService, IParkingService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ParkingService( IMapper mapper, IUnitOfWork unitOfWork) : base( mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceQueryResponse<ParkingViewModel>> GetAllParkings()
        {
            ServiceQueryResponse<ParkingViewModel> response = new ServiceQueryResponse<ParkingViewModel>();
            response.IsSuccess = false;

            try
            {
                var parkingsCollection = await _unitOfWork.ParkingRepository.GetValues();
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

        public async Task<ServiceQueryResponse<ParkingViewModel>> FindParking(int id)
        {
            ServiceQueryResponse<ParkingViewModel> response = new ServiceQueryResponse<ParkingViewModel>();
            try
            {
             
                var parkingResult = await _unitOfWork.ParkingRepository.Find(id);
                var mappedParking = _mapper.Map< ParkingViewModel>(parkingResult);
                response.Single = mappedParking;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response; 
        }
    }
}

