using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_Parking_Bicis.Interfaces;
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

        public async Task<IEnumerable<HistoryViewModel>> GetAllHistory()
        {
            var allHistoriesCollection = await _ctx.Histories
                                                    .ProjectTo<HistoryViewModel>(_mapper.ConfigurationProvider)
                                                    .ToListAsync();
            return allHistoriesCollection;
        }

        public async Task<int> NewParkingUsage(HistoryViewModel newParkingRegistration)
        {
            var mappedParkingRegistration = _mapper.Map<History>(newParkingRegistration);

            try
            {
                await _ctx.Histories.AddAsync(mappedParkingRegistration);
                await _ctx.SaveChangesAsync();
                return newParkingRegistration.Id;


            }
            catch (Exception ex)
            {
                return -1;
            }
        }


    }
}

