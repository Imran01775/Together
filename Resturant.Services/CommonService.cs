using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Interfaces;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class CommonService : IUserTypeService, IStatusService, ILocationService
    {

        private readonly IUserTypeRepository _userTypeRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IStatusRepository _statusRepository;
        public CommonService(IUserTypeRepository userTypeRepository, ILocationRepository locationRepository, IStatusRepository statusRepository)
        {
            _userTypeRepository = userTypeRepository;
            _locationRepository = locationRepository;
            _statusRepository = statusRepository;
        }
        public async Task<LocationDTO> LocationDelete(LocationDTO locationDTO)
        {
            return await _locationRepository.LocationDelete(locationDTO);
        }

        public async Task<LocationDTO> LocationEntryUpdate(LocationDTO locationDTO)
        {
            return await _locationRepository.LocationEntryUpdate(locationDTO);
        }

        public async Task<StatusDTO> StatusDelete(StatusDTO statusDTO)
        {
            return await _statusRepository.StatusDelete(statusDTO);
        }

        public async Task<StatusDTO> StatusEntryUpdate(StatusDTO statusDTO)
        {
            return await _statusRepository.StatusEntryUpdate(statusDTO);
        }

        public async Task<UserTypeDTO> UserTypeDelete(UserTypeDTO userTypeDTO)
        {
            return await _userTypeRepository.UserTypeDelete(userTypeDTO);
        }

        public async Task<UserTypeDTO> UserTypeEntryUpdate(UserTypeDTO userTypeDTO)
        {
            return await _userTypeRepository.UserTypeEntryUpdate(userTypeDTO);
        }
    }
}
