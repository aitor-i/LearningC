using System.Collections.Generic;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.Servicios.Interfaces;
using Application_Parking_Bicis.UOW;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Parking_Bicis.Model;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
	public class HistoryService:BaseService,  IHistoryService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public HistoryService( IMapper mapper, IUnitOfWork unitOfWork) : base( mapper)
        {
           
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceQueryResponse<HistoryViewModel>> GetAllHistory()
        {
            ServiceQueryResponse<HistoryViewModel> response = new ServiceQueryResponse<HistoryViewModel>() { IsSuccess = false };
            try
            {
                var allHistoriesCollection = await _unitOfWork.HistoryRepository.GetQuery().ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider).ToListAsync();
                                                                                                                             
                response.IsSuccess = true;
                response.Data = allHistoriesCollection;


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceQueryResponse<HistoryViewModel>> SearchHistory(string pattern)
        {
            ServiceQueryResponse<HistoryViewModel> response = new ServiceQueryResponse<HistoryViewModel>();

            try
            {
               // Regex expresion = new Regex($"/{pattern}/i");
               /*
                var filteredHistoriesCollection = await _unitOfWork.HistoryRepository.GetQuery()
                                                                                 .Where(history => history.User.Username.Contains(pattern) || history.Parking.ParkinName.Contains(pattern))
                                                                                 .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                                                 .ToListAsync();
                var patternMAtchingHistoriesCollerction = await _unitOfWork.HistoryRepository.GetQuery()
                                                                                 .Where(history => history.Parking.ParkinName.Contains(pattern))
                                                                                 .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                                                 .ToListAsync();
               
                // filteredHistoriesCollection.AddRange(patternMAtchingHistoriesCollerction);
                filteredHistoriesCollection.Union(patternMAtchingHistoriesCollerction);
               */
                /*
                var searchedHistoryCollection = await _unitOfWork.HistoryRepository.GetQuery()
                                                                                    .Where(history => history.User.Username.Contains(pattern) || history.Parking.ParkinName.Contains(pattern))
                                                                                    .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                                                    .ToListAsync();
                */
               
                var searchedHistoryCollection = await _unitOfWork.HistoryRepository.GetQuery(history => history.User.Username.Contains(pattern) || history.Parking.ParkinName.Contains(pattern))
                                                                                   .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                                                   .OrderBy(x=> x.Username)
                                                                                   .ToListAsync()
                                                                                   ;

               // var mappedSearchedHistoryCollection = _mapper.Map<IEnumerable<HistoryViewModel>>(searchedHistoryCollection);

                response.IsSuccess = true;
                response.Data = searchedHistoryCollection;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ServiceComandResponse> NewParkingUsage(HistoryViewModel newParkingRegistration)
        {
            ServiceComandResponse response = new ServiceComandResponse() { IsSuccess = false };

            try
            {
                var mappedParkingRegistration = _mapper.Map<History>(newParkingRegistration);
                var res = await _unitOfWork.HistoryRepository.Insert(mappedParkingRegistration);

                response.IsSuccess = true;
                response.Response = res;


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }


    }
}

