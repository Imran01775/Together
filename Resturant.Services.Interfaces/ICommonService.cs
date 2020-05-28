using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;

namespace Resturant.Services.Interfaces
{

    public interface IUserTypeService
    {
        Task<UserTypeDTO> UserTypeEntryUpdate(UserTypeDTO userTypeDTO);
        Task<UserTypeDTO> UserTypeDelete(UserTypeDTO userTypeDTO);

    }
    public interface IStatusService
    {
        Task<StatusDTO> StatusEntryUpdate(StatusDTO statusDTO);
        Task<StatusDTO> StatusDelete(StatusDTO statusDTO);
    }
    public interface ILocationService
    {
        Task<LocationDTO> LocationEntryUpdate(LocationDTO locationDTO);
        Task<LocationDTO> LocationDelete(LocationDTO locationDTO);
    }

}
