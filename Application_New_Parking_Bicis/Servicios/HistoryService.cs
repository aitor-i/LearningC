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
using Microsoft.EntityFrameworkCore;

namespace Application_Parking_Bicis.Servicios
{
	public class HistoryService:BaseService,  IHistoryService
    {
        public HistoryService(DataContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public async Task<ServiceQueryResponse<HistoryViewModel>> GetAllHistory()
        {
            ServiceQueryResponse<HistoryViewModel> response = new ServiceQueryResponse<HistoryViewModel>() { IsSuccess = false };
            try
            {
                var allHistoriesCollection = await _ctx.Histories
                                                        .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                        .ToListAsync();
                response.IsSuccess = true;
                response.Data = allHistoriesCollection;


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
                await _ctx.Histories.AddAsync(mappedParkingRegistration);
                await _ctx.SaveChangesAsync();

                response.IsSuccess = true;
                response.Response = mappedParkingRegistration.Id;


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }

            return response;
        }


    }
}

