using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.Entities;
using Resturant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{
    public class CommonRepository : IUserTypeRepository, IStatusRepository, ILocationRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CommonRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public async Task<LocationDTO> LocationDelete(LocationDTO locationDTO)
        {
            var dataObject = locationDTO as Location;
            _sqlServerContext.Remove<Location>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return locationDTO;
        }

        public async Task<LocationDTO> LocationEntryUpdate(LocationDTO locationDTO)
        {
            var dataObject = locationDTO as Location;
            if (locationDTO.LocationId == 0)
            {
                await _sqlServerContext.AddAsync<Location>(dataObject);
            }
            else
            {
                _sqlServerContext.Update<Location>(dataObject);
            }



            await _sqlServerContext.SaveChangesAsync();
            return locationDTO;
        }

        public async Task<StatusDTO> StatusDelete(StatusDTO statusDTO)
        {
            var dataObject = statusDTO as Status;
            _sqlServerContext.Remove<Status>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return statusDTO;
        }

        public async Task<StatusDTO> StatusEntryUpdate(StatusDTO statusDTO)
        {
            var dataObject = statusDTO as Status;
            if (statusDTO.StatusId == 0)
            {
                await _sqlServerContext.AddAsync<Status>(dataObject);
            }
            else
            {
                _sqlServerContext.Update<Status>(dataObject);
            }
            await _sqlServerContext.SaveChangesAsync();
            return statusDTO;
        }

        public async Task<UserTypeDTO> UserTypeDelete(UserTypeDTO userTypeDTO)
        {
            var dataObject = userTypeDTO as UserType;
            _sqlServerContext.Remove<UserType>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return userTypeDTO;
        }

        public async Task<UserTypeDTO> UserTypeEntryUpdate(UserTypeDTO userTypeDTO)
        {
            var dataObject = userTypeDTO as UserType;
            if (userTypeDTO.UserTypeId == 0)
            {
                await _sqlServerContext.AddAsync<UserType>(dataObject);
            }
            else
            {
                _sqlServerContext.Update<UserType>(dataObject);
            }
            await _sqlServerContext.SaveChangesAsync();
            return userTypeDTO;
        }
    }
}
