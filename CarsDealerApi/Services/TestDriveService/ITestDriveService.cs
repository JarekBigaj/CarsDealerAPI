using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.TestDrive;

namespace CarsDealerApi.Services.TestDriveService
{
    public interface ITestDriveService
    {
        Task<ServiceResponse<List<GetTestDriveDto>>> GetAllTestDrive();
        Task<ServiceResponse<GetTestDriveDto>> GetTestDriveById(int id);
        Task<ServiceResponse<List<GetTestDriveDto>>> AddTestDrive(AddTestDriveDto newTestDrive);
    }
}