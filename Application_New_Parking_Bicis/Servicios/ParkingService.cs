using System;
using System.ComponentModel.DataAnnotations;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.UOW;
using Application_Parking_Bicis.Validators;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
                var parkingsCollection = await _unitOfWork.ParkingRepository.GetQuery().ProjectTo<ParkingViewModel>(_mapper.ConfigurationProvider).ToListAsync();
                // var mappedParkingsCollection = _mapper.Map<IEnumerable<Parkings>, IEnumerable<ParkingViewModel>>(parkingsCollection);
                response.IsSuccess = true;
                response.Data = parkingsCollection;

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

        public async Task<ServiceComandResponse> NewParking(NewParkingForm parkingForm)
        {
            ServiceComandResponse response = new ServiceComandResponse();
            try
            {
                NewParkingFormValidator validator = new NewParkingFormValidator();
                var result = validator.Validate(parkingForm);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        response.Message =  response.Message + "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + "\n";
                    }
                    throw new Exception();
                }
                else
                {

                var parking = _mapper.Map<Parkings>(parkingForm);
                var res = await _unitOfWork.ParkingRepository.Insert(parking);
                response.IsSuccess = true;
                response.Response = res;
                }
                }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ServiceComandResponse> ChangeParkingName(ParkingViewModel newParking)
        {
            ServiceComandResponse response = new ServiceComandResponse();
            try
            {
                //any(parkingId)
                // var modelledParking = _mapper.Map<Parkings>(newParking);
                var parking = await _unitOfWork.ParkingRepository.Find(newParking.Id);
                parking.ParkinName = newParking.ParkinName;
                var res = await _unitOfWork.ParkingRepository.Edit(parking, newParking.Id);

                response.IsSuccess = true;
                response.Response = res.Id;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }
    }
}

