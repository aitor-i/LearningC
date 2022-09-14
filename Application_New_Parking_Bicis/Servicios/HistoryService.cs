using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Interfaces;
using Application_Parking_Bicis.Message;
using Application_Parking_Bicis.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data_Parking_Bicis.data;
using Data_Parking_Bicis.Model;
using Data_Parking_Bicis.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
	public class HistoryService:BaseService,  IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryService(DataContext ctx, IMapper mapper,IHistoryRepository historyRepository) : base( mapper)
        {
            _historyRepository = historyRepository;
        }

        public async Task<ServiceQueryResponse<HistoryViewModel>> GetAllHistory()
        {
            ServiceQueryResponse<HistoryViewModel> response = new ServiceQueryResponse<HistoryViewModel>() { IsSuccess = false };
            try
            {
                var allHistoriesCollection = await _historyRepository.GetValues();
                var mappedHistoryCollection = _mapper.Map<IEnumerable<HistoryViewModel>>(allHistoriesCollection);
                
                                                                                                             
                response.IsSuccess = true;
                response.Data = mappedHistoryCollection;


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
                var res = await _historyRepository.Insert(mappedParkingRegistration);

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

