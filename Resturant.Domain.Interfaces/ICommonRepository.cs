using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;

namespace Resturant.Domain.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<UserTypeDTO> UserTypeDelete(UserTypeDTO userTypeDTO);
        Task<UserTypeDTO> UserTypeEntryUpdate(UserTypeDTO userTypeDTO);
    }
    public interface ILocationRepository
    {
        Task<LocationDTO> LocationDelete(LocationDTO locationDTO);
        Task<LocationDTO> LocationEntryUpdate(LocationDTO locationDTO);
    }
    public interface IStatusRepository
    {
        Task<StatusDTO> StatusDelete(StatusDTO statusDTO);
        Task<StatusDTO> StatusEntryUpdate(StatusDTO statusDTO);
    }
}
